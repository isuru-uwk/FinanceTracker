using FinanceTracker.Api.Controllers;
using FinanceTracker.BLL.Interfaces;
using FinanceTracker.Shared.Enums;
using FinanceTracker.Shared.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FinanceTracker.Tests.ApiTests
{
    public class TransactionControllerTests
    {
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly TransactionController _controller;

        public TransactionControllerTests()
        {
            _mockTransactionService = new Mock<ITransactionService>();
            _controller = new TransactionController(_mockTransactionService.Object);
        }

        [Fact]
        public async Task GetTransactions_ReturnsOkResult_WithListOfTransactions()
        {
            // Arrange
            var expectedTransactions = new List<TransactionReadModel>
        {
            new()
            {
                TransactionId = 1,
                Amount = 100.00m,
                TransactionDate = DateTimeOffset.UtcNow.AddDays(-1),
                Description = "Groceries",
                Type = TransactionType.Expense,
                CategoryId = 2,
            },
            new()
            {
                TransactionId = 2,
                Amount = 250.00m,
                TransactionDate = DateTimeOffset.UtcNow.AddDays(-2),
                Description = "Rent",
                Type = TransactionType.Expense,
                CategoryId = 3,
            }
        };

            _mockTransactionService
                .Setup(service => service.GetAllTransactionsAsync())
                .ReturnsAsync(expectedTransactions);

            // Act
            var result = await _controller.GetTransactions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedData = Assert.IsAssignableFrom<IReadOnlyCollection<TransactionReadModel>>(okResult.Value);
            Assert.Equal(2, returnedData.Count);
        }
    }
}
