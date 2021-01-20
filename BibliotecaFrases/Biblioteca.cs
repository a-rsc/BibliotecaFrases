using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFrases
{
    public class Biblioteca
    {
        //public List<string> paraulesRepetides(string frase1, string frase2)
        //{
        //    List<string> paraulesFrase1 = new List<string>(frase1.Split(' '));
        //    List<string> paraulesFrase2 = new List<string>(frase2.Split(' '));
        //    List<string> paraulesRepetides = new List<string>();

        //    foreach(string paraula1 in paraulesFrase1)
        //    {
        //        if(paraulesFrase2.Contains(paraula1))
        //        {
        //            paraulesRepetides.Add(paraula1);
        //        }
        //    }

        //    return paraulesRepetides;
        //}

        public List<string> paraulesRepetides(string frase1, string frase2)
        {
            Hashtable frase = new Hashtable();

            List<string> paraulesRepetides = new List<string>();
            List<string> paraulesFrase1;
            List<string> paraulesFrase2;

            if(
                !String.IsNullOrEmpty(frase1) &&
                !String.IsNullOrEmpty(frase2))
            {
                paraulesFrase1 = new List<string>(frase1.Split(' '));
                paraulesFrase2 = new List<string>(frase2.Split(' '));

                foreach(string paraula1 in paraulesFrase1)
                {
                    frase.Add(paraula1, null);
                }

                foreach(string paraula2 in paraulesFrase2)
                {
                    if(frase.ContainsKey(paraula2))
                    {
                        paraulesRepetides.Add(paraula2);
                    }
                }
            }

            return paraulesRepetides;
        }

        public List<string> paraulesNoRepetides(string frase1, string frase2)
        {
            Hashtable frase = new Hashtable();

            List<string> paraulesNoRepetides = new List<string>();
            List<string> paraulesFrase1;
            List<string> paraulesFrase2;

            if(
                !String.IsNullOrEmpty(frase1)&&
                !String.IsNullOrEmpty(frase2))
            {

                paraulesFrase1 = new List<string>(frase1.Split(' '));
                paraulesFrase2 = new List<string>(frase2.Split(' '));

                foreach(string paraula1 in paraulesFrase1)
                {
                    if(!frase.ContainsKey(paraula1))
                    {
                        frase.Add(paraula1, null);
                    }
                }

                foreach(string paraula2 in paraulesFrase2)
                {
                    if(!frase.ContainsKey(paraula2))
                    {
                        frase.Add(paraula2, null);
                    }
                    else
                    {
                        frase.Remove(paraula2);
                    }
                }

                foreach(DictionaryEntry f in frase)
                {
                    paraulesNoRepetides.Add(f.Key.ToString());
                }

            } else if(String.IsNullOrEmpty(frase2))
            {
                paraulesFrase1=new List<string>(frase1.Split(' '));

                foreach(string paraula1 in paraulesFrase1)
                {
                    if(!frase.ContainsKey(paraula1))
                    {
                        frase.Add(paraula1, null);
                    }
                }

                foreach(DictionaryEntry f in frase)
                {
                    paraulesNoRepetides.Add(f.Key.ToString());
                }

            }
            else
            {
                paraulesFrase2=new List<string>(frase2.Split(' '));

                foreach(string paraula2 in paraulesFrase2)
                {
                    if(!frase.ContainsKey(paraula2))
                    {
                        frase.Add(paraula2, null);
                    }
                }

                foreach(DictionaryEntry f in frase)
                {
                    paraulesNoRepetides.Add(f.Key.ToString());
                }
            }

            return paraulesNoRepetides;
        }

        public List<string> paraulesMesRepetides(string frase1, string frase2)
        {
            Hashtable frase = new Hashtable();

            List<string> paraulesMesRepetides = new List<string>();
            List<string> paraulesFrase1;
            List<string> paraulesFrase2;

            if(
                !String.IsNullOrEmpty(frase1)&&
                !String.IsNullOrEmpty(frase2))
            {
                paraulesFrase1=new List<string>(frase1.Split(' '));
                paraulesFrase2=new List<string>(frase2.Split(' '));

                foreach(string paraula1 in paraulesFrase1)
                {
                    if(frase.ContainsKey(paraula1))
                    {
                        frase[paraula1] = Convert.ToString(int.Parse(frase[paraula1].ToString())+1);
                    }
                    else
                    {
                        frase.Add(paraula1, "0");
                    }
                }

                foreach(string paraula2 in paraulesFrase2)
                {
                    if(frase.ContainsKey(paraula2))
                    {
                        frase[paraula2]=Convert.ToString(int.Parse(frase[paraula2].ToString())+1);
                    }
                    else
                    {
                        frase.Add(paraula2, "0");
                    }
                }

                frase.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).ToList();

                foreach(DictionaryEntry f in frase)
                {
                    if(f.Value.ToString() != "0")
                    {
                        paraulesMesRepetides.Add(f.Key.ToString());
                    }
                }
            }

            return paraulesMesRepetides;
        }

        public List<string> ParaulesRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<string> paraulesRepetides = new List<string>();

            string frase1;
            string frase2;

            frase1=ParaulesFile(ref f1);
            frase2=ParaulesFile(ref f2);

            paraulesRepetides=this.paraulesRepetides(frase1, frase2);

            return paraulesRepetides;
        }

        public List<string> ParaulesNoRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<string> paraulesNoRepetides = new List<string>();

            string frase1;
            string frase2;

            frase1=ParaulesFile(ref f1);
            frase2=ParaulesFile(ref f2);

            paraulesNoRepetides=this.paraulesNoRepetides(frase1, frase2);

            return paraulesNoRepetides;
        }

        public List<string> paraulesMesRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<string> paraulesMesRepetides = new List<string>();

            string frase1;
            string frase2;

            frase1=ParaulesFile(ref f1);
            frase2=ParaulesFile(ref f2);

            paraulesMesRepetides=this.paraulesMesRepetides(frase1, frase2);

            return paraulesMesRepetides;
        }

        public String ParaulesFile(ref StreamReader f)
        {
            string paraula, frase = "";

            try
            {
                while(!f.EndOfStream)
                {
                    paraula=f.ReadLine();
                    if(paraula.Trim()!="")
                    {
                        frase += paraula + ' ';
                    }
                }

                frase = frase.Trim();
            }
            catch(Exception)
            {
                throw;
            }

            return frase;
        }
    }
}
