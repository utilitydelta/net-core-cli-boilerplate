using System.Collections.Generic;
using CommandLine;
using UtilityDelta.Domain.Dto;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Cli.Verbs
{
    [Verb("add", HelpText = "Add some numbers together.")]
    public class Add : BaseOperation
    {
        [Option('a', "numbers-to-add", Separator = ',',
            HelpText = "Add all these numbers to the base number, seperate them by a ','.")]
        public IEnumerable<double> NumbersToAdd { get; set; }

        public override bool Process(IServiceResolver services)
        {
            if (!base.Process(services))
            {
                return false;
            }

            return services.GetService<IManageCalculation>().PerformOperation(new DtoCalculationInput
            {
                InitialValue = BaseNumber,
                Operation = DtoCalculationInput.OperationType.Add,
                ValuesToProcess = NumbersToAdd
            });
        }
    }
}