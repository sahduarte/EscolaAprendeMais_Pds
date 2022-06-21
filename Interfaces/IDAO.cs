using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pds_Escola_AprendeMaisSoft.Interfaces
{
    internal interface IDAO <E>
    {
        void Insert(E t);

        void Update(E t);

        void Delete(E t);

        List<E> List();

        E GetById(int id);
    }
}
