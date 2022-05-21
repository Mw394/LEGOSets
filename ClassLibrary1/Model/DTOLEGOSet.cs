using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class DTOLEGOSet
    {

        public DTOLEGOSet()
        {
               
        }

        public DTOLEGOSet(string lEGOSetName, string lEGOSetNumber, int lEGOSetID, bool discontinued, bool inStorage)
        {
            LEGOSetName = lEGOSetName;
            LEGOSetNumber = lEGOSetNumber;
            LEGOSetID = lEGOSetID;
            Discontinued = discontinued;
            InStorage = inStorage;
        }

        public string LEGOSetName { get; set; }

        public string LEGOSetNumber { get; set; }

        public int LEGOSetID { get; set; }

        public bool Discontinued { get; set; }

        public bool InStorage { get; set; }

        public List<DTOSetBrickLink> SetBrickLinks { get; set; }
    }


}
