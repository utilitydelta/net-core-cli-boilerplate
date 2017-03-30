using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Domain
{
    public class SupportedVerbs : IVerbs
    {
        public SupportedVerbs(IVerbAdd add, IVerbSubtract subtract)
        {
            Add = add;
            Subtract = subtract;
        }

        public IVerbAdd Add { get; }
        public IVerbSubtract Subtract { get; }
    }
}