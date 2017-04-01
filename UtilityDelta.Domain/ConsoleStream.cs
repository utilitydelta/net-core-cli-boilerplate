using System;
using System.IO;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Domain
{
    /// <summary>
    ///     We want to maintain control of what can write to the command line output.
    ///     So we override the default streams to stop other code components writing
    ///     unwanted stuff to the console output.
    /// </summary>
    public class ConsoleStream : IConsoleStream, IDisposable
    {
        private readonly TextWriter m_error;
        private readonly TextReader m_input;
        private readonly TextWriter m_output;
        private readonly StreamWriter m_streamThatGoesNoWhere = new StreamWriter(new MemoryStream());

        public ConsoleStream()
        {
            m_input = Console.In;
            m_output = Console.Out;
            m_error = Console.Error;

            //Make sure that any calls to Console.WriteLine, etc. do not go to our console.
            //Only write to console output using this class - WriteError() and WriteOutput()
            Console.SetOut(m_streamThatGoesNoWhere);
            Console.SetError(m_streamThatGoesNoWhere);
        }

        public string Read() => m_input.ReadLine();

        public void WriteError(string value) => m_error.WriteLine(value);

        public void WriteOutput(string value) => m_output.WriteLine(value);

        public void Dispose()
        {
            m_streamThatGoesNoWhere.Dispose();
        }
    }
}