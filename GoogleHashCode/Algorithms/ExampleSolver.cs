using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class ExampleSolver : ISolver<Input, Output>
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
									BookIDs = new List<int> { 0, 1, 2, 3, 4 },
									BooksPerDay = 1,
									SignupDays = 3
								}
							};
		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}