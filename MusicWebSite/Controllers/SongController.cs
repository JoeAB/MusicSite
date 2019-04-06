using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Interfaces;
using MusicWebSite.Models;
using MusicWebSite.ViewModels.Song;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite.Controllers
{
    public class SongController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISongService _songService;
        private readonly IGenreService _genreService;

        public SongController(IMapper mapper, ISongService songService, IGenreService genreService)
        {
            _mapper = mapper;
            _songService = songService;
            _genreService = genreService;
        }

        public IActionResult Songs(string filter = null)
        {
            List<SongModel> songViewModels = _mapper.Map<List<SongModel>>(_songService.GetAllSongs());
            return View(songViewModels);
        }

        public IActionResult View(int id)
        {
            SongModel song = _mapper.Map<SongModel>(_songService.GetSong(id));
            return View(song);
        }

        [HttpGet]
        public IActionResult Create(int artistID)
        {
            CreateSongViewModel model = new CreateSongViewModel();
            model.song = new SongModel();
            model.artistID = artistID;
            model.genreList = _mapper.Map<List<GenreModel>>(_genreService.GetAllGenres());
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateSongViewModel model)
        {
            MusicCore.Song songCore = _mapper.Map<MusicCore.Song>(model.song);
            songCore.songArtist = new MusicCore.Artist();
            songCore.songArtist.id = model.artistID;
            songCore.songGenre = new MusicCore.Genre();
            songCore.songGenre.id = model.genreID;

            Boolean success = _songService.AddSong(songCore);
            return RedirectToAction("Songs");
        }
    }
}