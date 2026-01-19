namespace Api.Common
{
	public static class StatusHandler
	{
		public static IActionResult HandleResult<T>(Result<T> result)
		{
			if (result.IsSuccess)
			{
				return new OkObjectResult(result.Data!);
			}
			else
			{
				return new BadRequestObjectResult(new { error = result.ErrorMessage });
			}
		}
	}
}