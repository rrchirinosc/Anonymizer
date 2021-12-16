using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymizer
{
    public class AnswerRepository
    {
        // Answers stored in memory to not complicate the assignment further
        private readonly Dictionary<int, Answer> UserAnswersById = new Dictionary<int, Answer>
        {
            { 1, new Answer 
                { 
                    AnswerId = 1, 
                    User = "adam.andersson", 
                    IsAnonymized = false, 
                    Answers = new List<string> { "yes", "yes" }, 
                    Timestamp = DateTime.Now.AddDays(-22) 
                } 
            },
            { 2, new Answer
                {
                    AnswerId = 2,
                    User = "bo.bertilsson",
                    IsAnonymized = false,
                    Answers = new List<string> { "yes", "no" },
                    Timestamp = DateTime.Now.AddDays(-16)
                }
            },
            { 3, new Answer
                {
                    AnswerId = 3,
                    User = "carl.classon",
                    IsAnonymized = false,
                    Answers = new List<string> { "no", "no" },
                    Timestamp = DateTime.Now.AddDays(-8)
                }
            },
            { 4, new Answer
                {
                    AnswerId = 4,
                    User = null,
                    IsAnonymized = false,
                    Answers = new List<string> { "yes", "no" },
                    Timestamp = DateTime.Now.AddDays(-16)
                }
            },
            { 5, new Answer
                {
                    AnswerId = 5,
                    User = "raul.chirinos",
                    IsAnonymized = false,
                    Answers = new List<string> { "yes", "no" },
                    Timestamp = DateTime.Now.AddDays(-20)
                }
            },
            { 6, new Answer
                {
                    AnswerId = 6,
                    User = "zlatan.ibrahimovich",
                    IsAnonymized = false,
                    Answers = new List<string> { "yes", "no" },
                    Timestamp = DateTime.Now.AddDays(-2)
                }
            },
            { 7, new Answer
                {
                    AnswerId = 7,
                    User = "per.morberg",
                    IsAnonymized = false,
                    Answers = new List<string> { "yes", "no" },
                    Timestamp = DateTime.Now.AddDays(-16)
                }
            },
            { 8, new Answer
                {
                    AnswerId = 8,
                    User = "cGVyLm1vcmJlcmc=",
                    IsAnonymized = true,
                    Answers = new List<string> { "yes", "no" },
                    Timestamp = DateTime.Now.AddDays(-26)
                }
            }
        };

        /// <summary>
        /// Gets answers which fulfills criteria to be anonymized.
        /// </summary>
        /// <returns>Answers to anonymize.</returns>
        public IEnumerable<Answer> GetAnswersToAnonymize()
        {
            // NOTE: See assignment info for which criteria are to be fulfilled

            // Fetch from the retrieved answers a list of all answers that are older 
            // than 14 days and are not flagged as already anonymized

            // NOTE: There may be answers that are older than 14 days and wrongly flagged as
            // anonymized but it is not the purpose of this function to deal with that
            return UserAnswersById.Values.Where(user => (user.Timestamp < DateTime.Now.AddDays(-14) &&
                    !user.IsAnonymized)).ToList();
                
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Saves anonymized answers to storage
        /// </summary>
        /// <param name="answers"></param>
        public void SaveAnonymizedAnswers(IEnumerable<Answer> answers)
        {
            // Stored in memory, so nothing to do

            // For demonstration purposes I output here a list with the 
            // modified values to be stored 
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("List of anonymized answers:\n");
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (Answer answer in answers)
            {
                Console.WriteLine("ID: {0, -5} User: {1, -20} Anonymized: {2, -5}\n", answer.AnswerId, answer.User, answer.IsAnonymized);
            }            
        }
    }
}
