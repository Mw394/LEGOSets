using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    internal class SetBrickLink
    {
        private LEGOBrick legoBrick;
        private LEGOSet legoSet;
        private int amount;
        private int setBrickLinkID;

        public SetBrickLink()
        {

        }

        public SetBrickLink(LEGOSet legoSet, LEGOBrick legoBrick, int amount)
        {
            this.legoBrick = legoBrick;
            this.legoSet = legoSet;
            this.amount = amount;
        }

        public LEGOBrick LEGOBrick { get => legoBrick; set => legoBrick = value; }
        public LEGOSet LEGOSet { get => legoSet; set => legoSet = value; }
        public int Amount { get => amount; set => amount = value; }
        public int SetBrickLinkID { get => setBrickLinkID; set => setBrickLinkID = value; }
    }
}