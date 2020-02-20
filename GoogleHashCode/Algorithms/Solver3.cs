using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class Solver3 : ISolver<Input, Output>
	{
		public Output Out { get; set; } = new Output();

		public void Solve(Input input)
		{
			Out.Input = input;

			var usedBooks = new HashSet<int>();
			foreach (var library in input.Libraries
										 .OrderBy(c => c.SignupDays)
										 .ThenByDescending(c => c.BookIds.Select(r => input.BookScores[r]).Sum(r => r)))
			{
				var l = new LibraryAction
						{
							BookIDs = library.BookIds.Except(usedBooks).OrderByDescending(c => input.BookScores[c]).ToList(),
							ID = library.Id,
							BooksPerDay = library.BooksPerDay,
							SignupDays = library.SignupDays
						};

				if (l.BookIDs.Any())
					Out.Libraries.Add(l);

				usedBooks.UnionWith(l.BookIDs);
			}

			Out.Libraries = Out.Libraries
							   .OrderByDescending(c => c.BookIDs
														.Select(j => input.BookScores[j])
														.Sum(q => q))
							   .ToList();
		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}