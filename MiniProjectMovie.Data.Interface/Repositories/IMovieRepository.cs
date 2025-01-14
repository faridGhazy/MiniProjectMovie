﻿using MiniProjectMovie.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Data.Interface.Repositories
{
    public interface IMovieRepository
    {
        //Movie
        public Task<bool> Create(Movie model);
        /*public Task<List<Movie>> GetAll();*/
        public Task<List<Movie>> GetById(int id);
        public Task<Movie> Update(Movie model);
        public Task<bool> Delete(int id);

    }
}
