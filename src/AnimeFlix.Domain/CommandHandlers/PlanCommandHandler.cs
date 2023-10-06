using AnimeFlix.Domain.Commands.PlanCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Plan;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class PlanCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPlanCommand, ValidationResult>,
        IRequestHandler<UpdatePlanCommand, ValidationResult>,
        IRequestHandler<DeletePlanCommand, ValidationResult>
    {
        private readonly IPlanRepository _planRepository;

        public PlanCommandHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewPlanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var plan = await _planRepository.GetByName(request.Name);

                if (plan != null)
                {
                    throw new Exception("O plano já existe");
                }

                var planModel = new SubscriptionPlanModel(request.Name,request.Description,request.Price, request.DurationInDays,true);

                _planRepository.Add(planModel);


                return await Commit(_planRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var plan = await _planRepository.GetById(request.Id);

                if (plan == null)
                {
                    throw new Exception("Plano não encotrado");
                }

                var planModel = new SubscriptionPlanModel(request.Name, request.Description, request.Price, request.DurationInDays, true);
                planModel.SetIdPlan(request.Id);

                _planRepository.Update(planModel);


                return await Commit(_planRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var plan = await _planRepository.GetById(request.Id);

                if (plan == null)
                {
                    throw new Exception("Plano não encotrado");
                }

                _planRepository.Remove(plan);

                return await Commit(_planRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
