using AutoMapper;
using TodoList.BLL.Models;
using TodoList.DAL.Entities;

namespace TodoList.BLL.MappingProfiles
{

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserVM>();
            CreateMap<UserVM, User>();

        }
    }

}
