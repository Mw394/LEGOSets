using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{

    public enum Color
    {
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Purple,
    }

    public class DTOLEGOBrick
    {

        public DTOLEGOBrick()
        {

        }

        public DTOLEGOBrick(string desciprtion, int designNumber, int legoBrickID, Color color)
        {
            Desciprtion = desciprtion;
            DesignNumber = designNumber;
            LEGOBrickID = legoBrickID;
            Color = color;
        }

        public string Desciprtion { get; set; }

        public int DesignNumber { get; set; }

        public int LEGOBrickID { get; set; }

        public Color Color { get; set; }
    }

}
