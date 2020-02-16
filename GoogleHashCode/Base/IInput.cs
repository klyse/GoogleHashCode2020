namespace GoogleHashCode.Base
{
	public interface IInput<out T>
	{
		T Parse(string[] values);
	}
}