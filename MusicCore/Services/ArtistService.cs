using MusicCore.Interfaces;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicCore.Services
{
    public class ArtistService: IArtistService
    {

        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public Artist GetArtist(int id)
        {
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapArtistDataToCore(_artistRepository.GetArtist(id));
        }
        public List<Artist> GetAllArtists()
        {
            List <Artist> artists = new List<Artist>();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            foreach(IArtist artistData in _artistRepository.GetAllArtists())
            {
                artists.Add(mapperService.MapArtistDataToCore(artistData));
            }
            return artists;
        } 
        public Boolean AddArtist(Artist artist)
        {
            //only set everything up if our object is valid
            if(Validate(artist))
            {
                CoreToDataMapperService mapperService = new CoreToDataMapperService();
                return _artistRepository.SaveArtist(mapperService.MapArtistCoreToData(artist));
            }
            return false;
        }
        //return false if the object violates requirements
        public Boolean Validate(Artist artist)
        {
            Boolean returnValue = true;
            if (artist.endingDate.HasValue && artist.endingDate.Value < artist.startingDate)
            {
                returnValue = false;
            }

            return returnValue;
        }

    }
}
