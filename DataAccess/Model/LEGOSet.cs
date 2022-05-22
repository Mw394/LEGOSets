using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    public class LEGOSet
    {

        public LEGOSet()
        {

        }

        public LEGOSet(string legoSetName, string legoSetNumber, bool discontinued, bool inStorage)
        {
            LEGOSetName = legoSetName;
            LEGOSetNumber = legoSetNumber;
            Discontinued = discontinued;
            InStorage = inStorage;
            SetBrickLinks = new List<SetBrickLink>();
        }

        

        public string LEGOSetName { get; set; }
        public string LEGOSetNumber { get; set; }
        public int LEGOSetID { get; set; }
        public bool Discontinued { get; set; }
        public bool InStorage { get; set; }
        public virtual List<SetBrickLink> SetBrickLinks { get; set; }
    }
}