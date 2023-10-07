using AnimeFlix.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.PlanCommand
{
    public abstract class PlanCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public int DurationInDays { get; protected set; }
        public bool IsActive { get; protected set; }

    }
}
