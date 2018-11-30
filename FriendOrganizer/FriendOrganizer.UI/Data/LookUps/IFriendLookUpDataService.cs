using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.LookUps
{
    public interface IFriendLookUpDataService
    {
        Task<List<LookUpItem>> GetFriendLookUpAsync();
    }
}