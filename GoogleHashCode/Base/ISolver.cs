namespace GoogleHashCode.Base
{
	public interface ISolver<in TInput, out TOutput>
	{
		void Solve(TInput input);
		TOutput GetOutput();
		int GetScore();
	}
}