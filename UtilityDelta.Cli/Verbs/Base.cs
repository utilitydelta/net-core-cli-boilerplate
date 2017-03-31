using CommandLine;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Cli.Verbs
{
    public abstract class Base
    {
        [Option('v', "verbose", HelpText = "Output detailed logging information.")]
        public bool Verbose { get; set; }

        public virtual bool Process(IServiceResolver services)
        {
            var comms = services.GetService<IUserCommunication>();
            comms.SetVerboseMode = Verbose;
            return true;
        }
    }
}