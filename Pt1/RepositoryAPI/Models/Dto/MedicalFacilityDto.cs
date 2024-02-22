using System.ComponentModel.DataAnnotations;

namespace RepositoryAPI.Models.Dto;

public class MedicalFacilityDto
{
    [Required]
    public int FacilityId { get; set; }
    [Required]
    public string FacilityName { get; set; }
    [Required]
    public string NoDoctor { get; set; }
    [Required]
    public string PrivateFacility { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Level must be bigger than 0!")]
    public int Level { get; set; }
}