using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    [Activity(Label = "")]
    class agreePage : Activity
    {
        List<String> answers;
        Question q;
        string nummer;
        List<String> agreeanswers = new List<string>();
        List<CheckBox> buttons = new List<CheckBox>();
        int i;
        int u;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            nummer = this.Intent.GetStringExtra("start");

            agreeanswers.Add("Disagree");
            agreeanswers.Add("Slightly disagree");
            agreeanswers.Add("Neutral");
            agreeanswers.Add("Slightly agree");
            agreeanswers.Add("Agree");

            q = GameBase.Quest;
            answers = q.getAnswer;

            ScrollView upmenu = new ScrollView(this);
            upmenu.SetBackgroundColor(Color.LightCyan);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.LightCyan);
            menu.SetPadding(40, 0, 40, 0);

            upmenu.AddView(menu);

            TextView y = new TextView(this); y.Text = q.getQuestion.Substring(1, q.getQuestion.Length - 1); y.TextSize = 20; y.SetTextColor(Color.Black); menu.AddView(y);

            TextView t;
            CheckBox c;

            for (i = 0; i < answers.Count; i++)
            {
                t = new TextView(this); t.Text = answers[i].Substring(1, answers[i].Length - 1); t.TextSize = 15; t.SetTextColor(Color.Black); menu.AddView(t);
                t.SetPadding(0, 20, 0, 0);
                for (u = 0; u < agreeanswers.Count; u++)
                {
                    c = new CheckBox(this); c.Text = agreeanswers[u]; c.Click += klikbutton;  menu.AddView(c);
                    buttons.Add(c);
                }
            }

            Button next = new Button(this); next.Text = "Next"; next.Click += kliknext; menu.AddView(next);

            this.SetContentView(upmenu);
        }
        public void klikbutton(object o, EventArgs ea)
        {
            CheckBox c = (CheckBox)o;
            int n = 0;
            for(int z = 0; z < buttons.Count; z++)
            {
                if(buttons[z] == c)
                {
                    n = z;
                }
            }
            for(int p = 0; p < buttons.Count; p++)
            {
                if(p >= ((n/5)*5) && p < (((n/5)*5) + 5))
                {
                    buttons[p].Checked = false;
                }
            }
            c.Checked = true;
        }
        public void kliknext(object o, EventArgs ea)
        {
            bool error = false;
            int loc = 0;
            for (int p = 0; p < q.getAnswer.Count; p++)
            {
                String s = "";
                for(int l = 0; l < 5; l++)
                {
                    if(buttons[(p*5)+l].Checked == true)
                    {
                        s = s + "1";
                    }
                    else
                    {
                        s = s + "0";
                    }
                }
                Char[] b = s.ToCharArray();
                int tel = 0;
                for(int v = 0; v < b.Length; v++)
                {
                    if (b[v] == '1')
                    {
                        tel = tel + 1;
                    }
                }
                if (tel == 0)
                {
                    error = true;
                    loc = p;
                }
            }
            if (error == true)
            {
                
            }
            else
            {
                String answ = "";
                for(int it = 0; it < buttons.Count; it++)
                {
                    if(buttons[it].Checked == true)
                    {
                        answ = answ + "1";
                    }
                    else
                    {
                        answ = answ + "0";
                    }
                }
                List<String> results = new List<string>();
                Char[] ans = answ.ToCharArray();
                int hoe = 0;
                for(int a = 0; a < answers.Count; a++)
                {
                    int bt = a * 5;
                    int et = ((a + 1) * 5);
                    for(int d = bt; d < et; d++)
                    {
                        if(ans[d] == '1')
                        {
                            hoe = d;
                        }
                    }
                    int po = 0;
                    po = hoe / 5;
                    hoe = hoe - (po * 5);
                    results.Add(hoe + "|" +answers[a].Substring(1, (answers[a].Length - 1)));
                }
                Userinfo.agreeopslaan(results);
                GameBase.nextquestion((int.Parse(nummer) + 1).ToString());
            }
        }
    }
}