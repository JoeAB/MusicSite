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
            CreateMap<ArtistModel, Artist>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<Genre, GenreModel>();
            CreateMap<GenreModel, Genre>();
            CreateMap<Song, SongModel>();
            CreateMap<SongModel, Song>();
            CreateMap<Album, AlbumModel>();
            CreateMap<AlbumModel, Album>();
        }
    }
}
