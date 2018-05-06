using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Services
{
    public class MarkerDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string [] Contacts  { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}