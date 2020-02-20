using System;
using System.Collections.Generic;
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
        [TestCase("b_read_on.txt")]
        [TestCase("c_incunabula.txt")]
        [TestCase("d_tough_choices.txt")]
        [TestCase("e_so_many_books.txt")]
        [TestCase("f_libraries_of_the_world.txt")]
        public void Solver1(string example)
        {
            var content = example.ReadFromFile();
            var solver = new Solver2();
            var input = Input.Parse(content);
            solver.Solve(input);
            var output = solver.GetOutput();

            Console.WriteLine($"Total Score: {output.GetScore()}");
            example.WriteToFile(output.GetOutputFormat());
            Assert.Pass();
        }


        [Test]
        public void Analyze()
        {
            new Analyzer().Execute(new List<string>
            {
                "a_example.txt",
                "b_read_on.txt", "c_incunabula.txt", "d_tough_choices.txt", "e_so_many_books.txt", "f_libraries_of_the_world.txt"
            });

            Assert.Pass();
        }


    }
}