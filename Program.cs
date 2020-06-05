using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PIWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPrime(int sayi)
            {
                if (sayi == 1)
                {
                    return false; //non prime
                }
                else
                {
                    int n, i, m = 0;
                    n = sayi;
                    m = n / 2;
                    for (i = 2; i <= m; i++)
                    {
                        if (n % i == 0)
                        {
                            return false;   //non prime
                        }
                    }
                    return true;        //prime
                }
            }

            int satir_sayisi = 0;
            string[] s = File.ReadAllLines("input.txt", Encoding.UTF8); //reading file
            foreach (var satir in s)
            {
                Console.WriteLine(satir);                               //writing down the content of the file
                satir_sayisi++;                                         //recording number of line
            }

            int[,] matris = new int[satir_sayisi, satir_sayisi];        //creating square matris

            for (int satirlar = 0; satirlar < satir_sayisi; satirlar++)
            {
                for (int sutunlar = 0; sutunlar < satirlar + 1; sutunlar++)
                {
                    //splitting s[satirlar] line to throw each element to matris[satirlar, sütunlar]
                    matris[satirlar, sutunlar] = Convert.ToInt32(s[satirlar].Split(' ')[sutunlar]);
                }
            }
            Console.WriteLine("\nCREATED MATRIS");
            for (int i = 0; i < satir_sayisi; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < satir_sayisi; j++)
                {
                    Console.Write(matris[i, j] + " ");
                }
            }

            bool[,] secim = new bool[satir_sayisi, satir_sayisi];
            int en_buyuk;
            int en_buyuk_sutunu = 0;   //I use this to choose wich columns will I use in the next line
            int temp = 0;              //to keep sutun i have to use 

            secim[0, 0] = true;         //choosing top element of the triangle

            int sum = matris[0, 0];      //also sum supposed to start with first element because in the loop, we wont check it
            for (int satir = 1; satir < satir_sayisi; satir++)  //checking all lines
            {
                en_buyuk = 0;
                for (int sutun = en_buyuk_sutunu - 1; sutun <= en_buyuk_sutunu + 1; sutun++)
                {
                    if (sutun >= 0 && sutun <= satir_sayisi && !isPrime(matris[satir, sutun]))
                    {
                        if (matris[satir, sutun] > en_buyuk)
                        {
                            en_buyuk = matris[satir, sutun];
                            temp = sutun;
                        }
                    }
                    else continue;
                }
                secim[satir, temp] = true;      //keeping all the matris elements that i have choosed
                sum += matris[satir, temp];
                en_buyuk_sutunu = temp;
            }

            Console.WriteLine("\n\nSELECTED MATRIS ELEMENTS ");
            for (int i = 0; i < satir_sayisi; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < satir_sayisi; j++)
                {
                    Console.Write(secim[i, j] + " ");
                }
            }

            Console.WriteLine("\n\nANSWER: " + sum);


            Console.ReadKey();
        }

    }
}
