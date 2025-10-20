using AutoMapper;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Models;

namespace CandidatesTestProject.Configurations.Mappings;

public class VerificationMappingProfile : Profile
{
    public VerificationMappingProfile()
    {
        CreateMap<VerificationRequestDto, Verification>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.PerformedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.Date, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.SearchFirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.SearchLastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PerformedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Events, opt => opt.Ignore());

        CreateMap<Candidate, VerificationEventVm>()
            .ForCtorParam("EntityType", opt => opt.MapFrom(_ => EntityType.Candidate))
            .ForCtorParam("FoundEntityId", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FullName", opt => opt.MapFrom(src => 
                $"{src.CandidateData.FirstName} {src.CandidateData.LastName} {src.CandidateData.MiddleName}".Trim()))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.CandidateData.Email));

        CreateMap<Employee, VerificationEventVm>()
            .ForCtorParam("EntityType", opt => opt.MapFrom(_ => EntityType.Employee))
            .ForCtorParam("FoundEntityId", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FullName", opt => opt.MapFrom(src => 
                $"{src.CandidateData.FirstName} {src.CandidateData.LastName} {src.CandidateData.MiddleName}".Trim()))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.CandidateData.Email));
    }
}

