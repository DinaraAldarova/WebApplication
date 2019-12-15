using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebApplication1
{
    public class Dice
    {
        private Random random;
        public string[] answers { get; }
        public string question;

        public Dice()
        {
            random = new Random();
            answers = new string[] {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6"
            };
            question = "What?";
        }

        public string GetDefaultAnswer() => "1..2..3..4..5..6.. don't know";

        public string GetAnswer() => answers[random.Next(answers.Length)];

        public string GetAnswerQuestion() => question + "\n" + GetAnswer();
    }
}
