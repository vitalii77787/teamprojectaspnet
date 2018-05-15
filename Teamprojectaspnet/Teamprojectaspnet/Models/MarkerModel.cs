using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teamprojectaspnet.Models
{
    public class MarkerModel
    {
        //[Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Contacts { get; set; }
        [RegularExpression(@"\d*\,\d*", ErrorMessage = "Invalid data")]
        public double Lat { get; set; }
        [RegularExpression(@"\d*\,\d*", ErrorMessage = "Invalid data")]
        public double Lng { get; set; }
        public string TypeofMarker { get; set; }
        public string MarkerAddress { get; set; }
        public string MarkerLogin { get; set; }
    }
}