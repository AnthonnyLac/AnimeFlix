using AnimeFlix.Domain.Commands.PlanCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Validations.PlanCommandValidation
{
    public class DeletePlanCommandValidation : PlanValidation<PlanCommand>
    {
        public DeletePlanCommandValidation() 
        {
            ValidateId();
        }
    }
}
