using GoogleHashCode.Base;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode.Model
{

	public class LibraryAction
	{
		public int ID { get; set; }

		public List<int> BookIDs { get; set; } = new List<int>();

	}
	public class Output : IOutput
	{
		public List<LibraryAction> Libraries { get; set; } = new List<LibraryAction>();

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