using GoogleHashCode.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleHashCode.Model
{
	public class LibraryAction
	{
		public int ID { get; set; }

		public List<int> BookIDs { get; set; } = new List<int>();

		public int SignupDays { get; set; }
		public int BooksPerDay { get; set; }
	}

	public class Output : IOutput
	{
		public List<LibraryAction> Libraries { get; set; } = new List<LibraryAction>();
		public Input Input { get; set; }

		public string[] GetOutputFormat()
		{
			var result = new List<string>();
			result.Add($"{Libraries.Count}");
			foreach (var item in Libraries)
			{
				result.Add($"{item.ID} {item.BookIDs.Count}");
				result.Add($"{string.Join(" ", item.BookIDs)}");
			}

			return result.ToArray();
		}

		public int GetScore()
		{
			var score = 0;
			var alreadyScannedBooks = new HashSet<int>();

			var currentDay = Libraries.ToDictionary(c => c.ID, c => -1);
			var libInSignup = -1;
			for (var day = 0; day < Input.DayCnt; day++)
			{
				bool requestSignupReset = false;
				foreach (var library in Libraries)
				{
					if (currentDay[library.ID] == -1 && libInSignup == -1)
					{
						libInSignup = library.ID;
						currentDay[library.ID] = 0;
					}

					if (currentDay[library.ID] == library.SignupDays)
						requestSignupReset = true;

					var scanDay = currentDay[library.ID] - library.SignupDays;

					if (scanDay > 0 && scanDay < library.BookIDs.Count)
					{
						scanDay -= 1;
						scanDay = scanDay * library.BooksPerDay;
						for (var i = 0; i < library.BooksPerDay && scanDay + i < library.BookIDs.Count; i++)
						{
							var bookId = library.BookIDs[scanDay + i];
							var bookScore = Input.BookScores[bookId];
							if (!alreadyScannedBooks.Contains(bookId))
							{
								alreadyScannedBooks.Add(bookId);
								score += bookScore;
							}
						}
					}


					if (currentDay[library.ID] >= 0)
						currentDay[library.ID] += 1;
				}

				if (requestSignupReset)
					libInSignup = -1;
			}

			return score;
		}
	}
}