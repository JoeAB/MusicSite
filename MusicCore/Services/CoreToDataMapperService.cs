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
        internal ISong MapSongCoreToData(Song songCore, Boolean mapAlbums = false)
        {
            DataObjectFactory dataObjectFactory = new DataObjectFactory();
            ISong songData = (ISong)dataObjectFactory.RetrieveObject("song");
            songData.songID = songCore.id;
            songData.name = songCore.name;
            songData.releaseDate = songCore.releaseDate;
            songData.filePath = songCore.filePath;
            //Check to see if we have ablum data we want to convert
            if(mapAlbums)
            {
                songData.albums = new List<IAlbum>();
                foreach(Album album in songCore.songAlbums)
                {
                    //don't get all the songs for the album, we just want basic info
                    songData.albums.Add(MapAlbumCoreToData(album, false));
                }
            }

            return songData;
        }

        internal Song MapSongDataToCore(ISong songData, Boolean mapAlbums = false)
        {
            Song songCore = new Song();
            songCore.id = songData.songID;
            songCore.name = songData.name;
            songCore.releaseDate = songData.releaseDate;
            songCore.filePath = songData.filePath;
            //Check to see if we have ablum data we want to convert
            if (mapAlbums)
            {
                songCore.songAlbums = new List<Album>();
                foreach (IAlbum album in songData.albums)
                {
                    //don't get all the songs for the album, we just want basic info
                    songCore.songAlbums.Add(MapAlbumeDataToCore(album, false));
                }
            }

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

        internal IAlbum MapAlbumCoreToData(Album albumCore, Boolean mapSongs = false)
        {
            DataObjectFactory dataObjectFactory = new DataObjectFactory();
            IAlbum albumData = (IAlbum)dataObjectFactory.RetrieveObject("album");
            albumData.albumID = albumCore.id;
            albumData.name = albumCore.name;
            albumData.releaseDate = albumCore.releaseDate;

            //Check to see if we have song data we want to convert
            if (mapSongs)
            {
                albumData.songs = new List<ISong>();
                foreach (Song song in albumCore.songs)
                {
                    //don't get all the albums for the song, we just want basic info
                    albumData.songs.Add(MapSongCoreToData(song, false));
                }
            }
            return albumData;
        }
        internal Album MapAlbumeDataToCore(IAlbum albumData,  Boolean mapSongs = false)
        {
            Album albumCore = new Album();
            albumCore.id = albumData.albumID;
            albumCore.name = albumData.name;
            albumCore.releaseDate = albumData.releaseDate;

            //Check to see if we have song data we want to convert
            if (mapSongs)
            {
                albumCore.songs = new List<Song>();
                foreach (ISong song in albumData.songs)
                {
                    //don't get all the albums for the song, we just want basic info
                    albumCore.songs.Add(MapSongDataToCore(song, false));
                }
            }
            return albumCore;
        }
    }
}
