//using FinanceTracker.BLL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FinanceTracker.Tests.ServiceTests
//{
//    public class TransactionServiceTests
//    {
//        private readonly Mock<ITransactionRepository> _transactionRepoMock;
//        private readonly ITransactionService _service;

//        public TransactionServiceTests()
//        {
//            _transactionRepoMock = new Mock<ITransactionRepository>();
//            _service = new TransactionService(_transactionRepoMock.Object);
//        }

//        [Fact]
//        public async Task UpdateTransactionAsync_ReturnsFalse_WhenTransactionNotFound()
//        {
//            // Arrange
//            var writeModel = new TransactionWriteModel { TransactionId = 999, ... };
//            _transactionRepoMock.Setup(r => r.GetAsync(It.IsAny<Expression<Func<Transaction, bool>>>()))
//                                .ReturnsAsync((Transaction)null);

//            // Act
//            var result = await _service.UpdateTransactionAsync(writeModel);

//            // Assert
//            Assert.False(result);
//        }
//    }
//}
