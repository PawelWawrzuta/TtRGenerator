using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtRGenerator.Models;

namespace TtRGenerator.Clingo_forms
{
    public class VerticesClingo
    {
        public int VertexId { get; set; }
        public int GameDetailsId { get; set; }
        public string VertexName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public VerticesClingo(Vertices vertices)
        {
            VertexId = vertices.VertexId;
            GameDetailsId = vertices.GameDetailsId;
            VertexName = vertices.VertexName;
            Latitude = Convert.ToDouble(vertices.Latitude);
            Longitude = Convert.ToDouble(vertices.Longitude);
        }
    }
}
