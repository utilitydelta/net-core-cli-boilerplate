using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UtilityDelta.Domain.Dto;
using UtilityDelta.Domain.Interface;

namespace UtilityDelta.Domain.Test
{
    [TestClass]
    public class TestManageCalculation
    {
        [TestMethod]
        public void TestMethodNoValuesToAdd()
        {
            var userCommunication = new Mock<IUserCommunication>();
            var calculateEngine = new Mock<ICalculateEngine>();
            var service = new ManageCalculation(userCommunication.Object, calculateEngine.Object);
            var result = service.PerformOperation(new DtoCalculationInput());
            Assert.IsFalse(result);
            calculateEngine.Verify(x => x.OnePlusAnother(It.IsAny<double>(), It.IsAny<double>()), Times.Never);
            calculateEngine.Verify(x => x.OneMinusAnother(It.IsAny<double>(), It.IsAny<double>()), Times.Never);
            userCommunication.Verify(x => x.WriteErrorLine(It.IsAny<string>(), true), Times.Once);
        }

        [TestMethod]
        public void TestMethodSomeValues()
        {
            var userCommunication = new Mock<IUserCommunication>();
            var calculateEngine = new Mock<ICalculateEngine>();
            calculateEngine.Setup(x => x.OnePlusAnother(44, 443.334)).Returns(new DtoCalculationResult
            {
                Result = 487.334
            });
            calculateEngine.Setup(x => x.OnePlusAnother(487.334, 32.44)).Returns(new DtoCalculationResult
            {
                Result = 519.774
            });
            var service = new ManageCalculation(userCommunication.Object, calculateEngine.Object);
            var result = service.PerformOperation(new DtoCalculationInput
            {
                InitialValue = 44,
                Operation = DtoCalculationInput.OperationType.Add,
                ValuesToProcess = new List<double>
                {
                    443.334,
                    32.44
                }
            });
            Assert.IsTrue(result);
            calculateEngine.Verify(x => x.OnePlusAnother(44, 443.334), Times.Once);
            calculateEngine.Verify(x => x.OnePlusAnother(487.334, 32.44), Times.Once);
            calculateEngine.Verify(x => x.OneMinusAnother(It.IsAny<double>(), It.IsAny<double>()), Times.Never);
            userCommunication.Verify(x => x.WriteErrorLine(It.IsAny<string>(), It.IsAny<bool>()), Times.Never);
            userCommunication.Verify(x => x.WriteOutputLine(It.IsAny<string>(), false), Times.Once);
        }
    }
}