using System;
using GoogleHashCode;
using GoogleHashCode.Algorithms;
using GoogleHashCode.Model;
using NUnit.Framework;

namespace Tests
{
	public class VolkmarsTest
	{
		[Test]
		[TestCase("a_example.txt")]
		[TestCase("b_lovely_landscapes.txt")]
		[TestCase("c_memorable_moments.txt")]
		[TestCase("d_pet_pictures.txt")]
		[TestCase("e_shiny_selfies.txt")]
		public void Solver1(string fileName)
		{
			new Solver1().ExecuteSolver(fileName);
			Assert.Pass();
		}
	}
}