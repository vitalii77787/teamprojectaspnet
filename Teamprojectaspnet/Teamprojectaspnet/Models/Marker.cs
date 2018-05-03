using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Models
{
    public class Marker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Address Address { get; set; }
        public virtual MarkerType Type { get; set; }
        public double Lat { get; set; }  // coordinate for google map
        public double Lng { get; set; }  // coordinate long for google map
        public string Picture { get; set; }
        public virtual Login Login { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}