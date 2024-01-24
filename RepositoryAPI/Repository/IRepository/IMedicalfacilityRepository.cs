using RepositoryAPI.Models;

namespace RepositoryAPI.Repository.IRepository;

public interface IMedicalfacilityRepository
{
    public List<MedicalFacility> GetAll();

    public List<MedicalFacility> SearchByName(string name);

    public MedicalFacility GetById(int id);

    public void Create(MedicalFacility medicalFacility);

    public void Update(MedicalFacility medicalFacility);

    public void Delete(int id);
}