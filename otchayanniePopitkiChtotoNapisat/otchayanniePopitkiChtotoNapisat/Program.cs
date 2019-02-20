using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otchayanniePopitkiChtotoNapisat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length.ToString());
            for(int i=0; i<args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            Console.WriteLine("Press any button to continue ");
            Console.ReadKey();
        }
    }
}
