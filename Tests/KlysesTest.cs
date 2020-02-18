using System;
using GoogleHashCode;
using GoogleHashCode.Algorithms;
using GoogleHashCode.Model;
using NUnit.Framework;

namespace Tests
{
	public class KlysesTest
	{
		[Test]
		[TestCase("a_example.txt")]
		[TestCase("b_lovely_landscapes.txt")]
		[TestCase("c_memorable_moments.txt")]
		[TestCase("d_pet_pictures.txt")]
		[TestCase("e_shiny_selfies.txt")]
		public void Solver1(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver1();
			var input = Input.Parse(content);
			solver.Solve(input);
			var output = solver.GetOutput();

			Console.WriteLine($"Total Score: {output.GetScore()}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}
	}
}