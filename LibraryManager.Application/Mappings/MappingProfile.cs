using AutoMapper;
using LibraryManager.Application.DTOs;
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();

            CreateMap<Loan, LoanDTO>();
            CreateMap<CreateLoanDTO, Loan>();
            CreateMap<ReturnLoanDTO, Loan>();
        }
    }
} 