using System;

namespace Program
{
    public class PasswordCheck
    {
        public static void Main(string[] args)
        {
            bool truth = true;
            while (truth)
            {

                Console.Write("Please Enter Your Password (At Least 6 Characters) : ");
                string password = Console.ReadLine();

                bool passwordLengthQualification = passwordLengthCheck(password);
                int numberInPassword = passwordNumberCheck(password);
                int characterInPassword = passwordCharacterCheck(password);
                int punctuationMarksInPassword = passwordPunctuationMarkCheck(password);

                if(passwordLengthQualification == false ) {
                    Console.WriteLine("Password length is not enough ");
                    Console.WriteLine();
                }
                else if(numberInPassword == password.Length || characterInPassword == password.Length) {
                    Console.WriteLine("Your password is weak. Your password cannot be numbers or characters only");
                    Console.WriteLine();
                }
                else if(numberInPassword > 0 && characterInPassword > 0 && punctuationMarksInPassword == 0) {
                    Console.WriteLine("Your password has medium security");
                    truth = false;
                }
                else if(numberInPassword > 0 && characterInPassword > 0 && punctuationMarksInPassword > 0)
                {
                    Console.WriteLine("Your password is highly secure :)");
                    truth = false;
                }
            }
        }

        public static bool passwordLengthCheck(string password)
        {
            bool truth = true;
            if(password.Length < 6) {
                truth= false;
            }
            return truth;
        }

        public static int passwordNumberCheck(string password)
        {
            int numberOfNumbers = 0;
            char[] num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] passwordCharacters = password.ToCharArray(); 
            for(int charactIndex = 0; charactIndex < passwordCharacters.Length; charactIndex++)
            {
                for(int numIndex = 0; numIndex < num.Length; numIndex++)
                {
                    if (passwordCharacters[charactIndex] == num[numIndex])
                    {
                        numberOfNumbers++;
                    }
                }
            }
            return numberOfNumbers;
        }

        public static int passwordCharacterCheck(string password)
        {
            int numberOfCharacter=0;
            char[] charact = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoprstuvyz".ToCharArray();
            char[] passwordCharacters = password.ToCharArray() ;
            for (int charactIndex = 0; charactIndex < passwordCharacters.Length; charactIndex++)
            {
                for (int numIndex = 0; numIndex < charact.Length; numIndex++)
                {
                    if (passwordCharacters[charactIndex] == charact[numIndex])
                    {
                        numberOfCharacter++;
                    }
                }
            }
            return numberOfCharacter;
        }

        public static int passwordPunctuationMarkCheck(string password)
        {
            int numberOfPunctuationMark = 0;
            char[] punctuationMarks = "!'^+#$%&/()[]{}=?-_.:,;<|>*".ToCharArray();
            char[] passwordCharacters = password.ToCharArray();
            for (int charactIndex = 0; charactIndex < passwordCharacters.Length; charactIndex++)
            {
                for (int numIndex = 0; numIndex < punctuationMarks.Length; numIndex++)
                {
                    if (passwordCharacters[charactIndex] == punctuationMarks[numIndex])
                    {
                        numberOfPunctuationMark++;
                    }
                }
            }
            return numberOfPunctuationMark;
        }
    }
}