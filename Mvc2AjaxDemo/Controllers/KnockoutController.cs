using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mvc2AjaxDemo.Services;
using Mvc2AjaxDemo.ViewModels;

namespace Mvc2AjaxDemo.Controllers
{
    public class KnockoutController : Controller
    {
        private IPlayerRepository _playerRepository;
        private IWebHostEnvironment _environment;

        public KnockoutController(IPlayerRepository playerRepository, IWebHostEnvironment environment)
        {
            _playerRepository = playerRepository;
            _environment = environment;
        }

        // GET
        public IActionResult Index()
        {
            var model = _playerRepository.GetAll().Select(r => new PlayerListViewModel.PlayerViewModel
            {
                Id = r.Id,
                Assists = 40,
                Goals = 51,
                ImageUrl = Path.Combine(_environment.ContentRootPath, $"/images/{r.Id}.jpg"),
                JerseyNumber = r.JerseyNumber,
                Name = r.Name,
                Position = r.Position

            }).First();
            return View(model);
        }
    }
}