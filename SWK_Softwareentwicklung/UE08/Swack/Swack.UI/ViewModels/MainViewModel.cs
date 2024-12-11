using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swack.Logic.Models;

namespace Swack.UI.ViewModels
{
    public class MainViewModel
    {
        public IEnumerable<Channel> Channels { get; set; }

        // ctor TAB
        public MainViewModel()
        {
            Channels = new List<Channel>()
            {
                new("#swk"),
                new("#fun"),
                new("#kurztest"),
            };
        }

    }
}
