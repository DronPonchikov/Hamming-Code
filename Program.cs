using System;
using System.Linq;
using System.Text;

namespace Hamming_Code
{
    class Program
    {
        public  static  string output =String.Empty;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Encode(input);
            Decode();
            Console.ReadLine();
        }

        public static void Decode()
        {
            string final = String.Empty;
           
            string[] threedigits = new string[output.Length / 3];
            string[] onedigit = new string[output.Length / 3];
            string[] eightdigits = new string[onedigit.Length / 8];
            string concat = String.Empty;
           long [] ascioutput = new long [eightdigits.Length];
            char[] finalarray = new char[eightdigits.Length];

            for (int i = 0; i < output.Length / 3; i++)
            {
                threedigits[i] = output.Substring(3 * i, 3);

                Console.Write(threedigits[i] + " ");
                switch (threedigits[i])
                {
                    case "111":
                    case "101":
                    case "110":
                    case "011":
                        onedigit[i] = "1";

                        break;
                    case "100":
                    case "001":
                    case "010":
                    case "000":
                        onedigit[i] = "0";
                        break;

                }
                Console.WriteLine(onedigit[i]);

                concat += onedigit[i];


               
               
            }
            Console.WriteLine(concat);
            for (int j = 0; j < eightdigits.Length; j++)
            {
                eightdigits[j]= concat.Substring(8 * j, 8);
                Console.WriteLine(eightdigits[j]);
                 ascioutput[j]=Convert.ToInt64(eightdigits[j], 2);
                //Console.WriteLine(ascioutput[j]);
                finalarray[j] =Convert.ToChar(ascioutput[j]);
                final += finalarray[j];
            }
            Console.WriteLine(final);


        }
        public static void Encode(string input)
        {
            byte[] asciicode = Encoding.ASCII.GetBytes(input);
            string[] ascii = new string[asciicode.Length];
            for (int i = 0; i < ascii.Length; i++)
            {
                
                
                    ascii[i] = "0" + Convert.ToString(asciicode[i], 2);
                if (ascii[i].Length<8)
                {
                    ascii[i] = "0" + ascii[i];
                }
               

                Console.WriteLine(ascii[i]);
            }
            
            for (int i = 0; i < ascii.Length; i++)
            {
                foreach (char c in ascii[i].ToString())
                {
                    if (c == '1')
                    {
                        output += "111";

                    }
                    else
                    {
                        output += "000";
                    }
                }
            }
            Console.WriteLine(output);
        }
       





    }
}
    

