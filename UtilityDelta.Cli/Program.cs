using UtilityDelta.Dependencies;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var scope = new Setup())
            {
                var verbs = scope.GetService<IVerbs>();
            }
        }
    }
}