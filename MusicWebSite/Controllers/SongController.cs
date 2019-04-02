using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Interfaces;
using MusicWebSite.Models;

namespace MusicWebSite.Controllers
{
    public class SongController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISongService _songService;

        public SongController(IMapper mapper, ISongService songService)
        {
            _mapper = mapper;
            _songService = songService;
        }

        public IActionResult Songs(string filter = null)
        {
            List<SongViewModel> songViewModels = _mapper.Map<List<SongViewModel>>(_songService.GetAllSongs());
            return View(songViewModels);
        }

        public IActionResult View(int id)
        {
            SongViewModel song = _mapper.Map<SongViewModel>(_songService.GetSong(id));
            return View(song);
        }

        [HttpGet]
        public IActionResult Create(int artistID)
        {
            SongViewModel model = new SongViewModel();
            model.artist = new ArtistViewModel();
            model.artist.id = artistID;
            model.genre = new GenreViewModel();
            model.genre.id = 1;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SongViewModel model)
        {
            MusicCore.Song songCore = _mapper.Map<MusicCore.Song>(model);
            songCore.songArtist = _mapper.Map<MusicCore.Artist>(model.artist);
            songCore.songGenre =_mapper.Map<MusicCore.Genre>(model.genre);
            Boolean success = _songService.AddSong(songCore);
            return RedirectToAction("Songs");
        }
    }
}