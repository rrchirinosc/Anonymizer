using System;
using System.Collections.Generic;

namespace Anonymizer
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string User { get; set; }
        public bool IsAnonymized { get; set; }
        public List<string> Answers { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
