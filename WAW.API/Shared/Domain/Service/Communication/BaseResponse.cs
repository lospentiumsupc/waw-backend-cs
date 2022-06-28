using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WAW.API.Shared.Domain.Service.Communication;

public abstract class BaseResponse<T> {
  private bool Success { get; set; }
  private string Message { get; set; }
  private T? Resource { get; set; }

  protected BaseResponse(string message) {
    Success = false;
    Message = message;
    Resource = default;
  }

  protected BaseResponse(T resource) {
    Success = true;
    Message = string.Empty;
    Resource = resource;
  }

  public IActionResult ToResponse(ControllerBase controller) {
    // ReSharper disable once InvertIf
    if (!Success || Resource is null) {
      var body = new ErrorResponse(Message);
      return controller.BadRequest(body);
    }

    return controller.Ok(Resource);
  }

  public IActionResult ToResponse<TResponse>(ControllerBase controller, IMapper mapper) {
    if (!Success || Resource is null) {
      return controller.BadRequest(Message);
    }

    var mapped = mapper.Map<T, TResponse>(Resource);
    return controller.Ok(mapped);
  }
}
