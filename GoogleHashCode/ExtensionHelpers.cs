using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleHashCode
{
	public static class ExtensionHelpers
	{
		public static string[] ReadFromFile(this string fileName)
		{
			var readAllLines = File.ReadAllLines(Path.Combine(EnvironmentConstants.InputPath, fileName));
			return readAllLines;
		}

		public static void WriteToFile(this string fileName, string[] lines)
		{
			File.WriteAllLines(Path.Combine(EnvironmentConstants.OutputPath, fileName), lines);
		}

		public static void WriteToFile(this string fileName, string line)
		{
			WriteToFile(fileName, new List<string> { line }.ToArray());
		}

		public static List<int> ToBookIdList(this IEnumerable<(int id, int score)> idScoreList)
		{
			return idScoreList.Select(q => q.id).ToList();
		}

		
	}
}