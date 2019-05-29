using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    class WarCardGame
    {
        public static ArrayList cardList = new ArrayList();
        public static ArrayList pA = new ArrayList();
        public static ArrayList pB = new ArrayList();
        public static ArrayList pAWar = new ArrayList();
        public static ArrayList pBWar = new ArrayList();

        public static bool a = true;

        public static ArrayList ShuffleList(ArrayList source)
        {
            ArrayList randomList = new ArrayList();
            Random r = new Random();
            int randomIndex = 0;
            while (source.Count > 0)
            {
                randomIndex = r.Next(0, source.Count); //Choose a random object in the list
                randomList.Add(source[randomIndex]); //add it to the new, random list
                source.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            foreach (int b in randomList)
            {
                Debug.Write(b + " ");
            }
            return randomList; //return the new random list
        }

        public static void AssignDecks()
        {
            foreach (int b in cardList)
            {

                if (a)
                {
                    pA.Add(b);
                    a = false;
                }
                else
                {
                    pB.Add(b);
                    a = true;
                }
            }
            Debug.WriteLine("Deck 1: \n");
            foreach (int b in pA)
            {
                Debug.Write(b + " ");
            }
            Debug.WriteLine("\n\nDeck 2: \n");
            foreach (int b in pB)
            {
                Debug.Write(b + " ");
            }


            
        }

        static void Main(string[] args)
        {
            bool winner = false;
            for (int i = 1; i < 5; i++)
            {
                for (int e = 1; e < 14; e++)
                {
                    cardList.Add(e);
                }
            }

            Debug.WriteLine(cardList.Count);

            Debug.WriteLine("\n");
            cardList = ShuffleList(cardList);
            Debug.WriteLine("\n");

            AssignDecks();

            int aFirst = 0;
            int bFirst = 0;

            int counter = 0;
            while (!winner)
            {
                Debug.WriteLine("\n");
                aFirst = (int)pA[0];
                bFirst = (int)pB[0];
                Debug.WriteLine(aFirst + " " + bFirst);

                //Deck 1 won battle
                if (aFirst > bFirst)
                {

                    pB.RemoveAt(0);
                    pA.Add(bFirst);
                    pA.Remove(aFirst);
                    pA.Add(aFirst);
                    Debug.WriteLine("DECK ONE");

                }

                else if (aFirst == bFirst)
                {

                    Debug.WriteLine("TIE TIE TIE ");

                    Debug.WriteLine(" aFirst " + aFirst);
                    Debug.WriteLine(" bFirst " + bFirst);
                    //pA.Remove(aFirst);
                    //pA.Add(aFirst);

                    for (int i = 1; i <= 3; i++)
                    {
                        pAWar.Add(pA[i]);
                        pBWar.Add(pB[i]);
                        
                    }
                    Debug.WriteLine("pAWar");
                    foreach (int g in pAWar)
                    {
                        Debug.Write(" " + g);
                    }
                    Debug.WriteLine("\npBWar");

                    foreach (int g in pBWar)
                    {
                        Debug.Write(" " + g);
                    }

                    pA.RemoveAt(0);
                    pB.RemoveAt(0);

                    if ((int)pAWar[2] > (int)pBWar[2])
                    {


                        Debug.WriteLine("Deck One Won");
                        for (int d = 0; d < 3; d++)
                        {
                            pA.Add(pAWar[d]);
                            pA.Add(pBWar[d]);

                            pA.Remove(pA[d]);
                            pB.Remove(pB[d]);
                        }


                    }
                    else if ((int)pAWar[2] < (int)pBWar[2])
                    {
                        Debug.WriteLine("Deck One Won");
                        for (int d = 0; d < 3; d++)
                        {
                            pB.Add(pAWar[d]);
                            pB.Add(pBWar[d]);

                            pA.Remove(pA[d]);
                            pB.Remove(pB[d]);
                        }

                    }
                    pAWar.Clear();
                    pBWar.Clear();
                    Debug.WriteLine("\npA[0] " + pA[0]);
                    Debug.Write(" pB[0] " + pB[0] + "\n");
                }
                //Deck 2 won battle
                else if (bFirst > aFirst)
                {
                    pA.RemoveAt(0);
                    pB.Add(aFirst);
                    pB.Remove(bFirst);
                    pB.Add(bFirst);
                    Debug.WriteLine("DECK TWO");

                }

                if (pA.Count <= 1)
                {
                    Debug.WriteLine("\nPLAYER 2 WON");
                    winner = true;
                }
                else if (pB.Count <= 1)
                {
                    Debug.WriteLine("\nPLAYER 1 WON");
                    winner = true;
                }

                Debug.WriteLine("\npA-----------------");

                foreach (int g in pA)
                {
                    Debug.Write(" " + g);
                }

                Debug.WriteLine("\npB-----------------");
                foreach (int g in pB)
                {
                    Debug.Write(" " + g);
                }
                counter += 1;
                Debug.WriteLine(" COUNTER: " + counter);
                Debug.WriteLine("Deck One Count: " + pA.Count);
                Debug.WriteLine("Deck Two Count: " + pB.Count);

                //if (counter >= 50)
                //{
                //    winner = true;
                //}
            }


            Environment.Exit(0);
            //HOLDS CONSOLE OPEN
            //Console.ReadKey();
        }
    }
}
