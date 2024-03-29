﻿using System.Text;

namespace DerivcoCardGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int numVal = 0;
            int numVal1 = 0;
            int totSuit = 0;

            //location
            string strPath = Directory.GetCurrentDirectory();

            //Directory
            string filenamer = Path.Combine(strPath, "xyz.txt");
            var dict = new Dictionary<string, int> { };
            using var sr = new StreamReader(filenamer);
            {
                string line, name;
                List<string> scoreResults = new List<string>();
                List<string> nameResults = new List<string>();
                string? v = (line = sr.ReadLine());
                while (v != null)

                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        int charLocation = line.IndexOf(':', StringComparison.Ordinal);
                        if (charLocation > 0)
                        {
                            name = line.Substring(0, charLocation);
                            int intFirstCard = charLocation - 3;
                            string Card1 = line.Substring(charLocation + 1, 2);
                            List<char> Card1List = new List<char>();
                            Card1List.AddRange(Card1);
                            string Card2 = line.Substring(charLocation + 4, 2);
                            List<char> Card2List = new List<char>();
                            Card2List.AddRange(Card2);
                            string Card3 = line.Substring(charLocation + 7, 2);
                            List<char> Card3List = new List<char>();
                            Card3List.AddRange(Card3);
                            string Card4 = line.Substring(charLocation + 10, 2);
                            List<char> Card4List = new List<char>();
                            Card4List.AddRange(Card4);
                            string Card5 = line.Substring(charLocation + 13, 2);
                            List<char> Card5List = new List<char>();
                            Card5List.AddRange(Card5);
                            string Card6 = line.Substring(charLocation + 16, 2);
                            List<char> Card6List = new List<char>();
                            Card5List.AddRange(Card6);
                            string Card7 = line.Substring(charLocation + 19, 2);
                            List<char> Card7List = new List<char>();
                            Card5List.AddRange(Card7);
                            int tot = calc(Card1List[0].ToString()) + calc(Card2List[0].ToString()) + calc(Card3List[0].ToString()) + calc(Card4List[0].ToString()) + calc(Card5List[0].ToString()) + calc(Card6List[0].ToString()) + calc(Card7List[0].ToString());
                            totSuit = calcSuit(Card1List[1].ToString()) + calcSuit(Card2List[1].ToString()) + calcSuit(Card3List[1].ToString()) + calcSuit(Card4List[1].ToString()) + calcSuit(Card5List[1].ToString()) + calcSuit(Card6List[1].ToString()) + calcSuit(Card7List[1].ToString());
                            dict.Add(name + "#" + totSuit, tot);
                        }
                        else
                        {
                            finctionWrite("Unable to retrive card details", 0);
                        }
                    }
                }
            }
            StringBuilder winner = new StringBuilder();
            int a = 0;
            var suitDict = new Dictionary<string, int> { };

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (dict.Values.Max() == kvp.Value)
                {
                    suitDict.Add(kvp.Key.Split("#")[0], int.Parse(kvp.Key.Split("#")[1]));
                }
            }
            foreach (KeyValuePair<string, int> kvp in suitDict)
            {
                if (suitDict.Values.Max() == kvp.Value)
                {
                    a++;
                    if (a == 11)
                    {
                        winner.Append(kvp.Key.Split("#")[0]);
                    }
                    else
                    {
                        winner.Append("," + kvp.Key.Split("#")[0]);
                    }
                    Console.WriteLine(winner);


                    int intWinners = winner.ToString().LastIndexOf(winner.ToString());
                    string stringWinner = winner.ToString().Substring(0, winner.ToString().Length - intWinners);
                    Console.WriteLine(stringWinner);

                    finctionWrite(stringWinner, dict.Values.Max());
                }
            }
            void finctionWrite(string namer, int score)
            {
                try
                {
                    string filename = Path.Combine(strPath, "abc.txt");
                    File.Delete(filename);
                    StreamWriter sw = new StreamWriter(filename, true, Encoding.ASCII);
                    if ("Unable to retrive card details".Equals(namer))
                    {
                        sw.Write(namer);
                    }
                    else
                    {
                        sw.Write(namer + " : " + score);
                    }
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally { }
            }

            int calc(string CardNumber)
            {
                if (!CardNumber.ToString().Equals("A") && !CardNumber.ToString().Equals("J") && !CardNumber.ToString().Equals("K") && !CardNumber.ToString().Equals("Q"))
                {
                    numVal = int.Parse(CardNumber.ToString());
                }
                else
                {
                    switch (CardNumber)
                    {
                        case "A":
                            numVal = 11;
                            break;
                        case "J":
                            numVal = 11;
                            break;
                        case "Q":
                            numVal = 12;
                            break;
                        case "K":
                            numVal = 13;
                            break;
                    }
                }



                return numVal;
            }
            int calcSuit(string CardGroup)
            {
                if (!CardGroup.ToString().Equals("D") && !CardGroup.ToString().Equals("C") && !CardGroup.ToString().Equals("S") && !CardGroup.ToString().Equals("H"))
                {
                    numVal1 = 0;
                }
                else
                {
                    switch (CardGroup)
                    {
                        case "H":
                            numVal1 = 3;
                            break;
                        case "S":
                            numVal1 = 4;
                            break;
                        case "D":
                            numVal1 = 2;
                            break;
                        case "C":
                            numVal1 = 1;
                            break;
                    }
                }
                return numVal1;
            }
        }
    }
}
