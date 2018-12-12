using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : GenericRepository<Friend,FriendOrganizerDbContext>, IFriendRepository
    {
        
        public FriendRepository(FriendOrganizerDbContext context):base(context)
        {
        }

        public override async Task<Friend> GetByIdAsync(int? friendId)
        {
            return await _context.Friends.Include(f=>f.PhoneNumbers).SingleAsync(f=>f.Id == friendId);
        }

        public async Task<bool> HasMeetingsAsync(int friendId)
        {
            return await _context.Meetings.AsNoTracking().Include(mbox => mbox.Friends).AnyAsync(m => m.Friends.Any(f => f.Id == friendId));
        }

        public void RemovePhoneNumber(FriendPhoneNumber model)
        {
            _context.FriendPhoneNumbers.Remove(model);
        }
    }
}
