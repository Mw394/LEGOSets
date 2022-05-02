using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEGOSets.Models
{
    public class SetBrickLink
    {
        private LEGOBrick legoBrick;
        private LEGOSet legoSet;
        private int amount;
        private int setBrickLinkID;

        public SetBrickLink()
        {

        }

        public SetBrickLink(LEGOBrick legoBrick, LEGOSet legoSet, int amount, int setBrickLinkID)
        {
            this.legoBrick = legoBrick;
            this.legoSet = legoSet;
            this.amount = amount;
            this.setBrickLinkID = setBrickLinkID;
        }

        public LEGOBrick LegoBrick { get => legoBrick; set => legoBrick = value; }
        public LEGOSet LegoSet { get => legoSet; set => legoSet = value; }
        public int Amount { get => amount; set => amount = value; }
        public int SetBrickLinkID { get => setBrickLinkID; set => setBrickLinkID = value; }
    }
}