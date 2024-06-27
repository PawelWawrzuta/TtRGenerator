using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtRGenerator.Models
{
    public class Vertices
    {
        public int VertexId { get; set; }
        public int GameDetailsId { get; set; }
        public string VertexName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Vertices(int vertexId, string vetexName, decimal lat, decimal lon)
        {
            VertexId = vertexId;
            VertexName = vetexName;
            Latitude = lat;
            Longitude = lon;
        }

        public Vertices(string vetexName, decimal lat, decimal lon)
        {
            VertexName = vetexName;
            Latitude = lat;
            Longitude = lon;
        }
        public Vertices()
        {
                
        }
    }
}
