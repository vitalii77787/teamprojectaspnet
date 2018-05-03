using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual LoginStatus LoginStatus { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
    }
}