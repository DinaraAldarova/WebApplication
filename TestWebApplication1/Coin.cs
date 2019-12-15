using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebApplication1
{
    public class Coin
    {
        private Random random;
        public string question;
        public string obverse;
        public string reverse;

        public Coin()
        {
            random = new Random();
            question = "What?";
            obverse = "obverse";
            reverse = "reverse";
        }

        public string GetDefaultAnswer() => "obverse..reverse.. don't know";

        public string GetAnswer()
        {
            if (random.Next(0, 1) == 0)
                return obverse;
            else
                return reverse;
        }

        public string GetAnswerQuestion() => question + "\n" + GetAnswer();
    }
}
