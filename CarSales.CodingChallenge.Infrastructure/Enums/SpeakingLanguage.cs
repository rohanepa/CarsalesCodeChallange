using System.ComponentModel;

namespace CarSales.CodingChallenge.Infrastructure.Enums
{
    public enum SpeakingLanguage
    {
        [Description("Any Language")]
        Any = 1,
        [Description("Greek")]
        Greek = 2,
        [Description("Non Greek")]
        NonGreek = 3
    }
}
