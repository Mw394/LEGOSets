using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Mapper
{
    internal class SetBrickLinkMapper
    {

        public static DTO.Model.DTOSetBrickLink Map(SetBrickLink SetBrickLink)
        {
            return new DTO.Model.DTOSetBrickLink(LEGOBrickMapper.Map(SetBrickLink.LEGOBrick), LEGOSetMapper.Map(SetBrickLink.LEGOSet), SetBrickLink.Amount, SetBrickLink.SetBrickLinkID);
        }

        public static SetBrickLink Map(DTO.Model.DTOSetBrickLink SetBrickLink)
        {
            return new SetBrickLink(LEGOSetMapper.Map(SetBrickLink.DTOLEGOSet), LEGOBrickMapper.Map(SetBrickLink.LEGOBrick), SetBrickLink.Amount);
        }
    }
}
