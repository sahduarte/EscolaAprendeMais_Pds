using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pds_Escola_AprendeMaisSoft.Interfaces
{
    internal interface ICursoDAO <C>
    {
        void Insert(C u);

        void Update(C U);

        void Delete(C U);

        List<C> List();

        C GetById(int id);
    }
}
