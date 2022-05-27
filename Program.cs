using System.Data;
// TODO: add common weights/lengths etc
// TODO: add volume converter

namespace Calculator
{ 
    public class Calc
    {
        /// <summary>
        /// Basic math calculations
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        static public string Calculate(string inputStr) 
        {
            try
            {
                var _return = new DataTable().Compute(inputStr, null).ToString();
                if (_return == null) { _return = "ERROR: Calc.Calculate"; } // Used to get around "might be null" warning
                return _return;
            }
            catch (System.Data.SyntaxErrorException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: SyntaxErrorException; Don't put letters where they shouldn't be!");
                return "";
            }
            catch (System.Data.EvaluateException)
            {
                // Can cause issues sometimes with changing modes from this point so this check is for that
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: you probably messed up changing modes or something else");
                return "";
            }

        }
        /// <summary>
        ///  Class for Length conversions
        /// </summary>
        public class L
        {
            public static Dictionary<string, float> UnitsToInches = new Dictionary<string, float>(); // 5 * in(1.0f)
            public static List<string> UnitTypes { get; set; } = new List<string>();
            static L()
            {
                // Set up unit conversions
                UnitsToInches["in"] = 1.0f;               // inches
                UnitsToInches["ft"] = 12f;                // feet
                UnitsToInches["yd"] = 36f;                // yards
                UnitsToInches["fth"] = 72f;               // fathoms
                UnitsToInches["mi"] = 63360f;             // miles
                UnitsToInches["nmi"] = 72913.386f;        // nautical mile
                UnitsToInches["nm"] = 0.000000039370079f; // nanometers
                UnitsToInches["um"] = 0.000039370079f;    // picometers
                UnitsToInches["mm"] = 0.039370079f;       // milimeters
                UnitsToInches["cm"] = 0.393701f;           // centimeters
                UnitsToInches["m"] = 39.370079f;            // meters
                UnitsToInches["km"] = 39370.079f;            // kilometers
                UnitsToInches["ly"] = 372500000000000000.0f; // lightyears
                UnitsToInches["lm"] = 708200000000.0f;        // light minutes
                UnitsToInches["ls"] = 11800000000.0f;         // light seconds
                UnitsToInches["au"] = 5890000000000.0f;        // astronomical units
                UnitsToInches["pc"] = 1215000000000000000.0f;   // parsecs
                                                            // lb kg st g t oz mg 

                foreach (var item in UnitsToInches)
                {
                    UnitTypes.Add(item.Key);
                }
            }
            static public float UnitConversion(string input, string[] splitput)
            {
                string unit1;
                string unit2;

                float result;
                float number;


                unit1 = splitput[0];
                unit2 = splitput[1];
                number = float.Parse(splitput[2]);

                result = number * UnitsToInches[unit1];
                result = result / UnitsToInches[unit2];

                return result;
            }
        }
        /// <summary>
        /// Class for Weight conversions
        /// </summary>
        public class W
        {
            public static Dictionary<string, float> UnitsToPounds = new Dictionary<string, float>(); // 5 * in(1.0f)
            public static List<string> UnitTypes { get; set; } = new List<string>();
            static W()
            {
                // Set up unit conversions
                UnitsToPounds["lb"] = 1.0f;               // pounds
                UnitsToPounds["oz"] = 0.0625f;            // ounces
                UnitsToPounds["st"] = 14f;                // stones
                UnitsToPounds["ton"] = 2000f;             // tons
                UnitsToPounds["gr"] = 0.00014285714f;     // grains
                UnitsToPounds["mg"] = 0.0000022046226f;   // milligrams
                UnitsToPounds["g"] = 0.0022046226f;       // grams
                UnitsToPounds["kg"] = 2.2046226f;         // kilograms
                UnitsToPounds["mton"] = 2204.6226f;       // tonnes / metric tons
                UnitsToPounds["lton"] = 2240;             // tons / long tons
                UnitsToPounds["pw"] = 0.0034285714f;      // pennyweight
                UnitsToPounds["toz"] = 0.068571429f;      // troy ounces
                UnitsToPounds["tlb"] = 0.82285714f;        // troy pounds


                foreach (var item in UnitsToPounds)
                {
                    UnitTypes.Add(item.Key);
                }
            }
            static public float UnitConversion(string input, string[] splitput)
            {
                string unit1;
                string unit2;

                float result;
                float number;


                unit1 = splitput[0];
                unit2 = splitput[1];
                number = float.Parse(splitput[2]);

                result = number * UnitsToPounds[unit1];
                result = result / UnitsToPounds[unit2];

                return result;
            }
        }
        /// <summary>
        /// Class for time conversions
        /// </summary>
        public class Ti
        {
            public static Dictionary<string, float> UnitsToSeconds = new Dictionary<string, float>(); // 5 * in(1.0f)
            public static List<string> UnitTypes { get; set; } = new List<string>();
            static Ti()
            {
                // Set up unit conversions
                UnitsToSeconds["ns"]  = 0.000000001f;  // nanoseconds
                UnitsToSeconds["us"]  = 0.000001f;     // microseconds
                UnitsToSeconds["ms"]  = 0.001f;        // milliseconds
                UnitsToSeconds["s"]   = 1f;            // seconds
                UnitsToSeconds["m"]   = 60f;           // minutes
                UnitsToSeconds["h"]   = 3600f;         // hours
                UnitsToSeconds["d"]   = 86400f;        // days
                UnitsToSeconds["w"]   = 604800f;       // weeks
                UnitsToSeconds["mo"]  = 2629746f;      // months
                UnitsToSeconds["y"]   = 31556952f;     // years
                UnitsToSeconds["dec"] = 315569520f;    // decades
                UnitsToSeconds["cen"] = 3155695200f;   // centuries
                UnitsToSeconds["mil"] = 31556952000f;  // millenia


                foreach (var item in UnitsToSeconds)
                {
                    UnitTypes.Add(item.Key);
                }
            }
            static public float UnitConversion(string input, string[] splitput)
            {
                string unit1;
                string unit2;

                float result;
                float number;


                unit1 = splitput[0];
                unit2 = splitput[1];
                number = float.Parse(splitput[2]);

                result = number * UnitsToSeconds[unit1];
                result = result / UnitsToSeconds[unit2];

                return result;
            }
        }
        // Needs some more work, on hold for now
        /*public class T
        {
            public static Dictionary<string, float> UnitsToFahrenheit = new Dictionary<string, float>(); // 5 * in(1.0f)
            public static List<string> UnitTypes { get; set; } = new List<string>();
            static T()
            {
                // Set up unit conversions
                UnitsToFahrenheit["f"] = 1f;       // fahrenheit
                UnitsToFahrenheit["c"] = 33.8f;    // celsius
                UnitsToFahrenheit["k"] = 0.001f;   // kelvin

                foreach (var item in UnitsToFahrenheit)
                {
                    UnitTypes.Add(item.Key);
                }
            }
            static public float UnitConversion(string input, string[] splitput)
            {
                string unit1;
                string unit2;

                float result;
                float number;


                unit1 = splitput[0];
                unit2 = splitput[1];
                number = float.Parse(splitput[2]);

                result = number * UnitsToFahrenheit[unit1];
                result = result / UnitsToFahrenheit[unit2];

                return result;
            }
        }*/
    }
    public static class MainProgram
    {
        public static void PrintHelp()
        {
            FG(ConsoleColor.Yellow);
            Console.WriteLine("Type general or gen or g to enter general calculation mode.");
            Console.WriteLine("Type length or len or l to enter length conversion mode.");
            Console.WriteLine("Type weight or mass or w to enter weight conversion mode.");
            Console.WriteLine("Type time or ti to enter time conversion mode.");
            //Console.WriteLine("Type temperature or temp or t to enter temperature conversion mode.");
            Console.WriteLine("Type 'stop', 's', 'exit', or 'ex'  to quit.");
        }
		/// <summary>
        /// Check if user is trying to change Modes
        /// </summary>
        public static bool ModeChangeCheck(string input)
        { 
            if (input == "general" || input == "gen" || input == "g")
            {
                Mode = "general";
                Console.WriteLine("Entered general calculation mode.");
                Console.WriteLine("Enter numbers to calculate.");
                return true;
            } 
            if (input == "length" || input == "len" || input == "l")
            {
                Mode = "length";
                Console.WriteLine("Entered length conversion mode.");
                Console.WriteLine(String.Format("Enter a combination of {0} to convert between them.", String.Join(", ", Calc.L.UnitTypes)));
                return true;
            } 
            else if (input == "weight" || input == "mass" || input == "w")
            {
                Mode = "weight";
                Console.WriteLine("Entered weight conversion mode.");
                Console.WriteLine(String.Format("Enter a combination of {0} to convert between them.", String.Join(", ", Calc.W.UnitTypes)));
                return true;
            } 
            else if (input == "time" || input == "ti") 
            { 
                Mode = "time";
                Console.WriteLine("Entered time conversion mode.");
                Console.WriteLine(String.Format("Enter a combination of {0} to convert between them.", String.Join(", ", Calc.Ti.UnitTypes)));
                return true;
            } 
            /*else if (input == "temperature" || input == "temp" || input == "t") 
            { 
                Mode = "temp";
                Console.WriteLine("Entered temperature conversion mode.");
                Console.WriteLine(String.Format("Enter a combination of {0} to convert between them.", String.Join(", ", Calc.W.UnitTypes)));
                return true;
            } */
            else { return false; }
        }
        /// <summary>
        /// Changes the background color
        /// </summary>
        /// <param name="color"></param>
        public static void BG(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        /// <summary>
        /// Changes foreground color
        /// </summary>
        /// <param name="color"></param>
        public static void FG(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        static public string Mode = "general";
        public static void Main(string[] args)
        {
            string output = "";


            Console.Title = "CalculatorExtra";
            FG(ConsoleColor.Yellow);
            Console.WriteLine("Enter numbers to calculate.");
            PrintHelp();
            while (true) // Main loop
            {
                FG(ConsoleColor.DarkBlue);
                Console.Write(">> ");
                FG(ConsoleColor.DarkGray);
                var input = Console.ReadLine();
                input = input.ToLower(); // To avoid issues
                var splitput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input == "help")
                {
                    PrintHelp();
                    continue;
                } 
                else if (input == "stop" || input == "exit" || input == "ex" || input == "s")
                {
                    break;
                }
                // Check if user changed mode, if so skip this loop iteration so later code doesnt get confused
                if (ModeChangeCheck(input)) { continue; }
                switch (Mode)
                {
                    case "general":
                        output = Calc.Calculate(input);
                        break;
                    case "length":
                        if (Calc.L.UnitTypes.Contains(splitput[0]) && Calc.L.UnitTypes.Contains(splitput[1]))
                        {
                            output = Calc.L.UnitConversion(input, splitput).ToString();
                        }
                        else
                        {
                            FG(ConsoleColor.Red);
                            Console.WriteLine("ERROR: one or both of the specified unit types do not exist");
                            continue;
                        }
                        break;
                    case "weight":
                        if (Calc.W.UnitTypes.Contains(splitput[0]) && Calc.W.UnitTypes.Contains(splitput[1]))
                        {
                            output = Calc.W.UnitConversion(input, splitput).ToString();
                        }
                        else
                        {
                            FG(ConsoleColor.Red);
                            Console.WriteLine("ERROR: one or both of the specified unit types do not exist");
                            continue;
                        }
                        break;
                    case "time":
                        if (Calc.Ti.UnitTypes.Contains(splitput[0]) && Calc.Ti.UnitTypes.Contains(splitput[1]))
                        {
                            output = Calc.Ti.UnitConversion(input, splitput).ToString();
                        }
                        else
                        {
                            FG(ConsoleColor.Red);
                            Console.WriteLine("ERROR: one or both of the specified unit types do not exist");
                            continue;
                        }
                        break;
                    case "temp":
                        break;
                }
                //if (Char.IsLetter(input.FirstOrDefault()))
                //{
                //    if (Calc.L.UnitTypes.Contains(splitput[0]) && Calc.L.UnitTypes.Contains(splitput[1]))
                //    {
                //        output = Calc.L.UnitConversion(input, splitput).ToString();
                //    } else
                //    {
                //        FG(ConsoleColor.Red);
                //        Console.WriteLine("ERROR: one or both of the specified unit types do not exist");
                //        continue;
                //    }

                //} else
                //{
                //    output = Calc.Calculate(input);
                //}
                FG(ConsoleColor.White);
                Console.WriteLine("\t"+output);
            }
        }
    }
}