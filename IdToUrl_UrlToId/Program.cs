using System;

namespace IdToUrl_UrlToId
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Id to Url and vice-versa!");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Enter the number");
            try
            {
                long number = long.Parse(Console.ReadLine());
                String shortUrl = GetShortUrl(number);
                Console.WriteLine("The ShortUrl is "+shortUrl);

                Console.WriteLine("Printing the original number back");
                Console.WriteLine(GetIdFromUrl(shortUrl));
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }


            Console.ReadLine();
        }

        private static String GetShortUrl(long number) {
            String result = "";

            String stringMap = "abcdefghijklmnopqrstuvwxyz" +
                              "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                              "0123456789";

            char[] charMap = stringMap.ToCharArray();

            while (number != 0) {
                result += charMap[number%62];
                number /= 62;
            }

            char[] resultArray = result.ToCharArray();
            Array.Reverse(resultArray);
            return new string(resultArray);
        }


        private static long GetIdFromUrl(String stringValue) {
            long number = 0;

            char[] values = stringValue.ToCharArray();
;            for (int i = 0; i < stringValue.Length; i++) {
                if (values[i] >= 'a' && values[i] <= 'z') {
                    number = number * 62 + values[i] - 'a';
                }
                if (values[i] >= 'A' && values[i] <= 'Z')
                {
                    number = number * 62 + values[i] - 'A' + 26;
                }
                if (values[i] >= '0' && values[i] <= '9')
                {
                    number = number * 62 + values[i] - '0' + 52;
                }
            }


            return number;
        }

    }
}
