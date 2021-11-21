namespace Enaza.DTO
{
	public class BaseErrorResponseDto
	{
		public BaseErrorResponseDto()
		{

		}
		public BaseErrorResponseDto(string errorMessage)
		{
			ErrorMessage = errorMessage;
		}

		public string ErrorMessage { get; set; }
	}
}