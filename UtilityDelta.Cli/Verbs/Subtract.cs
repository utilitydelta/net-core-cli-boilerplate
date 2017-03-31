using System.Collections.Generic;
using CommandLine;
using UtilityDelta.Domain.Dto;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Cli.Verbs
{
    [Verb("subtract", HelpText = "Subtract some numbers from each other.")]
    public class Subtract : BaseOperation
    {
        [Option('s', "numbers-to-subtract", Separator = ',', HelpText = "Subtract all these numbers from the base number, seperate them by a ','.")]
        public IEnumerable<double> NumbersToSubtract { get; set; }

        public override bool Process(IServiceResolver services)
        {
            if (!base.Process(services))
            {
                return false;
            }

            return services.GetService<IManageCalculation>().PerformOperation(new DtoCalculationInput
            {
                InitialValue = BaseNumber,
                Operation = DtoCalculationInput.OperationType.Subtract,
                ValuesToProcess = NumbersToSubtract
            });
        }
    }
}