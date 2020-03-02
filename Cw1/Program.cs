using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //  Console.WriteLine("Hello World!");
            //int tmp1 = 1;
            //double tmp2 = 2.0;

            //string tmp3 = "Ala ma kota";
            //bool tmp4 = true;

            //int? tmp5 = null;

            //var tmp6 = 2;

            //Console.WriteLine($"{tmp3} i psa");

            //var path = @"C:\Users\s18788\Desktop\Cw1";

            //var newPerson = new Person { FirstName= "Szymon"};

            var url =args.Length>0 ? args[0]: "https://www.pja.edu.pl";


            using (HttpClient httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {

                            Console.WriteLine(match.ToString());
                        }
                    }
                }

            }
        }

            

        

           
    }
}
