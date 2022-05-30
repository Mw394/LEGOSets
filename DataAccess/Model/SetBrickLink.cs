using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    public class SetBrickLink
    {

        public SetBrickLink()
        {

        }

        public SetBrickLink(LEGOSet legoSet, LEGOBrick legoBrick, int amount)
        {
            LEGOBrick = legoBrick;
            LEGOSet = legoSet;
            Amount = amount;
        }

        public SetBrickLink(int amount)
        {
            Amount = amount;
        }

        public virtual LEGOBrick LEGOBrick { get; set; }
        public virtual LEGOSet LEGOSet { get; set; }
        public int Amount { get; set; }
        [Key]
        public int SetBrickLinkID { get; set; }
    }
}