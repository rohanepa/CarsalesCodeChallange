using System.ComponentModel;

namespace CarSales.CodingChallenge.Infrastructure.Enums
{
    public enum VehicleType
    {
        [Description("Any Vehicle")]
        Any = 1,
        [Description("Family Car")]
        FamilyCar = 2,
        [Description("Sports Car")]
        SportsCar = 3,
        [Description("Tradie Vehicle")]
        Tradie = 4
    }
}
