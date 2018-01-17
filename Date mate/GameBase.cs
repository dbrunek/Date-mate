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
        public static List<Text> textData = new List<Text>();
        public static List<Text> texts = new List<Text>();
        public static String number = "0";
        public static String textnumber = "0";

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
            if (s == "end")
            {
                startText();
            }
            else if (questions[int.Parse(number)].Ask.Substring(0, 1) == "x")
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
        public static void startText()
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(TextPage));
            i.PutExtra("start", textnumber);
            mContext.StartActivity(i);
        }
        public static void nextText()
        {
            int t = int.Parse(textnumber);
            t++;
            textnumber = t.ToString();

            if (texts.Count == int.Parse(textnumber))
            {
                startInfoPage();
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(TextPage));
                i.PutExtra("start", textnumber);
                mContext.StartActivity(i);
            }
        }
        public static void previousText()
        {
            int t = int.Parse(textnumber);
            t--;
            textnumber = t.ToString();

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(TextPage));
            i.PutExtra("start", textnumber);
            mContext.StartActivity(i);
        }
        public static void startInfoPage()
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(InfoPage));
            mContext.StartActivity(i);
        }
        public static void InfoPageLink(int t)
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(InfoPageLinkPage));
            i.PutExtra("start", t.ToString());
            mContext.StartActivity(i);
        }
        public static Text getSpecificText(String s)
        {
            return textData[int.Parse(s)];
        }
        public static List<Text> getTextData
        {
            get { return textData; }
            set { }
        }
        public static int getTextCount
        {
            get { return texts.Count; }
            set { }
        }
        public static Text getTextinfo
        {
            get { return texts[int.Parse(textnumber)]; }
            set { }
        }
        public static Question Quest
        {
            get { return questions[int.Parse(number)]; }
            set { }
        }
        public static void QuestionData()
        {
            Question q0 = new Question("What is your age?");
            q0.AddAnswer("10-18");
            q0.AddAnswer("118-21");
            q0.AddAnswer("122-25");
            q0.AddAnswer("126-40");
            q0.AddAnswer("130+");
            questions.Add(q0);
            Question q1 = new Question("What is your gender");
            q1.AddAnswer("2Man");
            q1.AddAnswer("2Women");
            questions.Add(q1);
            Question q2 = new Question("How much experience do you have with dating??");
            q2.AddAnswer("3No experience (Never dated before)");
            q2.AddAnswer("3Not much experience (Have had a few dates)");
            q2.AddAnswer("3Avarage experience (Have had multiple dates with a few different persons)");
            q2.AddAnswer("3A fair bit of experience (Have had frequent dates with different persons)");
            q2.AddAnswer("3A lot of experience (Have had a lot of dates dates with different persons)");
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
            Text t0 = new Text("test");
            t0.AddAlinea("test tekst");
            t0.AddAlinea("alinea 2");
            textData.Add(t0);
            Text t1 = new Text("test 1");
            t1.AddAlinea("test tekst 1");
            t1.AddAlinea("alinea 2");
            textData.Add(t1);
            Text t2 = new Text("test 2");
            t2.AddAlinea("test tekst 2");
            t2.AddAlinea("alinea 2");
            textData.Add(t2);

            texts = Userinfo.userText(textData);
        }
    }
}