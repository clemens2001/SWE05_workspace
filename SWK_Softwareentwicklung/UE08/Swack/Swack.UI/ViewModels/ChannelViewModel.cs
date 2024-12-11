using Swack.Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swack.UI.ViewModels
{
    public class ChannelViewModel
    {
        public Channel Channel { get; }

        public ObservableCollection<Message> Messages { get; } = [];

        public int UnreadMessages { get; set; }
        public ChannelViewModel(Channel channel)
        {
            this.Channel = channel;
            UnreadMessages = 0;
        }
    }
}
