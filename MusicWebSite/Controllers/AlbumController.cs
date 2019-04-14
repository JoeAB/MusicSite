using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Interfaces;
using MusicWebSite.Models;
using MusicWebSite.ViewModels.Album;

namespace MusicWebSite.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;

        public AlbumController(IMapper mapper, IAlbumService albumService, IArtistService artistService)
        {
            _mapper = mapper;
            _albumService = albumService;
            _artistService = artistService;
        }

        public IActionResult Albums()
        {
            ListAlbumViewModel model = new ListAlbumViewModel();
            model.albums = _mapper.Map<List<AlbumModel>>(_albumService.GetAllAlbums());
            return View(model);
        }

        public IActionResult View(int id)
        {
            ViewAlbumViewModel model = new ViewAlbumViewModel();
            model.album = _mapper.Map<AlbumModel>(_albumService.GetAlbum(id));
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateAlbumViewModel model = new CreateAlbumViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateAlbumViewModel model)
        {
            Boolean success = _albumService.AddAlbum(_mapper.Map<MusicCore.Album>(model.album));
            return RedirectToAction("Albums");
        }

        [HttpGet]
        public IActionResult AddSongToAlbum(int id)
        {
            AddSongToAlbumViewModel model = new AddSongToAlbumViewModel();
            model.album = _mapper.Map<AlbumModel>(_albumService.GetAlbum(id));
            model.artists = _mapper.Map<List<ArtistModel>>(_artistService.GetAllArtists());
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSongToAlbum(AddSongToAlbumViewModel model)
        {
            _albumService.AddSongToAlbum(model.album.id, model.songID);
            return RedirectToAction("View", new { id = model.album.id });
        }
    }
}