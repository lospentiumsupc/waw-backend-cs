namespace WAW.API.Shared.Domain.Service.Communication;

public class ErrorResponse {
  public string Message { get; }

  public ErrorResponse(string message) {
    Message = message;
  }
}
