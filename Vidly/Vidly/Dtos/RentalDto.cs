using System.Collections.Generic;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public MovieDto Movie { get; set; }
        public List<int> MovieIds { get; set; }
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }
      
    }
}