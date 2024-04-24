using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CatchAndLog
{
    public class DebugCallBack
    {
        private readonly ILogger<DebugCallBack> _logger;

        public DebugCallBack(ILogger<DebugCallBack> logger)
        {
            _logger = logger;
        }

        [Function("DebugCallBack")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation(requestBody);

            return new OkObjectResult(requestBody);
        }
    }
}
