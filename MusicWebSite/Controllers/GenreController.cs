using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Interfaces;
using MusicWebSite.Models;
using MusicWebSite.ViewModels.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Controllers
{
    public class GenreController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;

        public GenreController(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        public IActionResult Genres(string filter = null)
        {
            ListGenresViewModel model = new ListGenresViewModel();
            model.genres = _mapper.Map<List<GenreModel>>(_genreService.GetAllGenres());
            return View(model);
        }

        public IActionResult View(int id)
        {
            ViewGenreViewModel model = new ViewGenreViewModel();
            model.genre = _mapper.Map<GenreModel>(_genreService.GetGenre(id));
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGenreViewModel model = new CreateGenreViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateGenreViewModel model)
        {
            Boolean success = _genreService.AddGenre(_mapper.Map<MusicCore.Genre>(model.genre));
            return RedirectToAction("Genres");
        }
    }
}