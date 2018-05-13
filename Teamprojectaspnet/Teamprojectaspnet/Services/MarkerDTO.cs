using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Services
{
    public class MarkerDTO
    {
        public int MarkerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string [] Contacts  { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string TypeofMarker { get; set; }
        public  string MarkerAddress { get; set; }
        public string MarkerLogin { get; set; }
    }
}