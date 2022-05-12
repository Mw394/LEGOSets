using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;


namespace DataAccess.Mapper
{
    internal class LEGOBrickMapper
    {

        public static DTO.Model.DTOLEGOBrick Map(LEGOBrick LEGOBrick)
        {
            return new DTO.Model.DTOLEGOBrick(LEGOBrick.Description, LEGOBrick.DesignNumber, LEGOBrick.LEGOBrickID, LEGOBrick.Color);
        }

        public static LEGOBrick Map(DTO.Model.DTOLEGOBrick LEGOBrick)
        {
            return new LEGOBrick(LEGOBrick.Desciprtion, LEGOBrick.DesignNumber, LEGOBrick.Color);
        }
        
    }
}
