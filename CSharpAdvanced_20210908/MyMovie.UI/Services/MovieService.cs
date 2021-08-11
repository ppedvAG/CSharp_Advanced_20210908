using MyMovie.Share.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.UI.Services
{
    public class MovieService : IMovieService
    {

        private readonly HttpClient _httpClient;
        private string _baseURL = "https://localhost:5001/api/Movie/";
        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteMovie(int id)
        {
            string url = _baseURL + id.ToString();

            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
        }

        public async Task<List<Movie>> GetAll()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseURL);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            string jsonText = await  response.Content.ReadAsStringAsync();

            List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonText);

            return movieList;
        }

        public async Task<Movie> GetById(int id)
        {
            string extendetURL = _baseURL + id.ToString();

            HttpResponseMessage response = await _httpClient.GetAsync(extendetURL);
            string jsonText = await response.Content.ReadAsStringAsync();

            Movie currentMovie = JsonConvert.DeserializeObject<Movie>(jsonText);

            return currentMovie;
        }

        public async Task InsertMovie(Movie movie)
        {
            string jsonText = JsonConvert.SerializeObject(movie);

            StringContent content = new StringContent(jsonText, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_baseURL, content);
        }

        public async Task UpdateMovie(Movie movie)
        {
            string extendetURL = _baseURL + movie.Id.ToString();

            string jsonText = JsonConvert.SerializeObject(movie);
            StringContent body = new StringContent(jsonText, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(extendetURL, body);
        }
    }
}
