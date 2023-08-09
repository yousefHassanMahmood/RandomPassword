namespace business
{

    public class RandomsPass
    {
        Random rand = new Random();
        public int Length;
        private string password;

        public RandomsPass(int Length)
        {
            if (Length > 0)
            {
                this.Length = Length;
            }
            else
            {
                this.Length = 10;
            }

            this.password = MakePassword(this.Length);
        }

        private string MakePassword(int length)
        {
            int randValue;
            char letter;
            char[] val = new char[]
            {
              '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
              '-', '=', '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+',
              'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
              '[', ']', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';',
              '\'', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.', '/',
              'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P',
              '{', '}', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', ':',
              'Z', 'X', 'C', 'V', 'B', 'N', 'M', '<', '>', '?', '"'
            };
            //char[] charArr= val.ToCharArray();
            var str = "";

            for (int i = 0; i < length; i++)
            {
                randValue = rand.Next(0, val.Length);
                letter = val[randValue];


                str = str + letter;
            }

            return str;
        }

        public string GetPassword()
        {
            return  password;
        }


    }
    public class LengthException : Exception
    {
        public LengthException()
           : base()
        {
        }
    }
}

