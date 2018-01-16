using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    public class Question
    {
        public String Ask;
        //Elk answer bestaat uit een plaats daarna een spatie en het antwoord zelf
        public List<String> Answers = new List<String>();

        public Question(String q)
        {
            Ask = q;;
        }
        public void AddAnswer(String a)
        {
            Answers.Add(a);
        }
        public List<String> getAnswer
        {
            get { return Answers; }
            set { }
        }
        public String getQuestion
        {
            get { return Ask; }
            set { }
        }
    }
}