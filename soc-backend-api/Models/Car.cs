using System;
using System.Collections.Generic;

#nullable disable

namespace soc_backend_api.Models
{
    public partial class Car
    {
        public Car()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
