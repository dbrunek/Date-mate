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
        public int teller;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            string nummer = this.Intent.GetStringExtra("start");

            Text t = GameBase.getSpecificText(nummer);

            TextView q1 = new TextView(this); q1.Text = t.getTitel; q1.TextSize = 20; q1.SetTextColor(Color.Black); menu.AddView(q1);

            TextView alinea;
            foreach (String s in t.getTekst)
            {
                alinea = new TextView(this); alinea.Text = s; alinea.TextSize = 10; alinea.SetTextColor(Color.Black); menu.AddView(alinea);
            }

            Button Back = new Button(this); Back.Text = "Back"; Back.Click += klikback; menu.AddView(Back);

            this.SetContentView(menu);
        }
        public void klikback(object o, EventArgs ea)
        {
            GameBase.startInfoPage();

        }
    }
}