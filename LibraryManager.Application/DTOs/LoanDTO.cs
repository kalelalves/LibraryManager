using System;

namespace LibraryManager.Application.DTOs
{
    public class LoanDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class CreateLoanDTO
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class ReturnLoanDTO
    {
        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
    }
} 