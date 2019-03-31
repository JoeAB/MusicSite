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
            List<ArtistViewModel> artistViewModels = _mapper.Map<List<ArtistViewModel>>(_artistService.GetAllArtists());
            return View(artistViewModels);
        }

        public IActionResult View(int id)
        {
            ArtistViewModel artist =  _mapper.Map<ArtistViewModel>(_artistService.GetArtist(id));
            return View(artist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtistViewModel model)
        {
            Boolean success = _artistService.AddArtist(_mapper.Map<MusicCore.Artist>(model));
            return RedirectToAction("Artists");
        }
    }
}
