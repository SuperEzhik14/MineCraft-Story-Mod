using System.Reflection.Metadata;

namespace RedBull
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Masiv(5,1,3,     123,456,678,8908,07897);
        }       
        static void Masiv(int num,int num2,int num3,params int[] masiv)
        {
            int[] result = new int[masiv.Length - 3];
            int index = 0;
            for (int i = 0;i < masiv.Length; i++,index++)
            {
                if (i == num - 1 || i == num2 - 1 || i == num3 - 1)
                {
                    index--;
                    continue;
                }
                result[index] = masiv[i];
            }
            masiv = result;
            


            for (int i = 0;i < masiv.Length; i++)
            {
                Console.Write(masiv[i] + ".");
            }
        }
    }
}
