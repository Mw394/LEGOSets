using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Repository;

namespace BusinessLogic.BLL
{
    public class LEGOBLL
    {

        public DTOLEGOSet GetLEGOSet(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return LEGORepository.GetLEGOSet(id);
        }

        public void AddLEGOSet(DTOLEGOSet LEGOSet)
        {
            LEGORepository.AddLEGOSet(LEGOSet);
        }

        public void UpdateLEGOSet(DTOLEGOSet LEGOSet)
        {
            LEGORepository.UpdateLEGOSet(LEGOSet);
        }

        public List<DTOLEGOSet> GetLEGOSets()
        {
            return LEGORepository.GetLEGOSets();
        }

        public List<DTOLEGOBrick> GetLEGOBricks()
        {
            return LEGORepository.GetLEGOBricks();
        }

        public void AddLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            LEGORepository.AddLEGOBrick(LEGOBrick);
        }

        public void UpdateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            LEGORepository.UpdateLEGOBrick(LEGOBrick);
        }

        public DTOLEGOBrick GetLEGOBrick(int id)
        {
            return LEGORepository.GetLEGOBrick(id);
        }

        public void DeleteLEGOBrick(int id)
        {
            LEGORepository.DeleteLEGOBrick(id);
        }

        public List<DTOSetBrickLink> GetSetBrickLinks(DTOLEGOSet LEGOSet)
        {
            return LEGORepository.GetSetBrickLinks(LEGOSet);
        }
    }
}
