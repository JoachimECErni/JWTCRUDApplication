using AutoMapper;
using CRUDApplication.Domain.Contracts;
using CRUDApplication.Domain.Entities;

namespace CRUDApplication.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(record => record.Games, opt => opt.MapFrom(src => src.Games));
            CreateMap<CreateCompany, Company>();
            CreateMap<UpdateCompany, Company>();
            CreateMap<DeleteCompany, Company>();
            CreateMap<GetCompany, Company>();

            CreateMap<Game, GameDto>();
            CreateMap<CreateGame, Game>();
            CreateMap<UpdateGame, Game>();
            CreateMap<DeleteGame, Game>();
            CreateMap<GetGame, Game>();

            CreateMap<UserDto, User>();

            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<CreateRole, Role>();
            CreateMap<UpdateRole, Role>();

            CreateMap<UserRoleDto, UserRole>().ReverseMap();
            CreateMap<UpdateUserRole, UserRole>();
            CreateMap<CreateUserRole, UserRole>();


        }
    }
}
