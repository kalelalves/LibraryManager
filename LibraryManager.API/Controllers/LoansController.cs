using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManager.Application.UseCases.Loans;
using LibraryManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILogger<LoansController> _logger;
        private readonly GetLoanUseCase _getLoanUseCase;
        private readonly CreateLoanUseCase _createLoanUseCase;
        private readonly ReturnLoanUseCase _returnLoanUseCase;
        private readonly ListLoansUseCase _listLoansUseCase;
        private readonly GetUserLoansUseCase _getUserLoansUseCase;
        private readonly GetActiveLoansUseCase _getActiveLoansUseCase;

        public LoansController(
            ILogger<LoansController> logger,
            GetLoanUseCase getLoanUseCase,
            CreateLoanUseCase createLoanUseCase,
            ReturnLoanUseCase returnLoanUseCase,
            ListLoansUseCase listLoansUseCase,
            GetUserLoansUseCase getUserLoansUseCase,
            GetActiveLoansUseCase getActiveLoansUseCase)
        {
            _logger = logger;
            _getLoanUseCase = getLoanUseCase;
            _createLoanUseCase = createLoanUseCase;
            _returnLoanUseCase = returnLoanUseCase;
            _listLoansUseCase = listLoansUseCase;
            _getUserLoansUseCase = getUserLoansUseCase;
            _getActiveLoansUseCase = getActiveLoansUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAll()
        {
            try
            {
                var loans = await _listLoansUseCase.Execute();
                return Ok(loans);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all loans");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetById(int id)
        {
            try
            {
                var loan = await _getLoanUseCase.Execute(id);
                if (loan == null)
                    return NotFound();

                return Ok(loan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting loan with id {LoanId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetByUser(int userId)
        {
            try
            {
                var loans = await _getUserLoansUseCase.Execute(userId);
                return Ok(loans);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting loans for user {UserId}", userId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetActive()
        {
            try
            {
                var loans = await _getActiveLoansUseCase.Execute();
                return Ok(loans);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active loans");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> Create([FromBody] Loan loan)
        {
            try
            {
                var createdLoan = await _createLoanUseCase.Execute(loan);
                return CreatedAtAction(nameof(GetById), new { id = createdLoan.Id }, createdLoan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating loan");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> Return(int id)
        {
            try
            {
                await _returnLoanUseCase.Execute(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error returning loan with id {LoanId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
} 