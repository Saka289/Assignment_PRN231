namespace RepositoryAPI.Models.Dto;

public class ServicePriceListDto
{
    public int ServiceId { get; set; }
    public string ServiceLevel { get; set; }
    public string ServiceName { get; set; }
    public decimal ServicePrice { get; set; }
    public int FacilityId { get; set; }
}