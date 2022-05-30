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
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a Design Number")]
        [Range(1, int.MaxValue, ErrorMessage ="Design number cannot be 0")]
        public int DesignNumber { get; set; }
        public int LEGOBrickID { get; set; }
        [Required(ErrorMessage = "Please choose a color")]
        public Color Color { get; set; }

        public string BrickInfo { get { return DesignNumber + " " + Description + " " + Color; } }

        public override string ToString()
        {
            return DesignNumber + " | " + Description + " | " + Color;
        }

    }

}
