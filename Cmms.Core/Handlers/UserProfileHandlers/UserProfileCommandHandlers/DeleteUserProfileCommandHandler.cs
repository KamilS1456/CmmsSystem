using Cmms.Core.Commands.UserProfileCommands;
using Cmms.DataAccess.EntitieDbCOntext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.UserProfileHandlers.UserProfileCommandHandlers
{
    class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public DeleteUserProfileCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _cmmsDbContext.UserProfileS.FirstOrDefaultAsync(f => f.UserProfileId == request.UserProfileId);
            if (userProfile is null) {
                return;
            }
            _cmmsDbContext.UserProfileS.Remove(userProfile);
            await _cmmsDbContext.SaveChangesAsync();
        }
    }
}
