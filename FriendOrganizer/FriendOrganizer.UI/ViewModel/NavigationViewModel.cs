using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.LookUps;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookUpDataService _friendLookUpDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IFriendLookUpDataService friendLookUpDataService, IEventAggregator eventAggregator)
        {
            _friendLookUpDataService = friendLookUpDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
            _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Subscribe(AfterFriendDeleted);
        }


        public ObservableCollection<NavigationItemViewModel> Friends { get; }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookUpDataService.GetFriendLookUpAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id,item.DisplayMember, _eventAggregator));
            }
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var lookUpItem = Friends.SingleOrDefault(l => l.Id == obj.Id);
            if (lookUpItem == null)
            {
                Friends.Add(new NavigationItemViewModel(obj.Id,obj.DisplayMember,_eventAggregator));
            }
            else
            {
                lookUpItem.DisplayMember = obj.DisplayMember;
            }
        }


        private void AfterFriendDeleted(int friendId)
        {
            var friend = Friends.SingleOrDefault(f => f.Id == friendId);
            if (friend!= null)
            {
                Friends.Remove(friend);
            }
        }
    }
}
