using FinanceTracker.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Shared.Models.ApiModels
{
    public class TransactionWriteModel
    {
        public int TransactionId { get; init; }

        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public required decimal Amount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Transaction type is required")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public required int CategoryId { get; set; }
    }
}
