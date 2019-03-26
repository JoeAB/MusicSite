using MusicCore;
using MusicData.DataAccess;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCore.Services
{
    public class ArtistService
    {
        public Artist GetArtist(int id)
        {
            //want to refactor this later with DI but will leave alone until I find the best approach for this
            IArtistRepository repository = new ArtistRepository();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapArtistDataToCore(repository.GetArtist(id));
        }
        public List<Artist> GetAllArtists()
        {
            List <Artist> artists = new List<Artist>();
            //want to refactor this later with DI but will leave alone until I find the best approach for this
            IArtistRepository repository = new ArtistRepository();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            foreach(IArtist artistData in repository.GetAllArtists())
            {
                artists.Add(mapperService.MapArtistDataToCore(artistData));
            }
            return artists;
        } 
        public Boolean AddArtist(Artist artist)
        {
            IArtistRepository repository = new ArtistRepository();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return repository.SaveArtist(mapperService.MapArtistCoreToData(artist));
        }

    }
}
