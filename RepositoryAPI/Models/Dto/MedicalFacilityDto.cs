namespace RepositoryAPI.Models.Dto;

public class MedicalFacilityDto
{
    public int FacilityId { get; set; }
    public string FacilityName { get; set; }
    public string NoDoctor { get; set; }
    public string PrivateFacility { get; set; }
    public int Level { get; set; }
}