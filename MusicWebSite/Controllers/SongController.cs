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
        private readonly IArtistService _artistService;

        public SongController(IMapper mapper, ISongService songService, IGenreService genreService, IArtistService artistService)
        {
            _mapper = mapper;
            _songService = songService;
            _genreService = genreService;
            _artistService = artistService;
        }

        public IActionResult Songs(string filter = null)
        {
            ListSongViewModel model = new ListSongViewModel();
            model.songs = _mapper.Map<List<SongModel>>(_songService.GetAllSongs());
            return View(model);
        }

        public IActionResult View(int id)
        {
            ViewSongViewModel model = new ViewSongViewModel();
            model.song = _mapper.Map<SongModel>(_songService.GetSong(id));
            model.songArtist = _mapper.Map<ArtistModel>(_artistService.GetArtist(model.song.songArtistID));
            model.songGenre = _mapper.Map<GenreModel>(_genreService.GetGenre(model.song.songGenreID));

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int artistID)
        {
            CreateSongViewModel model = new CreateSongViewModel();
            model.song = new SongModel();
            model.song.songArtistID = artistID;
            model.genreList = _mapper.Map<List<GenreModel>>(_genreService.GetAllGenres());
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateSongViewModel model)
        {
            MusicCore.Song songCore = _mapper.Map<MusicCore.Song>(model.song);
            songCore.songArtistID = model.song.songArtistID;
            songCore.songGenreID = model.song.songGenreID;

            Boolean success = _songService.AddSong(songCore);
            return RedirectToAction("Songs");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            EditSongViewModel model = new EditSongViewModel();
            model.song = _mapper.Map<SongModel>(_songService.GetSong(id));
            model.genreList = _mapper.Map<List<GenreModel>>(_genreService.GetAllGenres());
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditSongViewModel model)
        {
            Boolean success = _songService.UpdateSong(_mapper.Map<MusicCore.Song>(model.song));
            return RedirectToAction("Songs");
        }

        [HttpGet]
        public IActionResult GetArtistSongsJson(int artistID)
        {
            List<SongModel> songs = _mapper.Map<List<SongModel>>(_songService.GetSongsByArtist(artistID));
            return Json(songs);
        }
    }
}