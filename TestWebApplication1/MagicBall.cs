using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication1
{
    public class MagicBall
    {
        private Random random;
        public string[] Answers { get; set; }
        public string Question { get; set; }

        public MagicBall()
        {
            random = new Random();
            Answers = new string[] {
                "Yes",
                "No",
                "I don't know"
            };
            Question = "What?";
        }

        public string GetDefaultAnswer() => "Maybe yes, maybe no...";

        public string GetAnswer() => Answers[random.Next(Answers.Length)];

        public string GetAnswerQuestion() => Question + "\n" + GetAnswer();
    }
}
