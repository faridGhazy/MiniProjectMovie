using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectMovie.Model.Entities
{
    public class AllData
    {
        public int movieId { get; set; }
        public string namaMovie { get; set; }
        public float rating { get; set; }
        public int tahun { get; set; }
        public string namaSutradara { get; set; }
        public string namaAktor { get; set; }
        public string namaGenre { get; set; }
    }
}
