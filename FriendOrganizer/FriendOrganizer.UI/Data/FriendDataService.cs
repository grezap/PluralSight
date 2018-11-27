using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _context;

        public FriendDataService(Func<FriendOrganizerDbContext> context)
        {
            _context = context;
        }

        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using (var ctx = _context())
            {
                return await ctx.Friends.AsNoTracking().SingleAsync(f=>f.Id == friendId);
            }

        }
    }
}
