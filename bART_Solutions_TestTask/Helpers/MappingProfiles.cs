using AutoMapper;
using bART_Solutions_TestTask.DTO;
using bART_Solutions_TestTask.Entities;

namespace bART_Solutions_TestTask.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerDto, Customer>();
        CreateMap<AccountDto, Account>();
        CreateMap<IncidentDto, Customer>();
    }
    
}