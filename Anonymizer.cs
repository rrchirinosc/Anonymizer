using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymizer
{
    public class Anonymizer
    {
        /// <summary>
        /// Anonymizes <paramref name="users"/> and returns anonymized user values in same order.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>Anonymized user values in same order as <paramref name="users" /></returns>
        public IEnumerable<string> Anonymize(IEnumerable<string> users)
        {
            // NOTE: See assignment info for which criteria are to be fulfilled

            //throw new NotImplementedException();

            // TODO: null user check???
            // make sure the resulting list has the same amount of entries as the input list!!
            return users.Select(user => Encode(user));
        }

        /// <summary>
        /// Base64 encodes a given string<paramref name="data"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Base64 encoded string or null if given string is null.</returns>
        private string Encode(string data)
        {
            return (data == null ? null : System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data)));
        }

        /// <summary>
        /// Decodes a given Base64 string<paramref name="data"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Decoded Base64 string or null if given string is null.</returns>
        private string Decode(string data)
        {
            return (data == null ? null : System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(data)));
        }
    }
}
