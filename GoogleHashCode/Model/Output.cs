using GoogleHashCode.Base;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode.Model
{

	public class Library
	{
		public int ID { get; set; }

		public List<int> BookIDs { get; set; } = new List<int>();

	}
	public class Output : IOutput
	{
		public List<Library> Libraries { get; set; } = new List<Library>();

		public string[] GetOutputFormat()
		{
			var result = new List<string>();
			result.Add($"{Libraries.Count}");
			foreach (var item in Libraries)
			{
				result.Add($"{item.ID} {item.BookIDs.Count}");
				result.Add($"{string.Join(" ", item.BookIDs)}");
			}

			return result.ToArray();
		}

		public int GetScore()
		{
			return 1;
		}
	}
}