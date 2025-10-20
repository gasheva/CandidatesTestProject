using AutoMapper;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Models;

namespace CandidatesTestProject.Configurations.Mappings;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeVm>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.CandidateData.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.CandidateData.LastName))
            .ForCtorParam("MiddleName", opt => opt.MapFrom(src => src.CandidateData.MiddleName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.CandidateData.Email))
            .ForCtorParam("Phone", opt => opt.MapFrom(src => src.CandidateData.Phone))
            .ForCtorParam("Country", opt => opt.MapFrom(src => src.CandidateData.Country))
            .ForCtorParam("DateOfBirth", opt => opt.MapFrom(src => src.CandidateData.DateOfBirth))
            .ForCtorParam("SocialNetworks", opt => opt.MapFrom(src => src.CandidateData.SocialNetworks))
            .ForCtorParam("HireDate", opt => opt.MapFrom(src => src.HireDate));
    }
}

