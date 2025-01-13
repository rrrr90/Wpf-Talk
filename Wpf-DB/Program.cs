namespace Wpf_DB
{
    internal class Program
    {
        static readonly Random r = new Random();
        static readonly List<string> words = new List<string>() { "the", "be", "to", "of", "and", "a", "in", "that", "have", "I", "it", "for", "not", "on", "with", "he", "as", "you", "do", "at", "this", "but", "his", "by", "from", "they", "we", "say", "her", "she", "or", "an", "will", "my", "one", "all", "would", "there", "their", "what", "so", "up", "out", "if", "about", "who", "get", "which", "go", "me", "when", "make", "can", "like", "time", "no", "just", "him", "know", "take", "people", "into", "year", "your", "good", "some", "could", "them", "see", "other", "than", "then", "now", "look", "only", "come", "its", "over", "think", "also", "back", "after", "use", "two", "how", "our", "work", "first", "well", "way", "even", "new", "want", "because", "any", "these", "give", "day", "most", "us" };

        // 프로젝트 우클릭 >> 시작 프로젝트로 설정(A)
        static void Main(string[] args)
        {
            //GenerateTalkQuery();
        }

        static void GenerateTalkQuery()
        {
            string baseString = "insert into chatting(sender, recver, message) values(7, 1, 'message');";
            string baseStringWithDate =
                "insert into chatting(sender, recver, message, send_date)" +
                " values(3, 7, 'message', '2025-01-01 10:00:00');";
            int year = 2025, month = 1, day = 1, hour = 09, minute = 00, second = 00;
            for (int i = 0; i < 100; i++)
            {
                // id range 1 ~ 7
                int sender = GetNumber(7);
                int recver;
                string message = GetMessageFromWords();
                while ((recver = GetNumber(7)) == sender) { }

                second += r.Next(10);
                minute += r.Next(10);
                if(second >= 60) { minute += second /= 60; second %= 60; }
                if(minute >= 60) { hour += minute /= 60; minute %= 60; }
                if(hour >= 24) { day += hour /= 24; hour %= 24; }
                if (month == 2 && day >= 29) { month += day / 29; day %= 29; day += 1; }
                if (month == 2 && day >= 31) { month += day / 31; day %= 31; day += 1; }


                Console.WriteLine(
                    $"insert into chatting(sender, recver, message, send_date)" +
                    $" values({sender}, {recver}, '{message}', '{ToFString(year,4)}-{ToFString(month, 2)}-{ToFString(day, 2)} {ToFString(hour, 2)}:{ToFString(minute, 2)}:{ToFString(second, 2)}');");
            }
        }

        static string ToFString(int number, int length)
        {
            char[] format = Enumerable.Repeat('0', length + 4).ToArray();
            format[0] = '{'; format[2] = ':'; format[length + 4 - 1] = '}';
            return string.Format(new string(format), number);
        }

        static int GetNumber(int max)
        {
            return r.Next(max) + 1;
        }

        static char GetChar()
        {
            if (r.Next(10) == 0) return ' ';
            return (char)(r.Next(26) + 'a');
        }

        static string GetMessageFromWords()
        {
            int size = GetNumber(8);
            string message = string.Empty;
            for(int i = 0; i < size; i++)
            {
                message += words[r.Next(100)];
                if (i < size - 1) message += ' ';
            }
            return message;
        }

        static string GetMessage()
        {
            int size = GetNumber(100);
            if (size < 10) size = GetNumber(100);
            char[] mem = new char[size];
            for (int i = 0; i < size; i++)
            {
                mem[i] = GetChar();
            }
            return new string(mem).Trim();
        }
    }
}
