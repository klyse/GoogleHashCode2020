using GoogleHashCode.Base;
using GoogleHashCode.Model;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Algorithms
{
	public class Solver4 : ISolver<Input, Output>
	{
		Input In;

		public Output Out { get; set; } = new Output();

		HashSet<int> UsedBooks = new HashSet<int>();
		Dictionary<Library, List<(int id, int score)>> Books;
		int DaysUsed = 0;
		List<Library> Libraries;

		(int score, List<(int id, int score)> books) CalcBestScore(int usedDays, Library library)
		{
			int maxBooks = library.BooksPerDay * (In.DayCnt - library.SignupDays - usedDays);

			var books = Books[library].Where(q => !UsedBooks.Contains(q.id)).ToList();
			if (maxBooks > books.Count)
				maxBooks = books.Count;
			books = books.Take(maxBooks).ToList();
			var score = books.Sum(q => q.score);
			return (score, books);
		}

		void Partition(int skip, int take)
		{
			var libs = In.Libraries.Skip(skip).Take(take).ToList();
			while (libs.Count > 0)
			{
				var best = libs.Select(q => new { lib = q, bs = CalcBestScore(DaysUsed, q) }).OrderByDescending(q => q.bs.score).FirstOrDefault();
				var usedBooks = best.bs.books;
				Out.Libraries.Add(new LibraryAction
				{
					BookIDs = usedBooks.ToBookIdList(),
					ID = best.lib.Id,
					BooksPerDay = best.lib.BooksPerDay,
					SignupDays = best.lib.SignupDays,
				});

				DaysUsed += best.lib.SignupDays;

				libs.Remove(best.lib);

				foreach (var book in usedBooks)
					UsedBooks.Add(book.id);

				if (DaysUsed > In.DayCnt)
					return;
			}
		}

		public void Solve(Input input)
		{
			In = input;
			Out.Input = input;

			Books = input.Libraries.ToDictionary(q => q, q => input.GetBookIdScoreList(q).OrderByDescending(q => q.score).ToList());

			DaysUsed = 0;
			Libraries = In.Libraries.ToList();

			var take = 1000;
			var skip = 0;
			while (skip < Libraries.Count)
			{
				Partition(skip, take);
				skip += take;
			}
		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}