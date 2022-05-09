using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEGOSets.Models
{
    public class LEGOSet
    {
        private string legoSetName;
        private string legoSetNumber;
        private int legoSetID;
        private bool discontinued;
        private bool inStorage;
        private List<SetBrickLink> setBrickLinks;

        public LEGOSet()
        {

        }

        public LEGOSet(string legoSetName, string legoSetNumber, bool discontinued, bool inStorage)
        {
            this.legoSetName = legoSetName;
            this.legoSetNumber = legoSetNumber;
            this.discontinued = discontinued;
            this.inStorage = inStorage;
        }

        

        public string LegoSetName { get => legoSetName; set => legoSetName = value; }
        public string LegoSetNumber { get => legoSetNumber; set => legoSetNumber = value; }
        public int LegoSetID { get => legoSetID; set => legoSetID = value; }
        public bool Discontinued { get => discontinued; set => discontinued = value; }
        public bool InStorage { get => inStorage; set => inStorage = value; }
        public List<SetBrickLink> SetBrickLinks { get => setBrickLinks; set => setBrickLinks = value; }
    }
}