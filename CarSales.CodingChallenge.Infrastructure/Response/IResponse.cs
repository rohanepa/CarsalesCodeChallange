using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSales.CodingChallenge.Infrastructure.Response
{
    public interface IResponse
    {
        IList<ValidationResult> ValidationResults { get; set; }
        bool Success { get; }
        TResult Result<TResult>() where TResult : class;
        void SetResult<TResult>(TResult result) where TResult : class;
    }
}
