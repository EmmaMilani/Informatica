using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tour_Operator
{
    class TourOperator : IDictionary
    {
        string nome_dest;
        private string codiceProssimoCliente;
        Dictionary<string, string> dizionario = new Dictionary<string, string>();
        //metodi pubblici
        public TourOperator(string codiceProssimoCliente)//costruttore
        {
            this.codiceProssimoCliente = codiceProssimoCliente;
        }
        public void add(string nome, string destinazione_viaggio)
        {
            nome_dest = nome + " : " + destinazione_viaggio;
            string temp1 = string.Format($"{codiceProssimoCliente[1]}{codiceProssimoCliente[2]}{codiceProssimoCliente[3]}");//salvo i le posizioni dei numeri in una variabile temporanea
            char temp2 = codiceProssimoCliente[0];//vado a salvare il valore della lettera in una seconda variabile temporanea
            if (Convert.ToInt32(temp1) < 999)//controllo se il numero del cliente è minore di 999
            {
                temp1 = Convert.ToString(Convert.ToInt32(temp1) + 1);//se è vero allora incremento solo il numero
            }
            else
            {
                //se è falso vado a mettere la lettera successiva nell'ordine lessicografico.
                temp1 = "000";
                temp2 = Convert.ToChar(Convert.ToInt32(codiceProssimoCliente[0]) + 1);
            }
            codiceProssimoCliente = temp2 + temp1;
            dizionario.Add(codiceProssimoCliente, nome_dest);//aggiungo al dizionario la coppia key-value
        }
        public override string ToString()//faccio l'override del metodo ToString()
        {
            return string.Format($"{codiceProssimoCliente} : {nome_dest}");
        }
        public static void main(string[] args)
        {
            string Cod_utente = "";
            string nome_dest = "";
            Console.WriteLine("Inserisci codice utente (Esempio: A192):");
            do
            {
                Cod_utente = Console.ReadLine();//leggo dal terminale il codice
            } while (!ControlloCodice(Cod_utente) || Cod_utente.Length != 4);//se il controllo codice è falso o la lunghezza della stringa è diversa da 4, riscrivi il codice
            TourOperator t = new TourOperator(Cod_utente);//creo e inizializzo la variabile t di tipo TourOperator
            Console.WriteLine("Inserisci nome:destinazione del cliente. Scrivi \"fine\" quando hai finito.");
            do
            {
                nome_dest = Console.ReadLine();//leggo nome e destinazione
                if(nome_dest != "fine")
                {
                    string[] array = nome_dest.Split(':');//salvo il nome e la destinazione nell'array "array"
                    t.add(array[0], array[1]);//poi li aggiungo al dizionario
                }
            } while (nome_dest!="fine");//se la stringa è fine interrompo il ciclo
            foreach (KeyValuePair<string, string> p in t.dizionario)//scorro il dizionario
                Console.WriteLine($"{p.Key.ToString()} : {p.Value.ToString()}");//stampo a video il contenuto del dizionario
        }
        private static bool ControlloCodice(string codice_)//controllo se il codice è nel formato corretto
        {
            string Cod = string.Format($"{codice_[1]}{codice_[2]}{codice_[3]}");//salvo i caratteri numerici del codice nella variabile Cod
            return (char.IsUpper(codice_[0]) && Regex.IsMatch(Cod, @"^[0-9]+$"));//se il primo carattere è una lettera maiuscola e gli altri 3 sono numeri allora ritorno true
        }
        //classi interne
        private class Cliente
        {
            string name;// nome del cliente
            string destinazione;// destinazione del viaggio
            Cliente(string aNome, string aDest)
            {
                name = aNome;
                destinazione = aDest;
            }
        }
        private class Coppia : IComparable
        {
            string code;
            Cliente client;
            Coppia(string aCode, Cliente aClient)
            {
                code = aCode;
                client = aClient;
            }
            public int CompareTo(Object obj)
            {
                Coppia tmpC = (Coppia)obj;
                return code.CompareTo(tmpC.code);
            }
        }
        //implemento i metodi del'interfaccia IDictionary
        void IDictionary.Insert(IComparable key, object attribute)
        {
            for (int index = 0; index < dizionario.Count; index++)//scorro il dizionario
            {
                KeyValuePair<string, string> valore = dizionario.ElementAt(index);//salvo l'elemento restituito da ElementAt in posizione index
                if (key.CompareTo(valore.Key) == 0)//se trovo la key nel dizionario
                {
                    //sovrascivo i valori key-value
                    dizionario[valore.Key] = (string)key;
                    dizionario[valore.Value] = (string)attribute;
                }
                else
                    dizionario.Add((string)key, (string)attribute);//sennò lo aggiungo al dizionario
            }
        }
        object IDictionary.Find(IComparable key)
        {
            string[] diz = new string[dizionario.Count];
            dizionario.Keys.CopyTo(diz, 0);//copio le chiavi del dizionario dentro l'array diz
            for (int i = 0; i < diz.Length; i++)//scorro l'array diz
            {
                if (diz[i] == (string)key)//se trovo la key la ritorno
                {
                    return diz[i];
                }
            }
            return new InvalidOperationException();//altrimenti ritorno un'eccezione
        }
        object IDictionary.Remove(IComparable key)
        {
            string attributo = "";
            if (dizionario.ContainsKey((string) key))//se il valore c'è lo salvo sulla variabile attributo e ritorno true
            {
                dizionario.TryGetValue((string)key, out attributo);
                dizionario.Remove((string)key);//rimuovo l'elemento key-value
                return attributo;//ritorno l'attributo
            }
            else
                return new InvalidOperationException();//se è falco ritorno un'eccezione
        }
    }
}