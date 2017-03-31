using UtilityDelta.Domain.Dto;

namespace UtilityDelta.Domain.Interface
{
    public interface IManageCalculation
    {
        bool PerformOperation(DtoCalculationInput input);
    }
}