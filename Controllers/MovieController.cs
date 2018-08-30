using Microsoft.AspNetCore.Mvc;
using MovieWebApplication.Models;
using System;
using System.Collections.Generic;

namespace MovieWebApplication.Controllers
{
    public class MovieController : Controller
    {

        MovieViewModel movieViewModel = new MovieViewModel();
        
        private static List<Movie> movies=getAllMovies();
        


        public MovieController()
        {
           
            
            
        }

        public IActionResult Index()
        {
            /// <summary>
            /// Default Action result
            /// </summary>
            /// <returns></returns>


            //ViewData.Model = movieViewModel;
            movieViewModel.MovieList = movies;
            return View(movieViewModel);            
        }

        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MovieViewModel movie)
        {
            var receivedMovieId = $"{movie.MovieID}";
            int movieID = Convert.ToInt32(receivedMovieId);
            List<Movie> movieData = new List<Movie>();
            foreach (Movie item in movies)
            {
                if (item.MovieID == movieID)
                {
                    movieData.Add(item);
                }
            }
            movieViewModel.MovieList = movieData;
            Index();
            ModelState.Clear();
            return Json(movieViewModel);
        }


        [HttpPost]
        public IActionResult Insert(Movie movie)
        {
            movies.Add(movie);
            //var receivedMovieId = $"{movie.MovieID}";
            //int movieID = Convert.ToInt32(receivedMovieId);
            //List<Movie> movieData = new List<Movie>();
            //foreach (Movie item in movies)
            //{
            //    if (item.MovieID == movieID)
            //    {
            //        movieData.Add(item);
            //    }
            //}
            //movieViewModel.MovieList = movies;
            return RedirectToAction("Index", "Movie");
            //Index();
            //ModelState.Clear();
            //return Json(movieViewModel);
        }



        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {


             bool isFound = false;
            Movie tempMovieData = new Movie();
            foreach (var item in movies)
            {
                if (item.MovieID == movie.MovieID)
                {
                    isFound = true;
                    tempMovieData = item;
                }
            }
            if (isFound)
            {
                movies.Remove(tempMovieData);
                return RedirectToAction("Index", "Movie");

            }
            return NotFound();

           
        }



   
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            bool isFound = false;
            foreach (var item in movies)
            {
                if (item.MovieID == movie.MovieID)
                {
                    isFound = true;
                    item.MovieName = movie.MovieName;
                    item.ReleaseYear = movie.ReleaseYear;
                    item.Genre = movie.Genre;
                }
            }
            if (isFound)
            {
                return RedirectToAction("Index", "Movie");
            }
            return NotFound();
        }




        private static List<Movie> getAllMovies()
        {
            MovieData objMovie = new MovieData();
        
        return objMovie.Getata();
            
        }


    }
}