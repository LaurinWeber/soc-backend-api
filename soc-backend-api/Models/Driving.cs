using System;
using System.Collections.Generic;

#nullable disable

namespace soc_backend_api.Models
{
    public partial class Driving
    {
        public Driving()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Region { get; set; }
        public decimal? KmPerWeek { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
