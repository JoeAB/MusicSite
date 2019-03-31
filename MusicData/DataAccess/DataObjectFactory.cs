using MusicData.Entities;
using MusicData.Interfaces;
using System;

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
                default:
                    throw new Exception("Unsupported object type requested to factory");
            }
                 
        }
    }
}
