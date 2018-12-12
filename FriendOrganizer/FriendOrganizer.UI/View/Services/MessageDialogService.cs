using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FriendOrganizer.UI.View.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            var res = MessageBox.Show(text, title, MessageBoxButton.OKCancel);
            return res == MessageBoxResult.OK ? MessageDialogResult.OK : MessageDialogResult.Cancel;
        }

        public void ShowInfoDialog(string text)
        {
            MessageBox.Show(text, "Info");
        }

    }

    public enum MessageDialogResult
    {
        OK,
        Cancel
    }
}
