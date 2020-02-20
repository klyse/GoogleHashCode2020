using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class Solver2 : ISolver<Input, Output>
	{
		public Output Out { get; set; } = new Output();

		public void Solve(Input input)
		{
			Out.J = input.I;
		}

		public Output GetOutput()
		{
			return Out;
		}
	}
}