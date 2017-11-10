using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devnot.AspnetCore.Sample.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Spot { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }
}
