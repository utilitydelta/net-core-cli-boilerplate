namespace UtilityDelta.Domain.Interface
{
    public interface IUserCommunication
    {
        bool HasError { get; }
        bool SetVerboseMode { set; }
        void WriteErrorLine(string error, bool isInputError);
        void WriteOutputLine(string output, bool verboseOnly);
    }
}