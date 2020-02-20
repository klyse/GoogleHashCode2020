using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Model
{
	public class Library
	{
		public int Id { get; set; }
		public int BookCnt { get; set; }
		public int SignupDays { get; set; }
		public int BooksPerDay { get; set; }
		public HashSet<int> BookIds { get; set; } = new HashSet<int>();
	}

	public class Input
	{
		public int BooksCnt { get; set; }
		public int LibrariesCnt { get; set; }
		public int DayCnt { get; set; }
		public int[] BookScores { get; set; }

		public List<Library> Libraries { get; set; } = new List<Library>();

		public static Input Parse(string[] values)
		{
			var input = new Input();

			var splitRow = values.First().Split(' ').Select(int.Parse).ToList();

			input.BooksCnt = splitRow.ElementAt(0);
			input.LibrariesCnt = splitRow.ElementAt(1);
			input.DayCnt = splitRow.ElementAt(2);

			input.BookScores = values.ElementAt(1).Split(' ').Select(int.Parse).ToArray();

			var index = 2;

			while (index < values.Length)
			{
				var firstRow = values[index].Split(' ').Select(int.Parse).ToList();
				var secondRow = values[index + 1].Split(' ').Select(int.Parse).ToHashSet();
				input.Libraries.Add(new Library
									{
										Id = index / 2 - 1,
										BookCnt = firstRow.ElementAt(0),
										SignupDays = firstRow.ElementAt(1),
										BooksPerDay = firstRow.ElementAt(2),
										BookIds = secondRow
									});
				index += 2;
			}

			return input;
		}
	}
}