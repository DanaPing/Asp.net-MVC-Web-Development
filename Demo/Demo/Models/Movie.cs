using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

       
        
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime AddDate { get; set; }
        [StockOver0]
        public int NumberInStock { get; set; }

        public int NumberAvaliable { get; set; }

    }
}