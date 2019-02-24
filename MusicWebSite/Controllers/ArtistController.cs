using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicCore.Services;
using MusicWebSite.Models;

namespace MusicWebSite.Controllers
{
    public class ArtistController: Controller
    {
        private readonly IMapper _mapper;

        public ArtistController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult BrowseAll()
        {
            ArtistService artistService = new ArtistService();
            List<ArtistViewModel> artistViewModels = _mapper.Map<List<ArtistViewModel>>(artistService.GetAllArtists());
            return View(artistViewModels);
        }

        public IActionResult View(int id)
        {
            ArtistService artistService = new ArtistService();
            ArtistViewModel artist =  _mapper.Map<ArtistViewModel>(artistService.GetArtist(id));
            return View(artist);
        }
    }
}
