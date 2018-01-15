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
        public static String number = "0";

        public static void startgame()
        {
            Question q0 = new Question("wat is je leeftijd");
            q0.AddAnswer("1haHAA");
            q0.AddAnswer("212 btw");
            questions.Add(q0);
            Question q1 = new Question("PepeHands");
            q1.AddAnswer("0Krappa");
            q1.AddAnswer("24Head");
            questions.Add(q1);
            Question q2 = new Question("scrub LUL");
            q2.AddAnswer("1EleGiggle");
            q2.AddAnswer("0BabyRage");
            questions.Add(q2);

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(QuestionPage));
            i.PutExtra("start", number);
            mContext.StartActivity(i);
        }

        public static void nextquestion(string s)
        {
            number = s;
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(QuestionPage));
            i.PutExtra("start", s);
            mContext.StartActivity(i);
        }
        public static Question Quest
        {
            get { return questions[int.Parse(number)]; }
            set { }
        }
    }
}