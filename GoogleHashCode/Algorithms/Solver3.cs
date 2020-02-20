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

			var realBookScore = input.Libraries.SelectMany(c => c.BookIds.ToList()).GroupBy(c => c)
									 .Select(c => new
												  {
													  Id = c.Key,
													  Score = (decimal)c.Count()
												  })
									 .ToDictionary(c => c.Id, c => c.Score);

			foreach (var library in input.Libraries)
			{
				Out.Libraries.Add(new LibraryAction
								  {
									  BookIDs = library.BookIds.OrderBy(c => realBookScore[c]).ThenByDescending(c => input.BookScores[c]).ToList(),
									  ID = library.Id,
									  BooksPerDay = library.BooksPerDay,
									  SignupDays = library.SignupDays
								  });
			}

			Out.Libraries = Out.Libraries
							   .OrderBy(c => c.SignupDays)
							   .ThenByDescending(c => c.BooksPerDay / (double)c.BookIDs.Count)
							   .ThenBy(c => c.BookIDs
											  .Select(r => realBookScore[r])
											  .Sum(j => j))
							   .ToList();
		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}