using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading.Tasks;

namespace CampaignMonitorTechTask
{
    class Program
    {
        bool StringCheck(string str)
        {
            bool check;
            if (str != null && str != "")
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;
        }

        List<int> Factors(int num)
        {
            List<int> factors = new List<int>();
            for(int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                    factors.Add(i);
            }
            return factors;
        }

        int CalculateArea(int a, int b, int c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (a + b > c && b + c > a && a + c > b)
                {
                    int halfPeri = (a + b + c) / 2;
                    int area = (int)Math.Sqrt(halfPeri * (halfPeri - a) * (halfPeri - b) * (halfPeri - c));
                    return area;
                }

                else
                {
                    return 0;
                }
            }
            
            else
            {
                return -1;
            }
        }

        List<int> MostCommon(int[] input)
        {
            List<int> result = new List<int>();
            int counter = 0;
            foreach (int a in input)
            {
                int maxOccurrence = input.Count(x => x == a);
                if (maxOccurrence >= counter)
                {
                    result.Add(a);
                    counter = maxOccurrence;
                }
            }
            return result;
        }

        void LinkChecker(string url)
        {
            WebClient client = new WebClient();
            byte[] buffer = client.DownloadData(url);
            string html = System.Text.Encoding.Default.GetString(buffer);
            List<string> htmlList = LinkExtractor(html);
            List<string> validUrls = new List<string>();

            Console.WriteLine("===================================================================================================================");
            Console.WriteLine("Valid URLs are as below:");
            Parallel.ForEach(htmlList, new ParallelOptions() { MaxDegreeOfParallelism = 28 }, linkTest =>
            {
                try
                {
                    var request = WebRequest.Create(linkTest);
                    request.Method = "HEAD";
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.Found))
                        {
                            Console.WriteLine(linkTest);
                        }
                    }
                }

                catch
                {
                }
            });
        }

        public List<string> LinkExtractor (string html)
        {
            List<string> htmlList = new List<string>();
            Regex regex = new Regex("href\\s*=\\s*\"(?<url>.*?)\"", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            if (regex.IsMatch(html))
            {
                foreach (Match match in regex.Matches(html))
                {
                    htmlList.Add(match.Groups[1].Value);
                }
            }
            return htmlList;
        }

        static void Main(string[] args)
        {
            bool check = true;
            Program prog = new Program();
            while(check == true)
            {
                Console.Clear();
                Console.WriteLine("Please Select One of the Following Options");
                Console.WriteLine("Press 1 for Task1");
                Console.WriteLine("Press 2 for Task2");
                Console.WriteLine("Press 3 for Task3");
                Console.WriteLine("Press 4 for Task4");
                Console.WriteLine("Press 5 for Task5");
                Console.WriteLine("Press 0 to Exit");
                var option = Console.ReadKey();
                Console.WriteLine();
                switch(option.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        check = false;
                        break;
                    
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Enter your desired string:");
                            string testString = Console.ReadLine();
                            Console.WriteLine(prog.StringCheck(testString));
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadKey();
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please try again");
                            Console.ReadKey();
                            break;
                        }

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Enter your desired number:");
                            int number = Convert.ToInt32(Console.ReadLine());
                            var tempResult = prog.Factors(number);
                            string answer = String.Join(", ", tempResult.ToArray());
                            Console.WriteLine("{" + answer + "}");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadKey();
                            break;
                        }

                        catch
                        {
                            Console.WriteLine("Enter numbers only, try again. Press Enter");
                            Console.ReadKey();
                            break;
                        }

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Enter first side:");
                            int a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter second side:");
                            int b = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter third side:");
                            int c = Convert.ToInt32(Console.ReadLine());
                            int area = prog.CalculateArea(a, b, c);
                            if (area > 0)
                                Console.WriteLine("The Area is: " + area);
                            if (area == 0 || area == -1)
                                Console.WriteLine("Invalid Triangle Exception");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadKey();
                            break;
                        }
                        
                        catch
                        {
                            Console.WriteLine("Invalid Triangle Exception");
                            break;
                        }

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        int[] arr = { 5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 };
                        Console.WriteLine("The input is: ");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == arr.Length - 1)
                                Console.Write(arr[i]);
                            else
                                Console.Write(arr[i] + ", ");
                        }
                        Console.WriteLine();
                        List<int> tempCommon = prog.MostCommon(arr);
                        HashSet<int> result = tempCommon.ToHashSet();
                        Console.WriteLine("Most Occurred Items are: ");
                        foreach (var i in result)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Please Enter the URL (E.g. http/s://google.com.au):");
                            string url = Console.ReadLine();
                            prog.LinkChecker(url);
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadKey();
                            break;
                        }
                        catch
                        {
                            break;
                        }

                    default:
                        Console.WriteLine("Please Select a proper value");
                        break;
                }
            }


        }
    }
}
