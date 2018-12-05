using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.LookUps
{
    public class LookUpDataService : IFriendLookUpDataService, IProgrammingLanguageLookUpDataService, IMeetingLookUpDataService
    {
        private Func<FriendOrganizerDbContext> _context;

        public LookUpDataService(Func<FriendOrganizerDbContext> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LookUpItem>> GetFriendLookUpAsync()
        {
            using (var ctx = _context())
            {
                return await ctx.Friends.AsNoTracking()
                    .Select(f => new LookUpItem
                    { Id = f.Id, DisplayMember = f.FirstName + " " + f.LastName }
                    )
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<LookUpItem>> GetProgrammingLanguageLookUpAsync()
        {
            using (var ctx = _context())
            {
                return await ctx.ProgrammingLanguages.AsNoTracking()
                    .Select(f => new LookUpItem
                    { Id = f.Id, DisplayMember = f.Name }
                    )
                    .ToListAsync();
            }
        }

        public async Task<List<LookUpItem>> GetMeetingLookUpAsync()
        {
            using (var ctx = _context())
            {
                var items = await ctx.Meetings.AsNoTracking().Select(m=> 
                new LookUpItem
                {
                    Id = m.Id,
                    DisplayMember = m.Title
                }).ToListAsync();
                return items;
            }
        }

    }
}
