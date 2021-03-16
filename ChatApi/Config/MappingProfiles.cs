using AutoMapper;
using ChatApi.Dtos;
using ChatApi.Models;

namespace ChatApi.Config
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Message, MessageDto>();
        }
    }
}