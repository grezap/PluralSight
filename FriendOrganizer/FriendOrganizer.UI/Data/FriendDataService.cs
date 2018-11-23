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

        public async Task<List<Friend>> GetAllAsync()
        {
            //yield return new Friend { FirstName = "Thomas", LastName = "Huber" };
            //yield return new Friend { FirstName = "Andreas", LastName = "Boehler" };
            //yield return new Friend { FirstName = "Julia", LastName = "Huber" };
            //yield return new Friend { FirstName = "Chrissi", LastName = "Egin" };

            using (var ctx = _context())
            {
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }

        }
    }
}
