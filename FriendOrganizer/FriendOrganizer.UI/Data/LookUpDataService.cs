using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class LookUpDataService : IFriendLookUpDataService
    {
        private Func<FriendOrganizerDbContext> _context;
        public LookUpDataService(Func<FriendOrganizerDbContext> context)
        {
            _context = context;
        }

        public async Task<List<LookUpItem>> GetFriendLookUpAsync()
        {
            using (var ctx = _context())
            {
                return await ctx.Friends.AsNoTracking().Select(f => new LookUpItem { Id = f.Id, DisplayMember = f.FirstName + " " + f.LastName }).ToListAsync();
            }
        }

    }
}
