using CarSales.CodingChallenge.Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarSales.CodingChallenge.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private const string UnspecifiedValidationMemberName = "Unspecified";

        protected IActionResult ActionResult<T>(T result) where T : class
        {
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }

        protected IActionResult ActionResult<T>(IResponse response) where T : class
        {
            return response.Success ? Ok(response.Result<T>()) : (ActionResult)CreateBadRequestResult(response);
        }

        private IActionResult CreateBadRequestResult(IResponse response)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var result in response.ValidationResults)
            {
                if (!result.MemberNames.Any())
                {
                    AddValidationResultToModalState(modelStateDictionary, UnspecifiedValidationMemberName, result);
                }
                else
                {
                    foreach (var memberName in result.MemberNames)
                    {
                        AddValidationResultToModalState(modelStateDictionary, memberName, result);
                    }
                }
            }
            return BadRequest(modelStateDictionary);
        }

        private static void AddValidationResultToModalState(ModelStateDictionary modelStateDictionary, string memberName, ValidationResult result)
        {
            if (!modelStateDictionary.ContainsKey(memberName))
            {
                modelStateDictionary.AddModelError(memberName, result.ErrorMessage);
            }
            else
            {
                modelStateDictionary[memberName].Errors.Add(result.ErrorMessage);
            }
        }
    }
}
