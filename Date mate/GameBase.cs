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
            Intent i = new Intent(mContext, typeof(inleidPage));
            i.PutExtra("start", number);
            mContext.StartActivity(i);

        }
        public static void endgame()
        {
            number = "0";
            textnumber = "0";
            Userinfo.delete();

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(Main));
            mContext.StartActivity(i);
        }
        public static void nextquestion(string s)
        {
            number = s;
            if (s == "8" || s == questions.Count.ToString())
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
            else if (questions[int.Parse(number)].Ask.Substring(0, 1) == "q")
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(agreePage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(QuestionPage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
        }
        public static void startText()
        {
            texts = Userinfo.userText(textData);
            List<Text> bv = new List<Text>();

            if (texts.Count == 0)
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
            Question q3 = new Question("Do you think you need to improve in finding a good dating location?");
            q3.AddAnswer("4Yes");
            q3.AddAnswer("4No");
            questions.Add(q3);
            Question q4 = new Question("Do you think you have to improve in avoiding awkward silences/ not knowing what to talk about?");
            q4.AddAnswer("5Yes");
            q4.AddAnswer("5No");
            questions.Add(q4);
            Question q5 = new Question("qHow much do you agree with the following statements about yourself in the context of dating:");
            q5.AddAnswer("6I can correctly identify other people’s emotions.");
            q5.AddAnswer("6I can correctly identify other people’s needs.");
            q5.AddAnswer("6I recall what other persons recently have said.");
            q5.AddAnswer("6I recall what other people have said at the beginning of the conservation.");
            q5.AddAnswer("6I can focus on other people.");
            questions.Add(q5);
            Question q6 = new Question("qHow much do you agree with the following statements about yourself in the context of dating:");
            q6.AddAnswer("7I feel calm.");
            q6.AddAnswer("7I am tense.");
            q6.AddAnswer("7I feel upset.");
            q6.AddAnswer("7I am relaxed.");
            q6.AddAnswer("7I feel content.");
            q6.AddAnswer("7I am worried.");
            questions.Add(q6);
            Question q7 = new Question("qHow much do you agree with the following statements about yourself:");
            q7.AddAnswer("8I feel confident about my appearance and attitude.");
            q7.AddAnswer("8I feel confident in conservations.");
            q7.AddAnswer("8I can enjoy social situations without being focused on how other think of me.");
            q7.AddAnswer("8I am not shy to share my honest opinion without being focused on what others think of me.");
            q7.AddAnswer("8In social situations, I feel relaxed and can focus and listen well to others.");
            q7.AddAnswer("8In social situations, I often do not fully feel present because I am too focused on what to say next.");
            questions.Add(q7);
        }
        public static void TextData()
        {
            Text t0 = new Text("Dating locations");
            t0.AddAlinea("test tekst");
            t0.AddAlinea("alinea 2");
            textData.Add(t0);
            Text t1 = new Text("Awkward silences/Not knowing what to say");
            t1.AddAlinea("test tekst 1");
            t1.AddAlinea("alinea 2");
            textData.Add(t1);
            Text t2 = new Text("Stress");
            t2.AddAlinea("test tekst 2");
            t2.AddAlinea("alinea 2");
            textData.Add(t2);
            Text t3 = new Text("Anxiety");
            t3.AddAlinea("test tekst 2");
            t3.AddAlinea("alinea 2");
            textData.Add(t3);
            Text t4 = new Text("Low self-esteem");
            t4.AddAlinea("test tekst 2");
            t4.AddAlinea("alinea 2");
            textData.Add(t4);
        }
    }
}