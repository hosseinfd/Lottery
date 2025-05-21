using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller.BaseControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}