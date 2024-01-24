using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryAPI.Models;

public class ServicePriceList
{
    [Key]
    public int ServiceId { get; set; }
    public string ServiceLevel { get; set; }
    [Required]
    public string ServiceName { get; set; }
    [Column(TypeName = "decimal(12,2)")]
    public decimal ServicePrice { get; set; }
    public int FacilityId { get; set; }
    [ForeignKey(nameof(FacilityId))]
    public MedicalFacility MedicalFacility { get; set; }
}