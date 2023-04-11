using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Operator
{
    public interface IDictionary
    {
        //inserisce la coppia (key, attribute) nel dizionario. Se la chiave è già
        //presente, sovrascrive la coppia;
        void Insert(IComparable key, object attribute);
        //restituisce l'attributo associato alla chiave key nel dizionario
        object Find(IComparable key);
        //elimina la coppia (key, attribute) dal dizionario e restituisce l'attributo
        //associato alla chiave se questa è presente.
        object Remove(IComparable key);
    }
}
