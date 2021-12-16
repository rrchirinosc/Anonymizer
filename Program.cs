//////////////////////////////////////////
//
// Anonymizer test console app
// Completed by: Raul Chirinos Coya
//
//////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Anonymize...\n\n");

            var repository = new AnswerRepository();
            var answers = repository.GetAnswersToAnonymize();

            var users = ExtractUsers(answers);

            var anonymizer = new Anonymizer();
            var anonymizedUsers = anonymizer.Anonymize(users);

            PrintBeforeAndAfterValues(answers, anonymizedUsers);

            UpdateAnonymizedUsers(answers, anonymizedUsers);

            repository.SaveAnonymizedAnswers(answers);

            Console.WriteLine("\n\n...done anonymizing");
            Console.ReadKey();
        }

        /// <summary>
        /// Extracts user values from <paramref name="answers"/>
        /// </summary>
        /// <param name="answers"></param>
        /// <returns>Extracted user values.</returns>
        private static IEnumerable<string> ExtractUsers(IEnumerable<Answer> answers)
        {
            // Create a list with the to be anonymized user names extracted from 
            // the to be anonymized answers 
            return answers.Select(answer => answer.User);

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Prints the user value before and after anonymization for each related item in <paramref name="answers"/> and <paramref name="anonymizedUsers"/>, 
        /// one line per answer.
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="anonymizedUsers"></param>
        private static void PrintBeforeAndAfterValues(IEnumerable<Answer> answers, IEnumerable<string> anonymizedUsers)
        {
            //throw new NotImplementedException();
            //TODO: null check??
            //Provided the input list correspond to each other (number of items,...)

            // Fetch an enumerator for the given anonymizedUser list to traverse it
            var anonymizedUsersEnumerator = anonymizedUsers.GetEnumerator();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("List of (before and after) anonymized users:\n");
            Console.BackgroundColor = ConsoleColor.Black;

            // As we traverse the answers list we 'pair' an answer with its corresponding anonymized user
            // based on an in-the-list order correspondence i.e. answer[0] -> anonymizedUser[0] and so on
            foreach (Answer answer in answers)
            {
                anonymizedUsersEnumerator.MoveNext();
                Console.WriteLine("User: {0, -20} Anonymized: {1, -20}\n", answer.User, anonymizedUsersEnumerator.Current);
            }
        }

        /// <summary>
        /// Updates all <see cref="Answer.User"/> in <paramref name="answers"/> with anonymized user value from <paramref name="anonymizedUsers"/>.
        /// Also marks the them as anonymized (by setting <see cref="Answer.IsAnonymized"/>).
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="anonymizedUsers"></param>
        private static void UpdateAnonymizedUsers(IEnumerable<Answer> answers, IEnumerable<string> anonymizedUsers)
        {
            //throw new NotImplementedException();
            // Fetch an enumerator for the given anonymizedUser list to traverse it
            var anonymizedUsersEnumerator = anonymizedUsers.GetEnumerator();

            // As we traverse the answers list we 'pair' an answer with its corresponding anonymized user
            // based on an in-the-list order correspondence i.e. answer[0] -> anonymizedUser[0] and so on
            foreach (Answer answer in answers)
            {
                anonymizedUsersEnumerator.MoveNext();
                answer.User = anonymizedUsersEnumerator.Current;
                answer.IsAnonymized = answer.User != null;     // no user = not anonymized
            }            
        }
    }
}
