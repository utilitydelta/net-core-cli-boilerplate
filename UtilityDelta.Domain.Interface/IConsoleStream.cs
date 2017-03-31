namespace UtilityDelta.Domain.Interface
{
    public interface IConsoleStream
    {
        string Read();
        void WriteError(string value);
        void WriteOutput(string value);
    }
}