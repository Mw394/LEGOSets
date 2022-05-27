using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DTO.Model
{
    [Serializable]
    public class DTOLEGOSet
    {

        public DTOLEGOSet()
        {
            SetBrickLinks = new List<DTOSetBrickLink>();
        }

        public DTOLEGOSet(string lEGOSetName, string lEGOSetNumber, int lEGOSetID, bool discontinued, bool inStorage)
        {
            LEGOSetName = lEGOSetName;
            LEGOSetNumber = lEGOSetNumber;
            LEGOSetID = lEGOSetID;
            Discontinued = discontinued;
            InStorage = inStorage;
            SetBrickLinks = new List<DTOSetBrickLink>();
        }
        [Required(ErrorMessage = "Please enter a Set name")]
        public string LEGOSetName { get; set; }

        [Required(ErrorMessage = "Please enter a SetNumber")]
        public string LEGOSetNumber { get; set; }

        public int LEGOSetID { get; set; }

        public bool Discontinued { get; set; }

        public bool InStorage { get; set; }

        public List<DTOSetBrickLink> SetBrickLinks { get; set; }
    }


}
