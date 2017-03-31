using UtilityDelta.Domain.Dto;

namespace UtilityDelta.Domain.Interface
{
    public interface ICalculateEngine
    {
        DtoCalculationResult OneMinusAnother(double one, double another);
        DtoCalculationResult OnePlusAnother(double one, double another);
    }
}