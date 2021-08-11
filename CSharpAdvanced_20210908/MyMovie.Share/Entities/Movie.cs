using System;

namespace MyMovie.Share.Entites
{
    public class Movie
    {
        public int Id { get; set; } //Id wird benötigt -> EF Core 
        public string Titel { get; set; }
        public string Description { get; set; }

        public Genre Genre { get; set; }
    }

    public enum Genre { Action=1, Drama, Romantik, Abenteuer, Comedy, Documentation}
}
