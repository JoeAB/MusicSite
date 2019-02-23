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
                    break;
                case "song":
                    return new Song();
                    break;
                case "album":
                    return new Album();
                    break;
                case "genre":
                    return new Genre();
                    break;
                case "songToAlbumMapping":
                    return new SongToAlbumMapping();
                    break;
                default:
                    throw new Exception("Unsupported object type requested to factory");
                    break;
            }
                 
        }
    }
}
