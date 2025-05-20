using FluentValidation;
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(100).WithMessage("Author must not exceed 100 characters");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN is required")
                .Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
                .WithMessage("Invalid ISBN format");

            RuleFor(x => x.Publication.Year)
                .NotEmpty().WithMessage("Publication year is required")
                .InclusiveBetween(1000, DateTime.Now.Year)
                .WithMessage("Publication year must be between 1000 and current year");
        }
    }
} 