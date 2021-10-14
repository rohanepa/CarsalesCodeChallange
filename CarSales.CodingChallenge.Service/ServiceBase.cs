using CarSales.CodingChallenge.Infrastructure.Response;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using AppValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace CarSales.CodingChallenge.Service
{
    public abstract class ServiceBase
    {
        protected IResponse GenerateErrorResponse(ValidationResult validationResult)
        {
            List<AppValidationResult> applicationValidationResults = new List<AppValidationResult>();

            validationResult.Errors.ToList().ForEach(error =>
            {
                var validationError = new AppValidationResult(error.ErrorMessage, new[] { error.PropertyName });
                applicationValidationResults.Add(validationError);
            });

            return new Response(applicationValidationResults);
        }

        protected IResponse GenerateErrorResponse(params string[] errors)
        {
            List<AppValidationResult> applicationValidationResults = new List<AppValidationResult>();

            errors.ToList().ForEach(error =>
            {
                applicationValidationResults.Add(new AppValidationResult(error));
            });

            return new Response(applicationValidationResults);
        }
    }
}
