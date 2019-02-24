using AutoMapper;
using MusicCore;
using MusicWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebSite
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ArtistViewModel, Artist>();
            CreateMap<Artist, ArtistViewModel>();
        }
    }
}
