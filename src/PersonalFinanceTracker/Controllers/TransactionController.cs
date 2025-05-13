using FinanceTracker.BLL.Interfaces;
using FinanceTracker.Shared.Models.ApiModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace FinanceTracker.Api.Controllers
{
    [ApiController]
    [Route("/api/transactions")]
    [Produces("application/json")]
    public class TransactionController(ITransactionService transactionService) : ControllerBase
    {
        /// <summary>
        /// Gets all transactions
        /// </summary>
        /// <returns>A list of transactions</returns>
        /// <response code="200">Returns the list of transactions</response>
        /// <response code="500">If there was an internal server error</response>
        [EndpointSummary("Get Transactions")]
        [Description("OData endpoint that gets transactions")]
        [HttpGet(Name = nameof(GetTransactions))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IReadOnlyCollection<TransactionReadModel>>> GetTransactions()
        {
            var result = await transactionService.GetAllTransactionsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Gets a specific transaction by id
        /// </summary>
        /// <param name="transactionId">The transaction identifier</param>
        /// <returns>The requested transaction</returns>
        /// <response code="200">Returns the requested transaction</response>
        /// <response code="404">If the transaction was not found</response>
        /// <response code="500">If there was an internal server error</response>
        [EndpointSummary("Get Transaction")]
        [Description("Endpoint that get a transaction")]
        [HttpGet("{transactionId:int}", Name = nameof(GetTransaction))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TransactionReadModel>> GetTransaction(int transactionId)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var result = await transactionService.GetTransactionByIdAsync(transactionId);
                return result == null ? this.NotFound() : this.Ok(result);
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(nameof(TransactionWriteModel), ex.Message);
                return ValidationProblem(ModelState);
            }
        }

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        /// <param name="writeModel">The transaction data</param>
        /// <returns>The created transaction id</returns>
        /// <response code="201">Returns the id of the created transaction</response>
        /// <response code="400">If the model is invalid</response>
        /// <response code="500">If there was an internal server error</response>
        [EndpointSummary("Create Transaction")]
        [Description("Endpoint that creates a transaction")]
        [HttpPost(Name = nameof(CreateTransaction))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] TransactionWriteModel writeModel)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var transactionId = await transactionService.CreateTransactionAsync(writeModel);
                var location = new Uri($"{Request.GetDisplayUrl().TrimEnd('/')}/{transactionId}");

                return Created(location, new { Id = transactionId });
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(nameof(TransactionWriteModel), ex.Message);
                return ValidationProblem(ModelState);
            }
        }

        /// <summary>
        /// Updates an existing transaction
        /// </summary>
        /// <param name="transactionId">The transaction identifier</param>
        /// <param name="writeModel">The transaction data</param>
        /// <returns>No content</returns>
        /// <response code="204">If the update was successful</response>
        /// <response code="400">If the model is invalid</response>
        /// <response code="404">If the transaction was not found</response>
        /// <response code="500">If there was an internal server error</response>
        [EndpointSummary("Update Transaction")]
        [Description("Endpoint that updates a transaction")]
        [HttpPut("{transactionId:int}", Name = nameof(UpdateTransaction))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateTransaction([FromBody] TransactionWriteModel writeModel)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var transactionId = await transactionService.UpdateTransactionAsync(writeModel);
                var location = new Uri($"{Request.GetDisplayUrl().TrimEnd('/')}/{transactionId}");

                return Created(location, new { Id = transactionId });
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(nameof(TransactionWriteModel), ex.Message);
                return ValidationProblem(ModelState);
            }
        }
    }
}
