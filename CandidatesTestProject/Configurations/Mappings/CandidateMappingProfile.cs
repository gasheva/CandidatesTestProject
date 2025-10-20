using AutoMapper;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Models;

namespace CandidatesTestProject.Configurations.Mappings;

public class CandidateMappingProfile : Profile
{
    public CandidateMappingProfile()
    {
        CreateMap<Candidate, CandidateVm>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.CandidateData.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.CandidateData.LastName))
            .ForCtorParam("MiddleName", opt => opt.MapFrom(src => src.CandidateData.MiddleName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.CandidateData.Email))
            .ForCtorParam("Phone", opt => opt.MapFrom(src => src.CandidateData.Phone))
            .ForCtorParam("Country", opt => opt.MapFrom(src => src.CandidateData.Country))
            .ForCtorParam("DateOfBirth", opt => opt.MapFrom(src => src.CandidateData.DateOfBirth))
            .ForCtorParam("SocialNetworks", opt => opt.MapFrom(src => src.CandidateData.SocialNetworks))
            .ForCtorParam("LastUpdatedAt", opt => opt.MapFrom(src => src.LastUpdatedAt))
            .ForCtorParam("WorkSchedule", opt => opt.MapFrom(src => src.WorkSchedule))
            .ForCtorParam("CreatedByUserId", opt => opt.MapFrom(src => src.CreatedByUserId));

        CreateMap<Candidate, CandidateListVm>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.CandidateData.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.CandidateData.LastName))
            .ForCtorParam("MiddleName", opt => opt.MapFrom(src => src.CandidateData.MiddleName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.CandidateData.Email))
            .ForCtorParam("LastUpdatedAt", opt => opt.MapFrom(src => src.LastUpdatedAt))
            .ForCtorParam("WorkSchedule", opt => opt.MapFrom(src => src.WorkSchedule));

        CreateMap<SocialNetwork, SocialNetworkVm>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Username", opt => opt.MapFrom(src => src.Username))
            .ForCtorParam("Type", opt => opt.MapFrom(src => src.Type))
            .ForCtorParam("AddedAt", opt => opt.MapFrom(src => src.AddedAt));

        CreateMap<List<CandidateListVm>, ListOfCandidates>()
            .ForCtorParam("Candidates", opt => opt.MapFrom(src => src));

        CreateMap<CreateCandidateDto, Candidate>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.CandidateDataId, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.LastUpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.WorkSchedule, opt => opt.MapFrom(src => src.WorkSchedule))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.CandidateData, opt => opt.MapFrom(src => new CandidateData
            {
                Id = Guid.NewGuid(),
                FirstName = src.FirstName,
                LastName = src.LastName,
                MiddleName = src.MiddleName,
                Email = src.Email,
                Phone = src.Phone,
                Country = src.Country,
                DateOfBirth = src.DateOfBirth,
                SocialNetworks = src.SocialNetworks.Select(sn => new SocialNetwork
                {
                    Id = Guid.NewGuid(),
                    Username = sn.Username,
                    Type = sn.Type,
                    AddedAt = DateTime.UtcNow
                }).ToList()
            }))
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

        CreateMap<CreateSocialNetworkDto, SocialNetwork>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.AddedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.CandidateData, opt => opt.Ignore())
            .ForMember(dest => dest.CandidateDataId, opt => opt.Ignore());

        CreateMap<UpdateCandidateDto, Candidate>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CandidateDataId, opt => opt.Ignore())
            .ForMember(dest => dest.LastUpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.WorkSchedule, opt => opt.MapFrom(src => src.WorkSchedule))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.CandidateData, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

        CreateMap<UpdateCandidateDto, CandidateData>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.SocialNetworks, opt => opt.MapFrom(src => src.SocialNetworks))
            .ForMember(dest => dest.Candidate, opt => opt.Ignore())
            .ForMember(dest => dest.Employee, opt => opt.Ignore());
    }
}

