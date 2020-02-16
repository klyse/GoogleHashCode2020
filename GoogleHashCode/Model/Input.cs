namespace GoogleHashCode.Model
{
	public class Input
	{
		public int I { get; set; }

		public static Input Parse(string[] values)
		{
			var input = new Input();

			input.I = 10;

			return input;
		}
	}
}