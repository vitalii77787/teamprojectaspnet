using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Models
{
    public class MarkerType
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Marker> Markers { get; set; }
    }
}