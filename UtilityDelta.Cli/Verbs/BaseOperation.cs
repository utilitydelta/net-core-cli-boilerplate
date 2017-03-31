using CommandLine;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Cli.Verbs
{
    public abstract class BaseOperation : Base
    {
        [Option('b', "base-number", Required = true, HelpText = "What number to start the operation with")]
        public double BaseNumber { get; set; }

        public override bool Process(IServiceResolver services)
        {
            if (!base.Process(services))
            {
                return false;
            }

            return true;
        }
    }
}