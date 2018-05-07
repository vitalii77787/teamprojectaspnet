using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teamprojectaspnet.Models;

namespace Teamprojectaspnet.Services
{
    public static class MarkerConverter
    {
        public static List<MarkerDTO> ConvertToView( Marker[] markers)
        {
            List<MarkerDTO> returnobjects = new List<MarkerDTO>();
            foreach (var item in markers)
            {
                MarkerDTO current = new MarkerDTO()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    Contacts = item.Contacts.Select(x => x.Name).ToArray()
                };
                returnobjects.Add(current);
            }
            return returnobjects;
        }
    }
}