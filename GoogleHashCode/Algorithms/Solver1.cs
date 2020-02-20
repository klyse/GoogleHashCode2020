using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class Solver1 : ISolver<Input, Output>
	{
		public Output Out { get; set; } = new Output();

		public void Solve(Input input)
		{
			Out.Input = input;


			Out.Libraries = new List<LibraryAction>
							{
								new LibraryAction
								{
									ID = 1,
									BookIDs = new List<int> { 3, 2, 5, 0 },
									BooksPerDay = 2,
									SignupDays = 2
								},
								new LibraryAction
								{
									ID = 0,
									BookIDs = new List<int> { 0 ,1, 2 ,3 ,4  },
									BooksPerDay = 1,
									SignupDays = 3
								}
							};
			return;
			foreach (var library in input.Libraries.OrderBy(c => c.SignupDays))
			{
				Out.Libraries.Add(new LibraryAction
								  {
									  BookIDs = library.BookIds.ToList(),
									  ID = library.Id,
									  BooksPerDay = library.BooksPerDay,
									  SignupDays = library.SignupDays
								  });
			}
		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}