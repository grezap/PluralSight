using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.LookUps
{
    public interface IProgrammingLanguageLookUpDataService
    {
        Task<IEnumerable<LookUpItem>> GetProgrammingLanguageLookUpAsync();
    }
}