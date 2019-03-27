using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Services;
using MusicWebSite.Models;

namespace MusicWebSite.Controllers
{
    public class GenreController : Controller
    {
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Genres(string filter = null)
        {
            GenreService genreService = new GenreService();
            List<GenreViewModel> genreViewModels = _mapper.Map<List<GenreViewModel>>(genreService.GetAllGenres());
            return View(genreViewModels);
        }

        public IActionResult View(int id)
        {
            GenreService genreService = new GenreService();
            GenreViewModel genre = _mapper.Map<GenreViewModel>(genreService.GetGenre(id));
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
            GenreService genreService = new GenreService();
            Boolean success = genreService.AddGenre(_mapper.Map<MusicCore.Genre>(model));
            return RedirectToAction("Genres");
        }
    }
}