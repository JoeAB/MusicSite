using MusicCore;
using MusicCore.Interfaces;
using MusicData.DataAccess;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicCore.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;

        public SongService(ISongRepository songRepository, IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository; 
        }

        public bool AddSong(Song song)
        {
            //only set everything up if our object is valid
            if (Validate(song))
            {
                CoreToDataMapperService mapperService = new CoreToDataMapperService();
                return _songRepository.SaveSong(mapperService.MapSongCoreToData(song));
            }
            return false;
        }

        public bool UpdateSong(Song song)
        {
            //only set everything up if our object is valid
            if (Validate(song))
            {
                CoreToDataMapperService mapperService = new CoreToDataMapperService();
                return _songRepository.UpdateSong(mapperService.MapSongCoreToData(song));
            }
            return false;
        }

        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            foreach (ISong songData in _songRepository.GetAllSongs())
            {
                songs.Add(mapperService.MapSongDataToCore(songData));
            }
            return songs;
        }

        public Song GetSong(int id)
        {
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapSongDataToCore(_songRepository.GetSong(id));
        }

        public bool Validate(Song song)
        {
            //check the artist ID is valid
            IArtist artist = _artistRepository.GetArtist(song.songArtistID);
            if (artist == null)
            {
                return false;
            }
            //check the genre id is valid
            else if(_genreRepository.GetGenre(song.songGenreID) == null)
            {
                return false;
            }
            //check the year it's released to make sure it's not outside the active years range
            else if(artist.startingDate.Year > song.releaseDate.Year || 
                (artist.endingDate.HasValue && artist.endingDate.Value.Year < song.releaseDate.Year))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
