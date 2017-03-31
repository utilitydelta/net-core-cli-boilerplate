using System.Collections.Generic;

namespace UtilityDelta.Domain.Dto
{
    public class DtoCalculationInput
    {
        public enum OperationType
        {
            Subtract,
            Add
        }

        public double InitialValue { get; set; }
        public OperationType Operation { get; set; }
        public IEnumerable<double> ValuesToProcess { get; set; }
    }
}