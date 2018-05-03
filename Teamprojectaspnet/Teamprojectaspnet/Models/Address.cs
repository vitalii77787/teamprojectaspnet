using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Models
{
    public class Address
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public virtual City City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
    }
}
