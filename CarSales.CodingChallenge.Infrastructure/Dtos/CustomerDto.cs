using CarSales.CodingChallenge.Infrastructure.Enums;

namespace CarSales.CodingChallenge.Infrastructure.Dtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public VehicleType VehicleType { get; set; }
        public SpeakingLanguage SpeakingLanguage { get; set; }
    }
}
