using MusicCore;
using MusicData.DataAccess;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCore.Services
{
    public class ArtistService
    {
        public Artist GetArtist(int id)
        {
            IArtist artistData;
            using (DataContext context = new DataContext())
            {
                artistData = context.Artists.Single(x => x.artistID.Equals(id));
            }
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapArtistDataToCore(artistData);
        }
    }
}
