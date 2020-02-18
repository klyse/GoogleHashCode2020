using GoogleHashCode.Base;

namespace GoogleHashCode.Model
{
	public class Output : IOutput
	{
		public int J { get; set; }

		public string[] GetOutputFormat()
		{
			return new[] { J.ToString() };
		}

		public int GetScore()
		{
			return 1;
		}
	}
}