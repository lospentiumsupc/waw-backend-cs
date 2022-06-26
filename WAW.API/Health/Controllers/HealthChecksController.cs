using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Health.Controllers;

[ApiController]
[Route("_health")]
[Produces(MediaTypeNames.Text.Plain)]
[SwaggerTag("Health checks for Google App Engine")]
public class HealthCheckController : ControllerBase {
  [HttpGet("readiness")]
  [ProducesResponseType(typeof(string), 200)]
  [SwaggerResponse(200, "The app is ready to start receiving requests", typeof(string))]
  public string ReadinessCheck() {
    return "pong";
  }

  [HttpGet("liveness")]
  [ProducesResponseType(typeof(string), 200)]
  [SwaggerResponse(200, "The app is healthy and can continue receiving requests", typeof(string))]
  public string LivenessCheck() {
    return "pong";
  }
}
