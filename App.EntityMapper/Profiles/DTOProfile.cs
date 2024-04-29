using App.Domain.Operations;
using App.DTOs;
using AutoMapper;

namespace App.EntityMapper.Profiles;
public class DTOProfile : Profile
{
    public DTOProfile()
    {
        CreateMap<Operation, OperationDto>().ReverseMap();
    }
}