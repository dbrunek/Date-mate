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
    [Activity(Label = "")]
    class CheckPage : Activity
    {
        public List<String> answers;
        public List<boynextdoor> check = new List<boynextdoor>();
        Question q;
        string nummer;

        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            nummer = this.Intent.GetStringExtra("start");

            q = GameBase.Quest;

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            TextView q1 = new TextView(this); q1.Text = q.getQuestion.Substring(1,q.getQuestion.Length-1); q1.TextSize = 10; q1.SetTextColor(Color.Black); menu.AddView(q1);

            answers = q.getAnswer;

            for(int i = 0; i < answers.Count; i++)
            {
                boynextdoor boy = new boynextdoor();
                boy.answer = answers[i].Substring(1,answers[i].Length-1);
                boy.ja = false;
                check.Add(boy);
            }

            CheckBox box;

            for (int i = 0; i < answers.Count; i++)
            {
                box = new CheckBox(this); box.Text = answers[i].Substring(1, answers[i].Length - 1); box.Click += gechekt; menu.AddView(box);
            }

            Button c = new Button(this); c.Text = "Confirm"; c.Click += Confirm; menu.AddView(c);

            this.SetContentView(menu);
        }
        public void gechekt(object o, EventArgs ea)
        {
            CheckBox box = (CheckBox)o;
            String s = box.Text;
            if(box.Checked)
            {
                for(int i = 0; i < check.Count; i++)
                {
                    if(check[i].answer == s)
                    {
                        if(check[i].ja == false)
                        {
                            check[i].ja = true;
                        }
                    }
                }
            }
            else
            {
                for(int i = 0; i < check.Count; i++)
                {
                    if (check[i].answer == s)
                    {
                        if (check[i].ja == true)
                        {
                            check[i].ja = false;
                        }
                    }
                }
            }

        }
        public void Confirm(object o, EventArgs ea)
        {
            Userinfo.Checkopslaan(check);
            GameBase.nextquestion((int.Parse(nummer) + 1).ToString());
        }
    }
}