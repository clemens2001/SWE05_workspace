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

        public ObservableCollection<ChannelViewModel> Channels { get; private set; } = [];


        public ChannelViewModel? CurrentChannel { get; set; }
        public MainViewModel(IMessagingLogic messagingLogic)
        {
            this.messagingLogic = messagingLogic ?? throw new ArgumentNullException(nameof(messagingLogic));
            this.messagingLogic.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(Message message)
        {
            var channel = Channels.FirstOrDefault(ch => ch.Channel.Name == message.Channel.Name);

            channel?.Messages.Add(message);
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
