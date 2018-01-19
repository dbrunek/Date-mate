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
    class Endscreen : Activity
    {
        List<Button> but = new List<Button>();
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            ScrollView upmenu = new ScrollView(this);
            upmenu.SetBackgroundColor(Color.LightCyan);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.LightCyan);
            menu.SetPadding(40, 0, 40, 0);

            upmenu.AddView(menu);

            TextView t1 = new TextView(this); t1.Text = "You are ready for your date. If you need more information or exercises you can go to the dating info tab on the main menu."; t1.TextSize = 15; t1.SetTextColor(Color.Black); menu.AddView(t1);

            Button end = new Button(this); end.Text = "End"; end.Click += klikend; menu.AddView(end);

            this.SetContentView(upmenu);
        }
        public void klikend(object o, EventArgs ea)
        {
            GameBase.endgame();
        }
    }
}