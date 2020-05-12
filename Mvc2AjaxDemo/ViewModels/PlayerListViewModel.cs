using System;
using System.Collections.Generic;

namespace Mvc2AjaxDemo.ViewModels
{
    public class PlayerListViewModel
    {

        public string Team { get; set; }

        public List<PlayerViewModel> Players { get; set; } = new List<PlayerViewModel>();

        public class PlayerViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int JerseyNumber { get; set; }
            public string Position { get; set; }
            public string ImageUrl { get; set; }

            public int Goals { get; set; }
            public int Assists { get; set; }
        }

        public PlayerViewModel CurrentPlayer { get; set; }
    }

}