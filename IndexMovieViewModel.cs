using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Viddly2.Models;

namespace Viddly2.ViewModels
{
    public class IndexMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}