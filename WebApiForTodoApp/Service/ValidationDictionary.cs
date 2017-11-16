using System.Web.Http.ModelBinding;

namespace WebApiForTodoApp.Service
{
	public class ValidationDictionary : IValidationDictionary
	{
		private readonly ModelStateDictionary _modelState;

		public ValidationDictionary(ModelStateDictionary modelState)
		{
			_modelState = modelState;
		}

		public void AddError(string key, string errorMessage)
		{
			_modelState.AddModelError(key, errorMessage);
		}

		public bool IsValid => _modelState.IsValid;
	}
}