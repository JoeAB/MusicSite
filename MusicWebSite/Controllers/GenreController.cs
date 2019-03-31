using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Interfaces;
using MusicWebSite.Models;

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
            List<GenreViewModel> genreViewModels = _mapper.Map<List<GenreViewModel>>(_genreService.GetAllGenres());
            return View(genreViewModels);
        }

        public IActionResult View(int id)
        {
            GenreViewModel genre = _mapper.Map<GenreViewModel>(_genreService.GetGenre(id));
            return View(genre);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GenreViewModel model)
        {
            Boolean success = _genreService.AddGenre(_mapper.Map<MusicCore.Genre>(model));
            return RedirectToAction("Genres");
        }
    }
}