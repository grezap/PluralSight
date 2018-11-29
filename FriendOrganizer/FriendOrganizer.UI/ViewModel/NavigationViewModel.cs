using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookUpDataService _friendLookUpDataService;
        private IEventAggregator _eventAggregator;
        private NavigationItemViewModel _selectedFriend;

        public NavigationViewModel(IFriendLookUpDataService friendLookUpDataService, IEventAggregator eventAggregator)
        {
            _friendLookUpDataService = friendLookUpDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; }


        public NavigationItemViewModel SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend!= null)
                {
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(_selectedFriend.Id);
                }
            }
        }


        public async Task LoadAsync()
        {
            var lookup = await _friendLookUpDataService.GetFriendLookUpAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id,item.DisplayMember));
            }
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var lookUpItem = Friends.Single(l => l.Id == obj.Id);
            lookUpItem.DisplayMember = obj.DisplayMember;
        }
    }
}
