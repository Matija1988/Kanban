using Application.Abstractions.HATEOS;
using Common;

namespace Kanban.Services;

internal sealed class LinkService : ILinkService
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IHttpContextAccessor _contextAccessor;

    public LinkService(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
    {
        _linkGenerator = linkGenerator;
        _contextAccessor = httpContextAccessor;
    }

    public Link Generate(string endpointName, object? routeValues, string rel, string method)
    {
        return new Link(
            _linkGenerator.GetUriByName(_contextAccessor.HttpContext, endpointName, routeValues),
            rel, 
            method);
    }
}
