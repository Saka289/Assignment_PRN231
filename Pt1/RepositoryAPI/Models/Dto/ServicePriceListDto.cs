using System.ComponentModel.DataAnnotations;

namespace RepositoryAPI.Models.Dto;

public class ServicePriceListDto
{
    [Required]
    public int ServiceId { get; set; }
    [Required]
    public string ServiceLevel { get; set; }
    [Required]
    public string ServiceName { get; set; }
    [Required]
    public decimal ServicePrice { get; set; }
    [Required]
    public int FacilityId { get; set; }
}