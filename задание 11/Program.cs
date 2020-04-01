using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание_11
{
    public class Program
    {
        static void Main(string [] args)
        {
            Console.WriteLine("«Исправление ошибок». Пусть по некоторому каналу связи передается сообщение, имеющее вид последовательности нулей и единиц (или, аналогично, точек и тире). Из-за помех возможен ошибочный прием некоторых сигналов: нуль может быть воспринят как единица и наоборот. Можно передавать каждый сигнал трижды, заменяя, например, последовательность 1, 0, 1 последовательностью 1.1,1,0,0,0,1,1,1. Три последовательные цифры при расшифровке заменяются той цифрой, которая встречается среди них по крайней мере дважды. Такое утраивание сигналов существенно повышает вероятность правильного приема сообщения. Написать программу расшифровки.");
            const int copySym = 3;
            Console.WriteLine("\nВходной алфавит состоит из символов 0 и 1.");
            char[] inputAlphabet = new char[2] { '0', '1' };
            string inputString=InsertStringOfTheAlphabet(inputAlphabet, "\nВведите полученное сообщение: ");
            List<string> list = GetNextChars(inputString, copySym);
            string answer = string.Empty;
            foreach (string name in list)
                answer+=DecodeString(name)+"  ";
            Console.WriteLine("\nРасшифрованное сообщение:\n"+ answer);
            Console.ReadKey();
        }

        static string InsertStringOfTheAlphabet(char [] inputAlphabet, string message)
        {
            string inputString;
            bool ok = true;
            Console.WriteLine(message);
            do
            {
                if (!ok)
                    Console.WriteLine($"Сообщение может содержать только символы входного алфавита." +
                        $" Повторите ввод: ");
                inputString = Console.ReadLine();
                ok = NormalString(inputString, inputAlphabet);
            } while (!ok);
            return inputString;
        }

        public static char DecodeString(string letter)
        {
            if (letter.Length==2)
                return letter[0];

            if (letter.Length == 1 || letter[0] == letter[1] || letter[0] == letter[2])
                return letter[0];
            return letter[1];
        }

        public static List<string> GetNextChars(string str, int iterateCount)
        {
            var words = new List<string>();

            for (int i = 0; i < str.Length; i += iterateCount)
                if (str.Length - i >= iterateCount)
                    words.Add(str.Substring(i, iterateCount));
                else
                    words.Add(str.Substring(i, str.Length - i));

            return words;
        }

        public static bool NormalString(string insertString, char [] inputAlphabet)
        {
            foreach (char letter in insertString)
                if (!inputAlphabet.Contains(letter))
                    return false;
            return true;
        }
    }
}
