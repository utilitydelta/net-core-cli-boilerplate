using UtilityDelta.Domain.Dto;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Domain
{
    /// <summary>
    ///     This class is to demonstrate where to place business logic in the application
    /// </summary>
    public class CalculateEngine : ICalculateEngine
    {
        public DtoCalculationResult OneMinusAnother(double one, double another)
        {
            var result = one - another;
            return new DtoCalculationResult
            {
                Result = result
            };
        }

        public DtoCalculationResult OnePlusAnother(double one, double another)
        {
            var result = one + another;
            return new DtoCalculationResult
            {
                Result = result
            };
        }
    }
}