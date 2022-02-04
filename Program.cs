using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string text;
            string action = "";
            string choice = "";
            bool cipherFlag = true;
            int optionFlag =-1; // just used arbitrary number to instantiat
            
            while(optionFlag != 0)
            {

                Console.WriteLine("Please enter 1 to encrypt or 2 to decrypt or 0 to exit:");
                //make all inputs lowercase
                choice = Console.ReadLine().ToLower();
                
                //verify they only use correct option numbers
                if (choice.Equals("0") || choice.Equals("1") || choice.Equals("2"))
                {
                    optionFlag = Int32.Parse(choice);

                    if (optionFlag == 0)
                    {
                        Console.WriteLine("Program Terminated.");
                        break;
                    }
                    else if (optionFlag == 1)
                    {
                        cipherFlag = true;
                        action = "encrypt";
                    }
                    else if (optionFlag == 2)
                    {
                        cipherFlag = false;
                        action = "decrypt";
                    }                    

                    Console.WriteLine($"Please enter text to be {action}:");
                    text = Console.ReadLine();
                    //Print out the results of the decrypting or encrypting
                    Console.WriteLine(Cipher(text, alphabet, cipherFlag));
                }
                //if not repeat loop
                else
                {
                    Console.WriteLine("Please try again, incorrect input.");
                    continue;
                }
            }            
        }

        static string Cipher(string text, char[] alph, bool flag)
        {
            //input array
            char[] secretMessage = text.ToCharArray();
            //output arra
            char[] newMessage = new char[secretMessage.Length];

            //if flag == true then we encrypt
            if (flag)
            {
                for (int i = 0; i < secretMessage.Length; i++)
                {
                    char temp = secretMessage[i];
                    int index = ((Array.IndexOf(alph, temp) + 3) % alph.Length);
                    newMessage[i] = alph[index];
                }
                
            }
            //if flag set to false then we decrypt
            else if (!flag)
            {
                for (int i = 0; i < secretMessage.Length; i++)
                {
                    char temp = secretMessage[i];
                    int index = Array.IndexOf(alph, temp);

                    if (index < 3)
                    {
                        index = 25 - index;                        
                    }
                    else
                    {
                       index -= 3;
                    }

                    newMessage[i] = alph[index];
                }
            }

            //transform the char[] into a string
            string cipherdMessage = String.Join("", newMessage);
            return cipherdMessage;

        }

    }
}