using MusicCore.Interfaces;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;

namespace MusicCore.Services
{
    public class GenreService: IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Genre GetGenre(int id)
        {
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            return mapperService.MapGenreDataToCore(_genreRepository.GetGenre(id));
        }
        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            CoreToDataMapperService mapperService = new CoreToDataMapperService();
            foreach (IGenre genreData in _genreRepository.GetAllGenres())
            {
                genres.Add(mapperService.MapGenreDataToCore(genreData));
            }
            return genres;
        }
        public Boolean AddGenre(Genre genre)
        {
            if(Validate(genre))
            {
                CoreToDataMapperService mapperService = new CoreToDataMapperService();
                return _genreRepository.SaveGenre(mapperService.MapGenreCoreToData(genre));
            }
            return false;
        }
        public Boolean Validate(Genre genre)
        {
            Boolean returnValue = true;

            //don't allow duplicates
            if(_genreRepository.GetByName(genre.name) != null)
            {
                returnValue = false;
            }

            return returnValue;
        }

        public bool UpdateGenre(Genre genre)
        {
            if (Validate(genre))
            {
                CoreToDataMapperService mapperService = new CoreToDataMapperService();
                return _genreRepository.SaveGenre(mapperService.MapGenreCoreToData(genre));
            }
            return false;
        }
    }
}
