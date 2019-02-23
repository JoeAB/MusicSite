using MusicData.DataAccess;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicCore.Services
{
    internal class CoreToDataMapperService
    {
        internal IArtist MapArtistCoreToData(Artist artistCore)
        {
            DataObjectFactory dataObjectFactory = new DataObjectFactory();
            IArtist artistData = (IArtist)dataObjectFactory.RetrieveObject("artist");
            artistData.artistID = artistCore.id;
            artistData.description = artistCore.description;
            artistData.name = artistCore.name;
            artistData.startingDate = artistCore.startingDate;
            artistData.endingDate = artistCore.endingDate;
            return artistData;
        }

        internal Artist MapArtistDataToCore(IArtist artistData)
        {
            Artist artistCore = new Artist();
            artistCore.id = artistData.artistID;
            artistCore.description = artistData.description;
            artistCore.name = artistData.name;
            artistCore.startingDate = artistData.startingDate;
            artistCore.endingDate = artistData.endingDate;
            return artistCore;
        }
        internal ISong MapSongCoreToData(Song songCore)
        {
            DataObjectFactory dataObjectFactory = new DataObjectFactory();
            ISong songData = (ISong)dataObjectFactory.RetrieveObject("song");
            songData.songID = songCore.id;
            songData.name = songCore.name;
            songData.releaseDate = songCore.releaseDate;
            songData.filePath = songCore.filePath;
            songData.dollarPrice = songCore.price;
            return songData;
        }

        internal Song MapSongDataToCore(ISong songData)
        {
            Song songCore = new Song();
            songCore.id = songData.songID;
            songCore.name = songData.name;
            songCore.price = songData.dollarPrice;
            songCore.releaseDate = songData.releaseDate;
            songCore.filePath = songData.filePath;
            return songCore;
        }

    }
}
