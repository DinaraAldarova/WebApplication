using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Dice
    {
        public string[] answers { get; }
        public string question;

        public Dice()
        {
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
    }
}
