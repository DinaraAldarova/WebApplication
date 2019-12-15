using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MagicBall
    {
        public string[] answers;
        public string question;
        
        public MagicBall()
        {
            answers = new string[] {
                "Yes",
                "No",
                "I don't know"
            };
            question = "What?";
        }
    }
}
