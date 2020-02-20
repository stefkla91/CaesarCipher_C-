using System;


namespace CeasarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            bool abortSignal = false;
            Console.WriteLine("Welcome to the Ceaser Cipher App!");

            while (!abortSignal)
            {
                Console.WriteLine("What do you want to do ? ");

                Console.WriteLine("\ta - Encode");
                Console.WriteLine("\tb - Decode");
                Console.WriteLine("\tq - Quit");

                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Run(0);
                        break;
                    case "b":
                        Run(1);
                        break;
                    case "q":
                        abortSignal = true;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }
        /// <summary>
        ///     Executes the Encoding/Decoding procedure
        /// </summary>
        /// <param name="mode">Mode input - 0=Encode, 1=Decode</param>
        static void Run(int mode)
        {
            string cipherKeyStr;
            string cipher;
            int cipherKey;

            //read the cipher key
            Console.WriteLine("Please enter a Cipher Key");

            cipherKeyStr = Console.ReadLine();
            //convert the string to and int
            try
            {
                cipherKey = Int32.Parse(cipherKeyStr);
            }
            catch (FormatException e)
            {
                Console.WriteLine("***The Cipher Key must be a number!");
                return;
            }

            Console.WriteLine("Pleaser enter your cipher");
            cipher = Console.ReadLine();

            if (mode == 0) //Encode
            {
                Console.WriteLine("Your Encoded Text is:");
                Console.WriteLine("\n" + applyCipher(cipher, cipherKey) + "\n");
            }
            else if (mode == 1)//Decode
            {
                Console.WriteLine("Your Decoded Text is:");
                Console.WriteLine("\n" + applyCipher(cipher, -cipherKey) + "\n");
            }
        }
        /// <summary>
        ///     Applies the Ceaser Cipher
        ///     
        ///     Encoding and Decoding is the same mathematical process. 
        ///     Only the "direction" of the key changes
        ///     Note: Can be encoded/decoded in either direction by the use of a negative key
        /// </summary>
        /// <param name="text"> The text on which to apply the Cipher</param>
        /// <param name="key"> The cipher Key to apply</param>
        /// <returns></returns>
        static string applyCipher(string text, int key)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            char ch;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsWhiteSpace(text[i]))
                {
                    ch = text[i];
                }
                else if (Char.IsUpper(text[i]))
                {
                    if ((int)text[i] + key < 65)
                    {
                        ch = (char)(((int)text[i] + key - 90) % 26 + 90);
                    }
                    else
                    {
                        ch = (char)(((int)text[i] + key - 65) % 26 + 65);
                    }
                }
                else
                {
                    if ((int)text[i] + key < 97)
                    {
                        ch = (char)(((int)text[i] + key - 122) % 26 + 122);
                    }
                    else
                    {
                        ch = (char)(((int)text[i] + key - 97) % 26 + 97);
                    }
                }

                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }
    }
}
