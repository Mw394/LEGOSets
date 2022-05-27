using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    [Serializable]
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
            LEGOBrickID = lEGOBrick.LEGOBrickID;
            LEGOSetID = dTOLEGOSet.LEGOSetID;
        }

        public int LEGOBrickID { get; set; }

        public int LEGOSetID { get; set; }

        public DTOLEGOBrick LEGOBrick { get; set; }

        public DTOLEGOSet DTOLEGOSet { get; set; }

        public int Amount { get; set; }

        public int SetBrickLinkID { get; set; }

        public string BrickInfo { get { return Amount + " | " + LEGOBrick.Description + " | " + LEGOBrick.Color; } }
    }
}
