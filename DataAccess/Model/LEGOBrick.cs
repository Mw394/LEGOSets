using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO.Model;

namespace DataAccess.Model
{

    public class LEGOBrick
    {

        public LEGOBrick()
        {
                
        }

        public LEGOBrick(string description, int designNumber, Color color)
        {
            Description = description;
            DesignNumber = designNumber;
            Color = color;
        }

        public string Description { get; set; }
        public int DesignNumber { get; set; }
        public int LEGOBrickID { get; set; }
        public Color Color { get; set; }
    }
}