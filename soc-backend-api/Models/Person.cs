using System;
using System.Collections.Generic;

#nullable disable

namespace soc_backend_api.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? FkCar { get; set; }
        public int? FkDriving { get; set; }

        public virtual Car FkCarNavigation { get; set; }
        public virtual Driving FkDrivingNavigation { get; set; }
    }
}
