using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Description = desciprtion;
            DesignNumber = designNumber;
            LEGOBrickID = legoBrickID;
            Color = color;
        }
        [Required]
        public string Description { get; set; }

        public int DesignNumber { get; set; }

        public int LEGOBrickID { get; set; }

        public Color Color { get; set; }
    }

}
