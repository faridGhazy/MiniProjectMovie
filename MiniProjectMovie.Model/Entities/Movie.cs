using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Model.Entities
{
    public class Movie
    {
        public int id { get; set; }
        public string namaMovie { get; set; }
        public float rating { get; set; }
        public int tahun { get; set; }
        public int sutradaraId { get; set; }
        public int aktorUtamaId { get; set; }
    }
}
