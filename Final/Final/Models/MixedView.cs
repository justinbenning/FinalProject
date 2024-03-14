using Dapper;
using Final.Models;
using System.Data;
using System.Collections.Generic;


namespace Final.Models
{
    public class MixedView
    {
        public IEnumerable<Shoes> Shoes { get; set; }
        public IEnumerable<Hats> Hats { get; set; }
    }
}
