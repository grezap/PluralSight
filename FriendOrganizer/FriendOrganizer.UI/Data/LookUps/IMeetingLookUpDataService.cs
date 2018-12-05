using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.LookUps
{
    public interface IMeetingLookUpDataService
    {
        Task<List<LookUpItem>> GetMeetingLookUpAsync();
    }
}
