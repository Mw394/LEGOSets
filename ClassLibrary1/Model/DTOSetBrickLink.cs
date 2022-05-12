using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class DTOSetBrickLink
    {

        public DTOSetBrickLink()
        {

        }

        public DTOSetBrickLink(DTOLEGOBrick lEGOBrick, DTOLEGOSet dTOLEGOSet, int amount, int setBrickLinkID)
        {
            LEGOBrick = lEGOBrick;
            DTOLEGOSet = dTOLEGOSet;
            Amount = amount;
            SetBrickLinkID = setBrickLinkID;
        }

        public DTOLEGOBrick LEGOBrick { get; set; }

        public DTOLEGOSet DTOLEGOSet { get; set; }

        public int Amount { get; set; }

        public int SetBrickLinkID { get; set; }
    }
}
