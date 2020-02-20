using GoogleHashCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleHashCode.Algorithms
{
    public class Analyzer
    {
        public StringBuilder Result = new StringBuilder ();



        private void Analyze(Input input)
        {

            Result.AppendLine($"Libraries: {input.Libraries.Count}");
            Result.AppendLine($"MinCount Books: {input.Libraries.Min(q => q.BookIds.Count)}");
            Result.AppendLine($"MaxCount Books: {input.Libraries.Max(q => q.BookIds.Count)}");
            Result.AppendLine($"Min Signup Days: {input.Libraries.Min(q => q.SignupDays)}");
            Result.AppendLine($"Max Signup Days: {input.Libraries.Max(q => q.SignupDays)}");

            var uniqueBooks = new HashSet<int>();
            foreach (var item in input.Libraries)
                foreach (var book in item.BookIds)
                    uniqueBooks.Add(book);

            Result.AppendLine($"UniqueBooks: {uniqueBooks.Count}");
        }

        public void Execute(List<string> filenames)
        {

            foreach (var item in filenames)
            {
                Result.AppendLine(item);
                Analyze(Input.Parse(item.ReadFromFile()));
                Result.AppendLine("--");
            }

            "Analyze.txt".WriteToFile(Result.ToString());
        }
    }
}
