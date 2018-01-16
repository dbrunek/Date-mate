using System;
using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    public static class GameBase
    {
        public static List<Question> questions = new List<Question>();
        public static List<List<String>> texts = new List<List<String>>();
        public static String number = "0";

        public static void startgame()
        {
            QuestionData();
            TextData();

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(QuestionPage));
            i.PutExtra("start", number);
            mContext.StartActivity(i);

        }
        public static void nextquestion(string s)
        {
            number = s;
            if (questions[int.Parse(number)].Ask.Substring(0, 1) == "x")
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(CheckPage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(QuestionPage));
                i.PutExtra("start", s);
                mContext.StartActivity(i);
            }
        }
        public static Question Quest
        {
            get { return questions[int.Parse(number)]; }
            set { }
        }
        public static void QuestionData()
        {
            Question q0 = new Question("What is your age?");
            q0.AddAnswer("10-15");
            q0.AddAnswer("116-21");
            q0.AddAnswer("122-30");
            q0.AddAnswer("131-40");
            q0.AddAnswer("141-50");
            q0.AddAnswer("351+");
            questions.Add(q0);
            Question q1 = new Question("What is your gender");
            q1.AddAnswer("2Man");
            q1.AddAnswer("2Women");
            questions.Add(q1);
            Question q2 = new Question("Are you straight or homosexual?");
            q2.AddAnswer("3Straight");
            q2.AddAnswer("3Homosexual");
            questions.Add(q2);
            Question q3 = new Question("xSelect the negative feeling you expect to feel during the date");
            q3.AddAnswer("0Stress");
            q3.AddAnswer("0Anxiety");
            q3.AddAnswer("0Nervousness");
            q3.AddAnswer("0Anxiety");
            questions.Add(q3);
        }
        public static void TextData()
        {

        }
    }
}