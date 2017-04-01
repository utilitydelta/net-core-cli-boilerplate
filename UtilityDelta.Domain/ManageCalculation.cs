using System;
using System.Linq;
using UtilityDelta.Domain.Dto;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Domain
{
    public class ManageCalculation : IManageCalculation
    {
        private readonly ICalculateEngine m_calculateEngine;
        private readonly IUserCommunication m_userCommunication;

        public ManageCalculation(IUserCommunication userCommunication, ICalculateEngine calculateEngine)
        {
            m_calculateEngine = calculateEngine;
            m_userCommunication = userCommunication;
        }

        public bool PerformOperation(DtoCalculationInput input)
        {
            m_userCommunication.WriteOutputLine("Starting calculation process...", true);
            var value = input.InitialValue;

            if (input.ValuesToProcess == null || !input.ValuesToProcess.Any())
            {
                m_userCommunication.WriteErrorLine("No values to process!", true);
                return false;
            }

            foreach (var valueToProcess in input.ValuesToProcess)
            {
                switch (input.Operation)
                {
                    case DtoCalculationInput.OperationType.Subtract:
                        m_userCommunication.WriteOutputLine($"Subtracting {valueToProcess}", true);
                        value = m_calculateEngine.OneMinusAnother(value, valueToProcess).Result;
                        break;
                    case DtoCalculationInput.OperationType.Add:
                        m_userCommunication.WriteOutputLine($"Adding {valueToProcess}", true);
                        value = m_calculateEngine.OnePlusAnother(value, valueToProcess).Result;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            m_userCommunication.WriteOutputLine($"Result is: {value}", false);

            if (value < 0)
            {
                m_userCommunication.WriteErrorLine("Value is now less than zero!", false);
            }

            return !m_userCommunication.HasError;
        }
    }
}