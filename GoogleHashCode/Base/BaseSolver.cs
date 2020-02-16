namespace GoogleHashCode.Base
{
	public abstract class BaseSolver<TInput, TOutput> where TInput : IInput, new() where TOutput : IOutput, new()
	{
		public TInput Input { get; } = new TInput();

		public TOutput Output { get; } = new TOutput();

		public abstract void Solve();
	}
}