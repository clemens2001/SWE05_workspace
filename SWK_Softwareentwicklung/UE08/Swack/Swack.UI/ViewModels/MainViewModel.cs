using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swack.Logic;
using Swack.Logic.Models;

namespace Swack.UI.ViewModels
{
    public class MainViewModel
    {
        private readonly IMessagingLogic messagingLogic;

        public ObservableCollection<ChannelViewModel> Channels { get; private set; } = [];

        public ChannelViewModel? CurrentChannel { get; set; }

        // ctor TAB
        public MainViewModel(IMessagingLogic messagingLogic)
        {
            this.messagingLogic = messagingLogic ?? throw new ArgumentNullException(nameof(messagingLogic));

        }

        public async Task InitializeAsync()
        {
            foreach(var channel in await messagingLogic.GetChannelsAsync()) {
                Channels.Add(new ChannelViewModel(channel));
            }
        }

    }
}
