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
    class InfoPageLinkPage : Activity
    {
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

            string nummer = this.Intent.GetStringExtra("start");

            Text t = GameBase.getSpecificText(nummer);

            TextView q1 = new TextView(this); q1.Text = t.getTitel; q1.TextSize = 25; q1.SetTextColor(Color.Black); menu.AddView(q1);

            TextView alinea;
            foreach (String s in t.getTekst)
            {
                alinea = new TextView(this); alinea.Text = s; alinea.TextSize = 12; alinea.SetTextColor(Color.Black); menu.AddView(alinea);
                alinea.SetPadding(0, 5, 0, 5);
            }

            Button Back = new Button(this); Back.Text = "Back"; Back.Click += klikback; menu.AddView(Back);

            this.SetContentView(upmenu);
        }
        public void klikback(object o, EventArgs ea)
        {
            GameBase.startInfoPage();

        }
    }
}