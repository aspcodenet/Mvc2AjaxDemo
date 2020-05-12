using System;

namespace Mvc2AjaxDemo.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int JerseyNumber { get; set; }

        public string Position { get; set; }
    }
}