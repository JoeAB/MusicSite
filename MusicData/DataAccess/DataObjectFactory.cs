using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicData.DataAccess
{
    public class DataObjectFactory
    {
        public IDataObject RetrieveObject(String creationParameter)
        {
            switch(creationParameter)
            {
                case "artist":
                    return new Artist();
                case "song":
                    return new Song();
                case "album":
                    return new Album();
                case "genre":
                    return new Genre();
                case "songToAlbumMapping":
                    return new SongToAlbumMapping();
                default:
                    throw new Exception("Unsupported object type requested to factory");
            }
                 
        }
    }
}
