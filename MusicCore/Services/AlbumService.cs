using MusicCore.Interfaces;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicCore.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ISongToAlbumMappingRepository _songToAlbumMappingRepository;

        public AlbumService(IAlbumRepository albumRepository, ISongToAlbumMappingRepository songToAlbumMappingRepository)
        {
            _albumRepository = albumRepository;
            _songToAlbumMappingRepository = songToAlbumMappingRepository;
        }
        public bool AddAlbum(Album album)
        {
            //only set everything up if our object is valid
            if (Validate(album))
            {
                CoreToDataMapperService mapperService = new CoreToDataMapperService();
                return _albumRepository.SaveAlbum(mapperService.MapAlbumCoreToData(album));
            }
            return false;
        }

        public List<Album> GetAllAlbums()
        {
            List<Album> albums = new List<Album>();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            foreach (IAlbum albumData in _albumRepository.GetAllAlbums())
            {
                albums.Add(mapperService.MapAlbumDataToCore(albumData));
            }
            return albums;
        }

        public Album GetAlbum(int id)
        {
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapAlbumDataToCore(_albumRepository.GetAlbum(id));
        }

        public bool Validate(Album album)
        {
            return true;
        }

        public bool AddSongToAlbum(int albumID, int songID)
        {
            return _songToAlbumMappingRepository.AddSongToAlbumMapping(albumID, songID);
        }

    }
}
