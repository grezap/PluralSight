using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataService;

        private Friend _friend;

        public FriendDetailViewModel(IFriendDataService friendDataService)
        {
            _dataService = friendDataService;
        }
        
        public Friend Friend
        {
            get { return _friend; }
            private set { _friend = value; OnPropertyChanged(); }
        }


        public async Task LoadAsync(int friendId)
        {
            Friend = await _dataService.GetByIdAsync(friendId);
        }


    }
}
