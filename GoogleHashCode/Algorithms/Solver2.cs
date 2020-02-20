using GoogleHashCode.Base;
using GoogleHashCode.Model;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Algorithms
{
	public class Solver2 : ISolver<Input, Output>
	{
		public Output Out { get; set; } = new Output();

		public void Solve(Input input)
		{
			foreach (var library in input.Libraries.OrderBy(c => c.SignupDays))
			{
				var books = input.GetBookIdScoreList(library);

				Out.Libraries.Add(new LibraryAction
				{
					BookIDs = books.OrderByDescending(q => q.score).ToBookIdList(),
					ID = library.Id
				});
			}

		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}