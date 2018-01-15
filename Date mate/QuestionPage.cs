using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    [Activity(Label = "")]
    public class QuestionPage : Activity
    {
        List<String> answers;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            string nummer = this.Intent.GetStringExtra("start");

            Question q = GameBase.Quest;

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            TextView q1 = new TextView(this); q1.Text = q.getQuestion; q1.TextSize = 10; q1.SetTextColor(Color.Black); menu.AddView(q1);

            answers = q.getAnswer;
            Button ans;

            for ( int i = 0; i < answers.Count; i++)
            {
                ans = new Button(this); ans.Text = answers[i].Substring(1,answers[i].Length-1); ans.Click += Klik; menu.AddView(ans);
            }

            this.SetContentView(menu);
        }
        public void Klik(object o, EventArgs ea)
        {
            Button B = (Button)o;
            string a = B.Text;
            foreach(String s in answers)
            {
                if (a == s.Substring(1,s.Length-1))
                {
                    GameBase.nextquestion(s.Substring(0,1));
                }
            }
        }
    }
}