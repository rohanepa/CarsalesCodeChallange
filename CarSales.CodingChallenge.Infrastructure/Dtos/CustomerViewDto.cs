using CarSales.CodingChallenge.Infrastructure.Extensions;

namespace CarSales.CodingChallenge.Infrastructure.Dtos
{
    public class CustomerViewDto : CustomerDto
    {
        public string Id { get; set; }
        public string SalesPersonName { get; set; }
        public string VehicleTypeDescription => VehicleType.GetDescription();
        public string SpeakingLanguageDescription => SpeakingLanguage.GetDescription();
    }
}
