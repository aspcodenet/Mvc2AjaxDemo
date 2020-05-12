using System;
using System.Collections.Generic;
using Mvc2AjaxDemo.Models;

namespace Mvc2AjaxDemo.Services
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player Get(Guid id);

    }
}