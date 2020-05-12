using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Mvc2AjaxDemo.Models;
using Mvc2AjaxDemo.Services;
using Mvc2AjaxDemo.ViewModels;

namespace Mvc2AjaxDemo.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IWebHostEnvironment _environment;

        public PlayerController(IPlayerRepository playerRepository, IWebHostEnvironment environment)
        {
            _playerRepository = playerRepository;
            _environment = environment;
        }

        public IActionResult Index(string id)
        {
            var viewModel = new PlayerListViewModel();
            viewModel.Players = _playerRepository.GetAll().Select(PlayerToPlayerViewModel).ToList();
            
            if(!string.IsNullOrEmpty(id))
            {
                viewModel.CurrentPlayer = viewModel.Players.FirstOrDefault(r => r.Id == Guid.Parse(id));
            }
            return View(viewModel);
        }

        public IActionResult JQueryJson()
        {
            var viewModel = new PlayerListViewModel();
            viewModel.Players = _playerRepository.GetAll().Select(PlayerToPlayerViewModel).ToList();
            return View(viewModel);
        }


        public IActionResult GetPlayerJson(Guid id)
        {
            var model = _playerRepository.GetAll().Where(r => r.Id == id).Select(PlayerToPlayerViewModel).SingleOrDefault();
            return Json(model);
        }



        public IActionResult GetPlayerHtml(Guid id)
        {
            var model = _playerRepository.GetAll().Where(r => r.Id == id).Select(PlayerToPlayerViewModel).SingleOrDefault();
            return View(model);
        }



        private PlayerListViewModel.PlayerViewModel PlayerToPlayerViewModel(Player arg)
        {
            return new PlayerListViewModel.PlayerViewModel
            {
                Id = arg.Id,
                JerseyNumber = arg.JerseyNumber,
                Name = arg.Name,
                Position = arg.Position,
                ImageUrl = Path.Combine(_environment.ContentRootPath, $"/images/{arg.Id}.jpg")
            };
        }


    }
}