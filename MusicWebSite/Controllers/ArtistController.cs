using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Interfaces;
using MusicWebSite.Models;
using MusicWebSite.ViewModels.Artist;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace MusicWebSite.Controllers
{
    public class ArtistController: Controller
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;

        public ArtistController(IMapper mapper, IArtistService artistService)
        {
            _mapper = mapper;
            _artistService = artistService;
        }

        public IActionResult Artists(string filter = null)
        {
            ListArtistViewModel model = new ListArtistViewModel();
            model.artists = _mapper.Map<List<ArtistModel>>(_artistService.GetAllArtists());
            return View(model);
        }

        public IActionResult View(int id)
        {
            ViewArtistViewModel model = new ViewArtistViewModel();
            model.artist =  _mapper.Map<ArtistModel>(_artistService.GetArtist(id));
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateArtistViewModel model = new CreateArtistViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateArtistViewModel model)
        {
            Boolean success = _artistService.AddArtist(_mapper.Map<MusicCore.Artist>(model.artist));
            return RedirectToAction("Artists");
        }
    }
}
