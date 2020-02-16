using GoogleHashCode.Base;

namespace GoogleHashCode.Model
{
	public class Input : IInput
	{
		public int I { get; set; }

		public void Parse(string[] values)
		{
			I = 10;
		}
	}
}