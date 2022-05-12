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
    }
}
