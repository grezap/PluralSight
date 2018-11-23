using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IFriendLookUpDataService _friendLookUpDataService;

        public NavigationViewModel(IFriendLookUpDataService friendLookUpDataService)
        {
            _friendLookUpDataService = friendLookUpDataService;
            Friends = new ObservableCollection<LookUpItem>();
        }

        public ObservableCollection<LookUpItem> Friends { get; }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookUpDataService.GetFriendLookUpAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(item);
            }
        }

    }
}
