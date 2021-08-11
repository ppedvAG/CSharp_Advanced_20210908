using MyMovie.Share.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.UI.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task InsertMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
