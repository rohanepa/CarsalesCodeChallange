using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarSales.CodingChallenge.Infrastructure.Response
{
    public class Response : IResponse
    {
        public IList<ValidationResult> ValidationResults { get; set; }

        public bool Success => ValidationResults == null || !ValidationResults.Any();

        protected object ResponseResult { get; private set; }

        public Response()
        {
            ValidationResults = new List<ValidationResult>();
        }

        public Response(IList<ValidationResult> validationResults)
        {
            ValidationResults = validationResults;
        }

        public TResult Result<TResult>() where TResult : class
        {
            return ResponseResult as TResult;
        }

        public void SetResult<TResult>(TResult result) where TResult : class
        {
            ResponseResult = result;
        }

        public static Response Ok()
        {
            return new Response();
        }
    }
}
