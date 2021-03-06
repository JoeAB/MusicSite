﻿using MusicData.DataAccess;
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
            songData.videoPath = songCore.videoPath;
            songData.artistID = songCore.songArtistID;
            songData.genreID = songCore.songGenreID;
       

            return songData;
        }

        internal Song MapSongDataToCore(ISong songData)
        {
            Song songCore = new Song();
            songCore.id = songData.songID;
            songCore.name = songData.name;
            songCore.releaseDate = songData.releaseDate;
            songCore.filePath = songData.filePath;
            songCore.videoPath = songData.videoPath;
            songCore.songArtistID = songData.artistID;
            songCore.songGenreID = songData.genreID;


            return songCore;
        }
        internal IGenre MapGenreCoreToData(Genre genreCore)
        {
            DataObjectFactory dataObjectFactory = new DataObjectFactory();
            IGenre genreData = (IGenre)dataObjectFactory.RetrieveObject("genre");
            genreData.genreID = genreCore.id;
            genreData.name = genreCore.name;
            return genreData;
        }
        internal Genre MapGenreDataToCore(IGenre genreData)
        {
            Genre genreCore = new Genre();
            genreCore.id = genreData.genreID;
            genreCore.name = genreData.name;
            return genreCore;
        }

        internal IAlbum MapAlbumCoreToData(Album albumCore)
        {
            DataObjectFactory dataObjectFactory = new DataObjectFactory();
            IAlbum albumData = (IAlbum)dataObjectFactory.RetrieveObject("album");
            albumData.albumID = albumCore.id;
            albumData.name = albumCore.name;
            albumData.releaseDate = albumCore.releaseDate;
            albumData.albumImagePath = albumCore.coverImagePath;
            return albumData;
        }
        internal Album MapAlbumDataToCore(IAlbum albumData)
        {
            Album albumCore = new Album();
            albumCore.id = albumData.albumID;
            albumCore.name = albumData.name;
            albumCore.releaseDate = albumData.releaseDate;
            albumCore.coverImagePath = albumData.albumImagePath;

            return albumCore;
        }
    }
}
