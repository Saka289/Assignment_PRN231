using RepositoryAPI.Data;
using RepositoryAPI.Models;
using RepositoryAPI.Repository.IRepository;

namespace RepositoryAPI.Repository;

public class MedicalfacilityRepository : IMedicalfacilityRepository
{
    private readonly AppDbContext _context;

    public MedicalfacilityRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<MedicalFacility> GetAll()
    {
        return _context.MedicalFacilities.ToList();
    }

    public List<MedicalFacility> SearchByName(string name)
    {
        return _context.MedicalFacilities.Where(m => m.FacilityName == name).ToList();
    }

    public MedicalFacility GetById(int id)
    {
        var obj = _context.MedicalFacilities.FirstOrDefault(m => m.FacilityId == id);
        if (obj != null)
        {
            return obj;
        }

        return null;
    }

    public void Create(MedicalFacility medicalFacility)
    {
        _context.MedicalFacilities.Add(medicalFacility);
        _context.SaveChanges();
    }

    public void Update(MedicalFacility medicalFacility)
    {
        var obj = _context.MedicalFacilities.FirstOrDefault(m => m.FacilityId == medicalFacility.FacilityId);
        if (obj != null)
        {
            obj.FacilityName = medicalFacility.FacilityName;
            obj.NoDoctor = medicalFacility.NoDoctor;
            obj.PrivateFacility = medicalFacility.PrivateFacility;
            obj.Level = medicalFacility.Level;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var obj = _context.MedicalFacilities.FirstOrDefault(m => m.FacilityId == id);
        if (obj != null)
        {
            _context.MedicalFacilities.Remove(obj);
            _context.SaveChanges();
        }
    }
}