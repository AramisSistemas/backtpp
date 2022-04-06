using Repository.Modelsdto.Compositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICompositionService
    {
        IEnumerable<CompositionDto> GetAll();
    }
}
