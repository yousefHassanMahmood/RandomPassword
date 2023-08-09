using business;

namespace RandomPassword
{
    class Program
    {
        static void Main(string[] args)
        {
        loop:
            Console.Write("Enter the length of the password: ");
            try
            {
                var lengthPass = Convert.ToInt32(Console.ReadLine());
                if (lengthPass > 1000)
                {
                    throw new LengthException();
                }
                var randomPass = new RandomsPass(lengthPass);
                Console.WriteLine($"Your password is: {randomPass.GetPassword()}");
                Console.WriteLine("Enter 1 to repeat");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    Console.Clear();
                    goto loop;
                }


            }
            catch (Exception ex)
            {
                if (ex is LengthException)
                {
                    Console.WriteLine($"Your password length is too long");
                    Console.WriteLine("press anykey to repeat");
                    Console.ReadKey();
                    Console.Clear();
                    goto loop;
                }
                else
                {
                    Console.WriteLine($"Error, you didn't enter any value or wrong format.{ex}");
                    Console.WriteLine("press anykey to repeat");
                    Console.ReadKey();
                    Console.Clear();
                    goto loop;
                }

            }



        }
    }



}