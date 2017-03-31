using System;
using System.Globalization;
using CommandLine;
using UtilityDelta.Cli.Verbs;
using UtilityDelta.Dependencies;

namespace UtilityDelta.Cli
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            using (var scope = new Setup())
            {
                var parser = new Parser(with =>
                {
                    with.ParsingCulture = CultureInfo.CurrentCulture;
                    with.EnableDashDash = true;
                    with.HelpWriter = Console.Out;
                });

                var isError = false;

                parser.ParseArguments<Add, Subtract>(args)
                    .WithNotParsed(options => isError = true)
                    .WithParsed(options =>
                    {
                        var baseObj = (Base) options;
                        isError = !baseObj.Process(scope);
                    });

                if (isError)
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}