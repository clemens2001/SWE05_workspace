using Swack.Logic;
using Swack.Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swack.UI.ViewModels
{
    public class MainViewModel
    {
        private readonly IMessagingLogic messagingLogic;
        private ChannelViewModel? currentChannel;

        public ObservableCollection<ChannelViewModel> Channels { get; private set; } = [];


        public ChannelViewModel? CurrentChannel {
            get => currentChannel;
            set {
                currentChannel = value;
                if (currentChannel is not null) {
                    currentChannel.UnreadMessages = 0;
                }
            }
        }

        public MainViewModel(IMessagingLogic messagingLogic)
        {
            this.messagingLogic = messagingLogic ?? throw new ArgumentNullException(nameof(messagingLogic));
            this.messagingLogic.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(Message message)
        {
            var channel = Channels.FirstOrDefault(ch => ch.Channel.Name == message.Channel.Name);

            channel?.Messages.Add(message);

            if(channel is not null && channel != CurrentChannel) {
                channel.UnreadMessages++;
            }
        }

        public async Task InitializeAsync() 
        {
            foreach(var channel in await messagingLogic.GetChannelsAsync())
            {
                Channels.Add(new ChannelViewModel(channel));
            }
        }
    }
}
