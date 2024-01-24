using RepositoryAPI.Models;
using RepositoryAPI.Models.Dto;

namespace ServiceAPI.Service.IService;

public interface IMedicalfacilityService
{
    public List<MedicalFacilityDto> GetAll();

    public List<MedicalFacilityDto> SearchByName(string name);

    public MedicalFacilityDto GetById(int id);

    public bool Create(MedicalFacilityDto medicalFacilityDto);

    public bool Update(MedicalFacilityDto medicalFacilityDto);

    public bool Delete(int id);
}