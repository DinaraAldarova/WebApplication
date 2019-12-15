using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication1
{
    public class MagicBall
    {
        private Random random;
        public string[] answers;
        public string question;
        
        public MagicBall()
        {
            random = new Random();
            answers = new string[] {
                "Yes",
                "No",
                "I don't know"
            };
            question = "What?";
        }

        public string GetDefaultAnswer() => "Maybe yes, maybe no...";

        public string GetAnswer() => answers[random.Next(answers.Length)];

        public string GetAnswerQuestion() => question + "\n" + GetAnswer();
    }
}
