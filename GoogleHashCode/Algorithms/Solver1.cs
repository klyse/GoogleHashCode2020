﻿using System.Linq;
using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class Solver1 : ISolver<Input, Output>
	{
		public Output Out { get; set; } = new Output();

		public void Solve(Input input)
		{
			foreach (var library in input.Libraries)
			{
				Out.Libraries.Add(new LibraryAction
								  {
									  BookIDs = library.BookIds.ToList(),
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