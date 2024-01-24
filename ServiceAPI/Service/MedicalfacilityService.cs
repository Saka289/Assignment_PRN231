using AutoMapper;
using RepositoryAPI.Models;
using RepositoryAPI.Models.Dto;
using RepositoryAPI.Repository;
using RepositoryAPI.Repository.IRepository;
using ServiceAPI.Service.IService;

namespace ServiceAPI.Service;

public class MedicalfacilityService : IMedicalfacilityService
{
    private readonly IMedicalfacilityRepository _medicalfacilityRepository;
    private readonly IMapper _mapper;

    public MedicalfacilityService(IMapper mapper, IMedicalfacilityRepository medicalfacilityRepository)
    {
        _mapper = mapper;
        _medicalfacilityRepository = medicalfacilityRepository;
    }

    public List<MedicalFacilityDto> GetAll()
    {
        try
        {
            var result = _mapper.Map<List<MedicalFacilityDto>>(_medicalfacilityRepository.GetAll());
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<MedicalFacilityDto> SearchByName(string name)
    {
        try
        {
            var result = _mapper.Map<List<MedicalFacilityDto>>(_medicalfacilityRepository.SearchByName(name));
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public MedicalFacilityDto GetById(int id)
    {
        try
        {
            var result = _mapper.Map<MedicalFacilityDto>(_medicalfacilityRepository.GetById(id));
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool Create(MedicalFacilityDto medicalFacilityDto)
    {
        try
        {
            MedicalFacility model = _mapper.Map<MedicalFacility>(medicalFacilityDto);
            _medicalfacilityRepository.Create(model);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool Update(MedicalFacilityDto medicalFacilityDto)
    {
        try
        {
            var result = _medicalfacilityRepository.GetById(medicalFacilityDto.FacilityId);
            if (result != null)
            {
                MedicalFacility model = _mapper.Map<MedicalFacility>(medicalFacilityDto);
                _medicalfacilityRepository.Update(model);
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

        return false;
    }

    public bool Delete(int id)
    {
        try
        {
            var result = _medicalfacilityRepository.GetById(id);
            if (result != null)
            {
                _medicalfacilityRepository.Delete(id);
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

        return false;
    }
}