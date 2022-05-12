using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Mapper
{
    internal class LEGOSetMapper
    {

        public static DTO.Model.DTOLEGOSet Map(LEGOSet LEGOSet)
        {
            return new DTO.Model.DTOLEGOSet(LEGOSet.LEGOSetName, LEGOSet.LEGOSetNumber, LEGOSet.LEGOSetID, LEGOSet.Discontinued, LEGOSet.InStorage);
        }

        public static LEGOSet Map(DTO.Model.DTOLEGOSet LEGOSet)
        {
            return new LEGOSet(LEGOSet.LEGOSetName, LEGOSet.LEGOSetNumber, LEGOSet.Discontinued, LEGOSet.InStorage);
        }
    }
}
