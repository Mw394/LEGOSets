using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            NewObject = false;
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
        [Required]
        public int LEGOBrickID { get; set; }
        public int LEGOSetID { get; set; }
        public DTOLEGOBrick LEGOBrick { get; set; }
        public DTOLEGOSet DTOLEGOSet { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than 1")]
        public int Amount { get; set; }

        public int SetBrickLinkID { get; set; }

        public bool NewObject { get; set; }

        [JsonIgnore]
        public string BrickInfo { get { return Amount + " | " + LEGOBrick.Description + " | " + LEGOBrick.Color; } }
    }
}
