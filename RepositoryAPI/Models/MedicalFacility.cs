using System.ComponentModel.DataAnnotations;

namespace RepositoryAPI.Models;

public class MedicalFacility
{
    [Key]
    public int FacilityId { get; set; }
    public string FacilityName { get; set; }
    public string NoDoctor { get; set; }
    public string PrivateFacility { get; set; }
    public int Level { get; set; }
    public IEnumerable<ServicePriceList> ServicePriceLists { get; set; }
}