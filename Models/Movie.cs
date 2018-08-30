using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Models
{
    public class Movie
    {
        public int MovieID
        {
            get; set;
        }
        public string MovieName
        {
            get; set;
        }
        public string ReleaseYear
        {
            get; set;
        }
        public string Genre
        {
            get; set;
        }
    }
}
