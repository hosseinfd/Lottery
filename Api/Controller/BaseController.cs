using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class BaseController : ControllerBase 
{
    public BaseController()
    {
        
    }
    private IMediator _mediator = null!;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

}