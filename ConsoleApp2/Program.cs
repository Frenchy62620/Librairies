using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public class Program
    {

        private static char lastchar;
        private static string playing;
        private static int nbr;
        private static int reste;
        private static Stopwatch w = new Stopwatch();
        private static Dictionary<char, (long t, string s)> dicoFC = new Dictionary<char, (long t, string s)>();
        private static Dictionary<char, (long t, string s)> dicoLC = new Dictionary<char, (long t, string s)>();
        private static int nbrLC = 0;
        private static int nbrFC = 0;
        private static bool diff = false;

        private static string[] inputsToTest = new string[]
        {
            "hare3,bee,cat,eagle;eagle!",
            "hare,3,bee,cat,eagle;eagle!",
            "ae,2,e,er;er!",
            //"ae,2,ere,e;ere",
            //"ae,3,er,e,ere;er!",
            //"pig,2,goat,toab;goat",
            //"ae,3,ree,ere,eer;ere",
            //"ae,3,eer,ere,ree;eer",
            //"ae,3,ere,eer,ree;ere",

            //"dog,2,snake,emu;?",

            //"ae,4,e,ee,eee,eeee;e",
            //"ae,4,er,e,ee,eee;er!",
            //"ae,4,er,e,ee,ree;er",
            //"ae,4,er,e,re,ree;er"
        };
        public static void Main(string[] args)
        {

            simulateInput();
            Console.ReadKey();
        }
        private static void simulateInput()
        {
            var cr = Environment.NewLine;

            foreach (var line in inputsToTest)
            {
                var sb = new StringBuilder();
                var reps = line.Split(';');
                var reponse = reps.Last();
                var test = reps.First();
                var values = string.Join(cr, test.Split(','));

                using (StreamReader reader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(values + cr))))
                using (var writer = new StringWriter(sb))
                {
                    var final = $"{test} -> {reponse} result: ";
                    Console.SetIn(reader);
                    Console.SetOut(writer);

                    testProblem(line);

                    //redirect Console.SetOut to standard Output
                    var standardOutput = new StreamWriter(Console.OpenStandardOutput());
                    standardOutput.AutoFlush = true;
                    Console.SetOut(standardOutput);
                    //answer of the test in var result
                    var result = sb.ToString().Split(new[] { cr }, StringSplitOptions.None)[0];
                    Console.WriteLine($"{final}{result} // {result == reponse} nbFC {nbrFC} nbLC {nbrLC}");
                }
            }
        }
        private static void oneline()
        {
            var cr = Environment.NewLine;
            foreach (var line in inputsToTest)
            {
                using (StreamReader reader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(line + cr))))
                {
                    Console.Write(line + " -> ");
                    Console.SetIn(reader);
                    testProblem(line);
                }
            }
        }
        private static void InitVar()
        {
            lastchar = ' ';
            playing = "?";
            reste = -1;
            nbr = -1;
            dicoFC.Clear();
            dicoLC.Clear();
            nbrFC = 0;
            nbrLC = 0;
        }
        private static bool isEqual(char k)
        {
            if (dicoFC.TryGetValue(k, out var tfc) && dicoLC.TryGetValue(k, out var lfc))
                return tfc.t == lfc.t;
            return false;
        }

        private static void testProblem(string line)
        {
            while ((line = Console.ReadLine()) != null)
            {
                Console.WriteLine($"while {line}");
                continue;
                var value = line.Trim();
                if (lastchar != ' ' && nbr < 0)
                {
                    nbr = int.Parse(value);
                    w.Restart();
                    reste = nbr;
                }
                else
                {
                    if (lastchar == ' ')
                        lastchar = value.Last();
                    else
                    {
                        reste--;

                        var fc = value[0];
                        var lc = value.Last();

                        if (playing == "?" && fc == lastchar)
                            playing = value;

                        if (fc == lastchar)
                        {
                            if (fc == lc)
                            {
                                (long, string) dfc = (0, null);
                                (long, string) dlc = (0, null);
                                dicoFC.TryGetValue(fc, out dfc);
                                dicoLC.TryGetValue(fc, out dlc);
                                if (!dicoFC.ContainsKey(fc) && !dicoLC.ContainsKey(fc))
                                {
                                    dicoLC.Add(fc, (w.ElapsedTicks, $"{value}!"));
                                    dicoFC.Add(fc, dicoLC[fc]);
                                    nbrLC++;
                                }
                                else if (!dicoFC.ContainsKey(fc))
                                {
                                    dicoFC.Add(fc, (w.ElapsedTicks, $"{value}!"));
                                    nbrFC++;
                                    diff = true;
                                }
                                else if (!dicoLC.ContainsKey(fc))
                                {
                                    dicoLC.Add(fc, (w.ElapsedTicks, $"{value}!"));
                                    nbrLC++;
                                    diff = true;
                                }
                                else
                                {
                                    if (dlc.Item1 * dfc.Item1 != 0 && dlc.Item1 == dfc.Item1)
                                    {
                                        dicoFC[fc] = (w.ElapsedTicks, $"{value}!");
                                        nbrLC++;
                                        diff = true;
                                    }
                                }
                            }
                            else //fc != lc
                            {
                                if (!diff)
                                {
                                    dicoFC[fc] = (w.ElapsedTicks, $"{value}!");
                                    nbrFC++;
                                    diff = true;
                                }
                                if (!dicoLC.ContainsKey(lc))
                                {
                                    dicoLC.Add(lc, (w.ElapsedTicks, $"{value}!"));
                                    nbrLC++;
                                }
                            }
                        }
                        else if (!dicoFC.ContainsKey(fc))
                        {
                            dicoFC.Add(fc, (w.ElapsedTicks, $"{value}!"));
                            nbrFC++;
                        }
                    }
                }
                if (reste == 0)
                {
                    if (!diff) dicoFC.Remove(lastchar);
                    var ef = dicoLC.Where(c => !dicoFC.ContainsKey(c.Key))
                                   .OrderBy(x => x.Value.t)
                                   .Select(x => x.Value.s)
                                   .FirstOrDefault();

                    Console.WriteLine(ef != null ? ef : playing);
                    w.Stop();
                }
            }
        }
    }
}


