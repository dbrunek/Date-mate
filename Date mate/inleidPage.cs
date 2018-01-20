using System;
using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;
using Android.Views;

namespace Date_mate
{
    [Activity(Label = "")]
    class inleidPage : Activity
    {
        string nummer;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            nummer = this.Intent.GetStringExtra("start");

            ScrollView upmenu = new ScrollView(this);
            upmenu.SetBackgroundColor(Color.LightCyan);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.LightCyan);
            menu.SetPadding(40, 0, 40, 0);

            upmenu.AddView(menu);

            List<String> list = new List<string>();
            list.Add("Date Mate will guide you through a succesfull dating experience in 3 simple steps.");
            list.Add("Step 1: Preperation");
            list.Add("With the help of some questions this app will eveluate your past dating experience or in case you never had a date it will show you what you need to improve in.");
            list.Add("Step 2: Guidance");
            list.Add("With the help of mental exercises and small tips you will be helped and motivated to have a succesfull date.");
            list.Add("Step 3: Evaluation");
            list.Add("The first date is almost never the last and this app will help to evaluate what went wrong and let's you learn from it.");

            TextView t1 = new TextView(this); t1.Text = "Welcome to Date Mate, the best way of having a succesfull date."; t1.TextSize = 25; t1.SetTextColor(Color.Black); menu.AddView(t1);

            for (int i = 0; i < list.Count; i++)
            {
                TextView q1 = new TextView(this); q1.Text = list[i]; q1.TextSize = 15; q1.SetTextColor(Color.Black); menu.AddView(q1);
                q1.SetPadding(0, 10, 0, 10);
            }

            LinearLayout buttonmenu = new LinearLayout(this);
            buttonmenu.Orientation = Orientation.Horizontal;
            buttonmenu.SetBackgroundColor(Color.LightCyan);
            buttonmenu.LayoutParameters =new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            buttonmenu.SetPadding(0, 5, 0, 0);

            int w = Resources.DisplayMetrics.WidthPixels;

            Button back = new Button(this); back.Text = "Back"; back.Click += klikback; back.SetWidth(w/2); buttonmenu.AddView(back);

            Button go = new Button(this); go.Text = "Start"; go.Click += klik; go.SetWidth(w/2); buttonmenu.AddView(go);
       
            menu.AddView(buttonmenu);

            this.SetContentView(upmenu);
        }
        public void klikback(object o, EventArgs ea)
        {
            GameBase.endgame();
        }
        public void klik(object o, EventArgs ea)
        {
            GameBase.nextquestion(nummer);
        }
    }

}