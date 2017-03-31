using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Domain
{
    public class UserCommunication : IUserCommunication
    {
        private const string CApplicationError = "APPLICATION_ERROR";
        private const string CInputError = "INPUT_ERROR";
        private readonly IConsoleStream m_consoleStream;

        private bool m_verboseMode;

        public UserCommunication(IConsoleStream consoleStream)
        {
            m_consoleStream = consoleStream;
        }

        public bool HasError { get; private set; }

        public bool SetVerboseMode
        {
            set { m_verboseMode = value; }
        }

        public void WriteErrorLine(string error, bool isInputError)
        {
            HasError = true;
            var code = isInputError ? CInputError : CApplicationError;
            m_consoleStream.WriteError($"{code}: {error}");
        }

        public void WriteOutputLine(string output, bool verboseOnly)
        {
            if (m_verboseMode && verboseOnly || !verboseOnly)
            {
                m_consoleStream.WriteOutput(output);
            }
        }
    }
}