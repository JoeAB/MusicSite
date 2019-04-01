using MusicCore;
using MusicCore.Interfaces;
using MusicData.DataAccess;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicCore.Services
{
    class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
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
            return true;
        }
    }
}
