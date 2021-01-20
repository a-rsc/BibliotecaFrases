using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFrases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        Biblioteca biblioteca;
        List<string> llResultat;
        string frase1, frase2, filename1, pathfilename1, filename2, pathfilename2;

        // Álvaro: Se ejecuta antes de cualquier prueba e inicializa las propiedades que se utilizan en todos los tests
        [TestInitialize]
        public void TestInitialize()
        {
            biblioteca=new Biblioteca();
            llResultat=new List<string>();
        }

        [TestMethod]
        public void paraulesRepetidesTest()
        {
            frase1="Lorem ipsum dolor sit amet consectetur adipiscing elit";
            frase2="ipsum dolor sit hola consectetur elit at conubia fringilla convallis feugiat sem habitant iaculis ac sollicitudin potenti pellentesque mauris";

            string[] resultat = { "ipsum", "dolor", "sit", "consectetur", "elit" };

            llResultat.AddRange(resultat);

            CollectionAssert.AreEqual(llResultat, biblioteca.paraulesRepetides(frase1, frase2));
        }

        [TestMethod]
        public void paraulesRepetidesNullTest()
        {
            frase1="Lorem ipsum dolor sit amet consectetur adipiscing elit.";
            frase2=null;

            string[] resultat = null;

            if(resultat!=null)
            {
                llResultat.AddRange(resultat);
            }

            CollectionAssert.AreEqual(llResultat, biblioteca.paraulesRepetides(frase1, frase2));
        }

        [TestMethod]
        public void paraulesNoRepetidesTest()
        {
            frase1="Lorem ipsum dolor sit amet consectetur adipiscing elit";
            frase2="ipsum dolor sit hola consectetur elit at conubia fringilla convallis feugiat sem habitant iaculis ac sollicitudin potenti pellentesque mauris";

            string[] resultat = new string[] { "Lorem", "amet", "adipiscing", "hola", "at", "conubia", "fringilla", "convallis", "feugiat", "sem", "habitant", "iaculis", "ac", "sollicitudin", "potenti", "pellentesque", "mauris" };

            llResultat.AddRange(resultat);

            CollectionAssert.AreEquivalent(llResultat, biblioteca.paraulesNoRepetides(frase1, frase2));
        }

        [TestMethod]
        public void paraulesNoRepetidesNullTest()
        {
            //string frase1 = "Lorem ipsum dolor sit amet consectetur adipiscing elit";
            //string frase2 = null;

            //string[] resultat = new string[] { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit" };

            frase1=null;
            frase2="ipsum dolor sit hola consectetur elit at conubia fringilla convallis feugiat sem habitant iaculis ac sollicitudin potenti pellentesque mauris";

            string[] resultat = new string[] { "ipsum", "dolor", "sit", "hola", "consectetur", "elit", "at", "conubia", "fringilla", "convallis", "feugiat", "sem", "habitant", "iaculis", "ac", "sollicitudin", "potenti", "pellentesque", "mauris" };

            llResultat.AddRange(resultat);

            CollectionAssert.AreEquivalent(llResultat, biblioteca.paraulesNoRepetides(frase1, frase2));
        }

        [TestMethod()]
        public void paraulesMesRepetidesTest()
        {
            frase1="Lorem ipsum dolor sit amet consectetur adipiscing elit ipsum";
            frase2="consectetur dolor adipiscing elit";

            string[] resultat = new string[] { "adipiscing", "dolor", "consectetur", "elit", "ipsum" };

            llResultat.AddRange(resultat);

            // L'ordre de les paraules amb les mateixes repeticions és imprevissible, caldria un proces que fes aquesta ordenació
            // L'ordre de les úniques sí que es respecte
            CollectionAssert.AreEquivalent(llResultat, biblioteca.paraulesMesRepetides(frase1, frase2));
        }

        [TestMethod()]
        public void paraulesMesRepetidesNullTest()
        {
            frase1="Lorem ipsum dolor sit amet consectetur adipiscing elit ipsum";
            frase2=null;

            string[] resultat = null;

            if(resultat!=null)
            {
                llResultat.AddRange(resultat);
            }

            CollectionAssert.AreEqual(llResultat, biblioteca.paraulesMesRepetides(frase1, frase2));
        }

        [TestMethod()]
        public void ParaulesRepetidesFileTest()
        {
            filename1="file1.txt";
            filename2="file2.txt";

            pathfilename1=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));
            pathfilename2=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename2));

            //Debug.WriteLine(pathFile1);
            //Debug.WriteLine(pathFile2);

            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(pathfilename2, System.Text.Encoding.Default);

            string[] resultat = new string[] { "ipsum", "dolor", "sit", "consectetur", "elit" };

            llResultat.AddRange(resultat);

            CollectionAssert.AreEqual(llResultat, biblioteca.ParaulesRepetidesFile(ref f1, ref f2));
        }

        [TestMethod()]
        public void ParaulesNoRepetidesFileTest()
        {
            filename1="file1.txt";
            filename2="file2.txt";

            pathfilename1=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));
            pathfilename2=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename2));

            //Debug.WriteLine(pathFile1);
            //Debug.WriteLine(pathFile2);

            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(pathfilename2, System.Text.Encoding.Default);

            string[] resultat = new string[] { "Lorem", "amet", "adipiscing", "hola", "at", "conubia", "fringilla", "convallis", "feugiat", "sem", "habitant", "iaculis", "ac", "sollicitudin", "potenti", "pellentesque", "mauris" };

            llResultat.AddRange(resultat);

            CollectionAssert.AreEquivalent(llResultat, biblioteca.ParaulesNoRepetidesFile(ref f1, ref f2));
        }

        [TestMethod()]
        public void paraulesMesRepetidesFileTest()
        {
            filename1="file1Repetides.txt";
            filename2="file2Repetides.txt";

            pathfilename1=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));
            pathfilename2=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename2));

            //Debug.WriteLine(pathFile1);
            //Debug.WriteLine(pathFile2);

            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(pathfilename2, System.Text.Encoding.Default);

            string[] resultat = new string[] { "adipiscing", "dolor", "consectetur", "elit", "ipsum" };

            llResultat.AddRange(resultat);

            // L'ordre de les paraules amb les mateixes repeticions és imprevissible, caldria un proces que fes aquesta ordenació
            // L'ordre de les úniques sí que es respecte
            CollectionAssert.AreEquivalent(llResultat, biblioteca.paraulesMesRepetidesFile(ref f1, ref f2));
        }

        [TestMethod()]
        public void ParaulesFileTest()
        {
            filename1="file1.txt";

            pathfilename1=Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));

            //Debug.WriteLine(pathFile1);

            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);

            frase1 = "Lorem ipsum dolor sit amet consectetur adipiscing elit";

            Assert.AreEqual(frase1, biblioteca.ParaulesFile(ref f1));
        }
    }
}
