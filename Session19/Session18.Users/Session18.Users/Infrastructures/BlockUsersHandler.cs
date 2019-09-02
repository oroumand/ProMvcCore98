using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Session18.Users.Infrastructures
{
    public class BlockUsersHandler : AuthorizationHandler<BlockUsersRequirement>
    {
        protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        BlockUsersRequirement requirement)
        {

            if (context.User.Identity != null && context.User.Identity.Name != null
                && !requirement.BlockedUsers
                    .Any(user => user.Equals(context.User.Identity.Name, StringComparison.OrdinalIgnoreCase)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
