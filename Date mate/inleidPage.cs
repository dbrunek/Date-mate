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
    class inleidPage : Activity
    {
        string nummer;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            nummer = this.Intent.GetStringExtra("start");

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            TextView q1 = new TextView(this); q1.Text = "suction"; q1.TextSize = 20; q1.SetTextColor(Color.Black); menu.AddView(q1);

            Button back = new Button(this); back.Text = "Back"; back.Click += klikback; menu.AddView(back);

            Button go = new Button(this); go.Text = "Start"; go.Click += klik; menu.AddView(go);

            this.SetContentView(menu);
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