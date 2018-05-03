using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Models
{
    public class Contact
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual Marker Marker { get; set; }
    }
}