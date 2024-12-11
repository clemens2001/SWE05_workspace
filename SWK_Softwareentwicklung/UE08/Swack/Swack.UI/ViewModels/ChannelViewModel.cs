using Swack.Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swack.UI.ViewModels
{
    public class ChannelViewModel : INotifyPropertyChanged
    {
        private int unreadMessages;

        public Channel Channel { get; }

        public ObservableCollection<Message> Messages { get; } = [];

        public int UnreadMessages {
            get => unreadMessages;
            set {
                unreadMessages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UnreadMessages)));
            }

        }
        public ChannelViewModel(Channel channel)
        {
            this.Channel = channel;
            UnreadMessages = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
