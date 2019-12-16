using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using xNet;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string help =
            //    "This MagicBall will answer any your question!\n" +
            //    "Just put parameters:\n" +
            //    "* without parameters you'll get random answer from default set\n" +
            //    "* string[] answers - you'll get random answer from your set\n" +
            //    "* string question  - you'll get question and answer to it\n" +
            //    "you also can use parameters together.\n" +
            //    "Good luck!";
            string helpEng =
                "This MagicBall, coin and dice will answer any your question!\n" +
                "Just put query:\n" +
                "* ask magic ball - you'll get random answer from set\n" +
                "* toss coin - you'll get the answer reverse or obverse\n" +
                "* roll dice  - you'll get answer from 1 to 6\n" +
                "you also can use parameters together.\n" +
                "Good luck!";
            string helpRu =
                "Магический шар, монетка и кость ответят на любые ваши вопросы!\n" +
                "Просто введите запрос:\n" +
                "* ask magic ball - вы получите случайный ответ из набора\n" +
                "* toss coin - вы получите ответ \"орел\" или \"решка\"\n" +
                "* roll dice  - вы получите ответ от 1 до 6\n" +
                "\n" +
                "* set question - изменить вопрос\n" +
                "* set answers - установить свой набор ответов магического шара\n" +
                "* set obverse - установить свой ответ для решки\n" +
                "* set reverse - установить свой ответ для орла\n" +
                "* show - просмотреть текущие настройки\n" +
                "Удачи!";
            MagicBall magicBall = new MagicBall();
            Coin coin = new Coin();
            Dice dice = new Dice();
            string serialized;
            string result;
            HttpRequest GetAnswer;

            Console.WriteLine(helpRu);
            string query;
            Console.Write("> ");
            while ((query = Console.ReadLine().ToLower()) != "quit")
            {
                switch (query)
                {
                    case "set question":
                        Console.WriteLine("Введите вопрос:");
                        string question = Console.ReadLine();
                        magicBall.question = question;
                        coin.question = question;
                        dice.question = question;
                        Console.WriteLine("Вопрос изменен");
                        break;

                    case "set answers":
                        Console.WriteLine("Введите варианты ответа на вопрос. Для завершения введите пустую строку:");
                        List<string> lst = new List<string> { };
                        string str;
                        while((str = Console.ReadLine()) != "")
                            lst.Add(str);
                        magicBall.answers = lst.ToArray();
                        Console.WriteLine("Ответы введены");
                        break;

                    case "set obverse":
                        Console.WriteLine("Введите ответ для решки:");
                        coin.obverse = Console.ReadLine();
                        Console.WriteLine("Ответ введен");
                        break;

                    case "set reverse":
                        Console.WriteLine("Введите ответ для орла:");
                        coin.reverse = Console.ReadLine();
                        Console.WriteLine("Ответ введен");
                        break;

                    case "show":
                        Console.WriteLine(magicBall.question);
                        Console.Write("Магический шар: ");
                        for (int i = 0; i < magicBall.answers.Length; i++)
                        {
                            if (i > 0)
                                Console.Write(", ");
                            Console.Write(magicBall.answers[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Монета: {0} или {1}", coin.obverse, coin.reverse);
                        Console.Write("Кость: ");
                        for (int i = 0; i < dice.answers.Length; i++)
                        {
                            if (i > 0)
                                Console.Write(", ");
                            Console.Write(dice.answers[i]);
                        }
                        Console.WriteLine();
                        break;

                    case "ask":
                    case "ask ball":
                    case "ask magic ball":
                    case "ask magicball":
                    case "ask a ball":
                    case "ask a magic ball":
                    case "ask a magicball":
                    case "ask the ball":
                    case "ask the magic ball":
                    case "ask the magicball":
                        serialized = JsonConvert.SerializeObject(magicBall);
                        GetAnswer = new HttpRequest();
                        GetAnswer.AddUrlParam("magicball", serialized);
                        try
                        {
                            result = GetAnswer.Get("https://localhost:5001/").ToString();
                        }
                        catch
                        {
                            result = "Не удалось отправить запрос сервису";
                        }
                        Console.WriteLine(result);
                        break;

                    case "toss":
                    case "toss coin":
                    case "toss a coin":
                    case "toss the coin":
                        serialized = JsonConvert.SerializeObject(coin);
                        GetAnswer = new HttpRequest();
                        GetAnswer.AddUrlParam("coin", serialized);
                        try
                        {
                            result = GetAnswer.Get("https://localhost:5001/").ToString();
                        }
                        catch
                        {
                            result = "Не удалось отправить запрос сервису";
                        }
                        Console.WriteLine(result);
                        break;

                    case "roll":
                    case "roll dice":
                    case "roll a dice":
                    case "roll the dice":
                    case "throw":
                    case "throw dice":
                    case "throw a dice":
                    case "throw the dice":
                        serialized = JsonConvert.SerializeObject(dice);
                        GetAnswer = new HttpRequest();
                        GetAnswer.AddUrlParam("dice", serialized);
                        try
                        {
                            result = GetAnswer.Get("https://localhost:5001/").ToString();
                        }
                        catch
                        {
                            result = "Не удалось отправить запрос сервису";
                        }
                        Console.WriteLine(result);
                        break;

                    case "help":
                        Console.WriteLine(helpRu);
                        break;

                    default:
                        break;
                }
                Console.Write("> ");
                result = "";
            }
        }
    }
}
