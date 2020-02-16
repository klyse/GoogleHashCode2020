using System.IO;
using GoogleHashCode.Base;

namespace GoogleHashCode
{
	public static class EnvironmentConstants
	{
		// ReSharper disable PossibleNullReferenceException
		public static string DataPath => Path.Combine(new FileInfo(typeof(EnvironmentConstants).Assembly.Location).Directory.Parent.Parent.Parent.Parent.ToString(), "Environment");
		// ReSharper restore PossibleNullReferenceException

		public static string InputPath => Path.Combine(DataPath, "Input");
		public static string OutputPath => Path.Combine(DataPath, "Output");
	}
}