using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Swack.Logic.Models
{
    public class ChannelViewModel(Channel channel)
    {
        public Channel Channel { get; } = channel;

        public ObservableCollection<Message> Messages { get; set; }

        public int UnreadMessages { get; set; }
    }
}
