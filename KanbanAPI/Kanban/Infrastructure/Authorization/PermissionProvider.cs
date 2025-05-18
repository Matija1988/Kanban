using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization;

internal class PermissionProvider
{
    public async Task<HashSet<string>> GetRolePremissions(AuthorizationHandlerContext authContext)
    {
        HashSet<string> permissionsSet = new HashSet<string>();

        if (authContext.User.IsInRole("user"))
        {
            permissionsSet.Add("tasks:access");
            permissionsSet.Add("tasks:allowEdit");
        }

        return permissionsSet;
    }
}
