using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.SubscriptionCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.User;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class SubscriptionCommandHandler : CommandHandler,
        IRequestHandler<RegisterSubscriptionCommand, ValidationResult>,
        IRequestHandler<UpdateSubscriptionCommand, ValidationResult>,
        IRequestHandler<DeleteSubscriptionCommand, ValidationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPlanRepository _planRepository;

        public SubscriptionCommandHandler(IUserRepository userRepository, ISubscriptionRepository subscriptionRepository, IPlanRepository planRepository)
        {
            _userRepository = userRepository;
            _subscriptionRepository = subscriptionRepository;
            _planRepository = planRepository;
        }
        public async Task<ValidationResult> Handle(RegisterSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetById(request.UserId);

                if (user == null)
                {
                    throw new Exception("O usuario não existe!");
                }

                var plan = await _planRepository.GetById(request.PlanId);

                if (plan == null)
                {
                    throw new Exception("O plano não existe!");
                }

                var subscription = await _subscriptionRepository.GetSubscriptionByUserId(request.UserId);

                if (subscription != null)
                {
                    throw new Exception("Esse usuario já tem plano!");
                }

                var userSubscriptionModel = new UserSubscriptionModel(request.UserId, request.PlanId, DateTime.Now, DateTime.Now.AddDays(plan.DurationInDays));

                _subscriptionRepository.Add(userSubscriptionModel);


                return await Commit(_subscriptionRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
        public async Task<ValidationResult> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetById(request.UserId);

                if (user == null)
                {
                    throw new Exception("O usuario não existe!");
                }

                var plan = await _planRepository.GetById(request.PlanId);

                if (plan == null)
                {
                    throw new Exception("O plano não existe!");
                }

                var subscription = await _subscriptionRepository.GetById(request.Id);

                if (subscription == null)
                {
                    throw new Exception("Esse plano não existe!");
                }

                var userSubscription = await _subscriptionRepository.GetSubscriptionByUserId(request.UserId);

                if (userSubscription != null && userSubscription.Id != subscription.Id) 
                {
                    throw new Exception("Não é possivel mover o plano de um usuario para outro!");
                }

                if (request.SubscriptionStartDate < DateTime.Now.AddHours(-1))
                {
                    throw new Exception("Intervalo de data invalido");
                }

                if ((request.SubscriptionEndDate - request.SubscriptionStartDate).TotalDays > plan.DurationInDays)
                {
                    throw new Exception("Intervalo de data invalido");
                }

                var userSubscriptionModel = new UserSubscriptionModel(request.UserId, request.PlanId, request.SubscriptionStartDate, request.SubscriptionEndDate);
                userSubscriptionModel.SetId(request.Id);

                _subscriptionRepository.Update(userSubscriptionModel);


                return await Commit(_subscriptionRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }



        public async Task<ValidationResult> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var subscription = await _subscriptionRepository.GetById(request.Id);

                if (subscription == null)
                {
                    throw new Exception("Esse usuario não tem plano!");
                }

              
                _subscriptionRepository.Remove(subscription);


                return await Commit(_subscriptionRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
