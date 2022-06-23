using Microsoft.AspNetCore.Mvc;

public abstract class BaseController : ControllerBase
{
    protected IActionResult ReturnActionResult(ResultComand result) =>
        result.IsValid ? Ok(result) : BadRequest(result);
}