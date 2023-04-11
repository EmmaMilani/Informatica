using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Operator
{
    public interface IContainer
    {
        //ritorna true se il contenitore è vuoto, false altrimenti
        bool IsEmpty();
        //rende vuoto il contenitore
        void MakeEmpty();
        //restituisce il numero di elementi inseriti nel contenitore
        int Size();
    }
}
