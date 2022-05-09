using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEGOSets.Models
{
    public enum Color{
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Purple,
    }


    public class LEGOBrick
    {
        private string description;
        private int designNumber;
        private int legoBrickID;
        private Color color;

        public LEGOBrick()
        {
                
        }

        public LEGOBrick(string description, int designNumber, Color color)
        {
            this.description = description;
            this.designNumber = designNumber;
            this.color = color;
        }

        public string Description { get => description; set => description = value; }
        public int DesignNumber { get => designNumber; set => designNumber = value; }
        public int LegoBrickID { get => legoBrickID; set => legoBrickID = value; }
        public Color Color { get => color; set => color = value; }
    }
}