using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teamprojectaspnet.Models;

namespace Teamprojectaspnet.Services
{
    public static class MarkerConverter
    {
     
        public static List<MarkerModel> ConvertToView( Marker[] markers)
        {
            List<MarkerModel> returnobjects = new List<MarkerModel>();
            foreach (var item in markers)
            {
                MarkerModel current = new MarkerModel()
                {
                    ID=item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    Contacts = item.Contacts.Select(x => x.Name).ToArray(),
                    MarkerAddress = item.Address.City.Name + " " + item.Address.Street + " " + item.Address.Number,
                    MarkerLogin=item.Login.Name,
                    TypeofMarker=item.Type.Name
                };
                returnobjects.Add(current);
            }
            return returnobjects;
        }

        public static MarkerModel MarkerById(Marker item)
        {
            MarkerModel current = new MarkerModel()
            {
                ID = item.Id,
                Name = item.Name,
                Description = item.Description,
                Lat = item.Lat,
                Lng = item.Lng,
                Contacts = item.Contacts.Select(x =>x.Id+" : "+ x.Name).ToArray(),
                MarkerAddress = item.Address.Id+" : "+item.Address.City.Name + ", " + item.Address.Street + " " + item.Address.Number,
                MarkerLogin = item.Login.Id+" : "+item.Login.Name,
                TypeofMarker = item.Type.Id+" : "+item.Type.Name
            };
            return current;
        }
     
    }
}