using MusicCore;
using MusicData.DataAccess;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicCore.Services
{
    public class GenreService
    {
        public Genre GetGenre(int id)
        {
            //want to refactor this later with DI but will leave alone until I find the best approach for this
            IGenreRepository repository = new GenreRepository();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapGenreDataToCore(repository.GetGenre(id));
        }
        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            //want to refactor this later with DI but will leave alone until I find the best approach for this
            IGenreRepository repository = new GenreRepository();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            foreach (IGenre genreData in repository.GetAllGenres())
            {
                genres.Add(mapperService.MapGenreDataToCore(genreData));
            }
            return genres;
        }
        public Boolean AddGenre(Genre genre)
        {
            IGenreRepository repository = new GenreRepository();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return repository.SaveGenre(mapperService.MapGenreCoreToData(genre));
        }
    }
}
