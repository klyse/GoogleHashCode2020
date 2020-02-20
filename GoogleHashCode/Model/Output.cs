using GoogleHashCode.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleHashCode.Model
{
    public class LibraryAction
    {
        public int ID { get; set; }

        public List<int> BookIDs { get; set; } = new List<int>();

        public int SignupDays { get; set; }
        public int BooksPerDay { get; set; }
    }

    public class Output : IOutput
    {
        public List<LibraryAction> Libraries { get; set; } = new List<LibraryAction>();
        public Input Input { get; set; }

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
			var score = 0;
			var alreadyScannedBooks = new HashSet<int>();

			var currentDay = Libraries.ToDictionary(c => c.ID, c => -1);
			var libInSignup = -1;
			for (var day = 0; day < Input.DayCnt; day++)
			{
				bool requestSignupReset = false;
				foreach (var library in Libraries)
				{
					if (currentDay[library.ID] == -1 && libInSignup == -1)
					{
						libInSignup = library.ID;
						currentDay[library.ID] = 0;
					}

					if (currentDay[library.ID] == library.SignupDays - 1)
						requestSignupReset = true;

					var scanDay = currentDay[library.ID] - library.SignupDays + 1;

					if (scanDay > 0 && scanDay < library.BookIDs.Count)
					{
						scanDay -= 1;
						scanDay = scanDay * library.BooksPerDay;
						for (var i = 0; i < library.BooksPerDay && scanDay + i < library.BookIDs.Count; i++)
						{
							var bookId = library.BookIDs[scanDay + i];
							var bookScore = Input.BookScores[bookId];
							if (!alreadyScannedBooks.Contains(bookId))
							{
								alreadyScannedBooks.Add(bookId);
								score += bookScore;
							}
						}
					}


					if (currentDay[library.ID] >= 0)
						currentDay[library.ID] += 1;
				}

				if (requestSignupReset)
					libInSignup = -1;
			}

			return score;
		}


        /*
        public int GetScore()
        {
            var score = 0;
            /*
            var alreadyScannedBooks = new HashSet<int>();

            var signupQueue = new Queue<LibraryAction>(Libraries);
            var active = new List<LibraryAction>();
            var activeBookIndex = new Dictionary<int, int>();
            LibraryAction signUp = null;
            int signUpCountDown = 0;
            for (var day = 0; day < Input.DayCnt; day++)
            {
                foreach (var item in active)
                    if (activeBookIndex[item.ID] < item.BookIDs.Count)
                    {
                        for (int i = 0; i < item.BooksPerDay; i++)
                        {
                            var bookIndex = activeBookIndex[item.ID];
                            if (bookIndex < item.BookIDs.Count)
                            {
                                var bookID = item.BookIDs[bookIndex];
                                if (!alreadyScannedBooks.Contains(bookID))
                                {
                                    score += Input.BookScores[bookID];
                                    alreadyScannedBooks.Add(bookID);
                                }
                            }
                            activeBookIndex[item.ID] = bookIndex + 1;
                        }
                    }

                if (signUp == null)
                {
                    if (signupQueue.Count > 0)
                    {
                        signUp = signupQueue.Dequeue();
                        signUpCountDown = signUp.SignupDays;
                    }
                    else
                        signUp = null;
                }

                signUpCountDown--;
                if (signUp != null && signUpCountDown == 0)
                {
                    active.Add(signUp);
                    activeBookIndex[signUp.ID] = 0;
                    signUp = null;
                }
            }
            return score;
        }
            */
    }
}