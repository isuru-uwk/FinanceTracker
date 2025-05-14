using AutoMapper;
using FinanceTracker.BLL.Services;
using FinanceTracker.DAL.Db.Entities;
using FinanceTracker.DAL.Repository.IRepository;
using FinanceTracker.Shared.Enums;
using FinanceTracker.Shared.Models.ApiModels;
using Moq;

namespace FinanceTracker.Tests.ServiceTests
{
    public class TransactionServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IGenericRepository<Transaction>> _mockGenericRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mockGenericRepo = new Mock<IGenericRepository<Transaction>>();
            _mockMapper = new Mock<IMapper>();

            // Set up IUnitOfWork to return our mocked generic repo
            _mockUow.Setup(u => u.Transactions).Returns(_mockGenericRepo.Object);

            _service = new TransactionService(_mockUow.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateTransactionAsync_ValidModel_ReturnsTransactionId()
        {
            var writeModel = new TransactionWriteModel { TransactionDate = DateTime.UtcNow,Amount = 200,
            CategoryId = 1,
            Description = "Foods",
            Type = TransactionType.Expense};
            var entity = new Transaction()
            {
                TransactionId = 1,
                Amount = 100.50m,
                TransactionDate = DateTimeOffset.UtcNow.AddDays(-1),
                Description = "Groceries",
                Type = TransactionType.Expense,
                Status = TransactionStatus.Completed,
                CreatedDate = DateTimeOffset.UtcNow.AddDays(-1),
                CategoryId = 2,
            };


            _mockMapper.Setup(m => m.Map<Transaction>(writeModel)).Returns(entity);
            _mockUow.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            var result = await _service.CreateTransactionAsync(writeModel);

            _mockGenericRepo.Verify(r => r.Add(entity), Times.Once);
            _mockUow.Verify(u => u.SaveChangesAsync(), Times.Once);
            Assert.Equal(1, result);
        }
    }
}
