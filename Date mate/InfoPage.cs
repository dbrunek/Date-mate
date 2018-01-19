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
    class InfoPage : Activity
    {
        List<Button> but = new List<Button>();
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            TextView q1 = new TextView(this); q1.Text = "Info pages" ; q1.TextSize = 20; q1.SetTextColor(Color.Black); menu.AddView(q1);

            List<Text> t = GameBase.getTextData;

            Button Link;

            for(int i = 0; i < t.Count; i++)
            {
                Link = new Button(this); Link.Text = t[i].getTitel; Link.Click += klikLink; menu.AddView(Link);
                but.Add(Link);
            }

            this.SetContentView(menu);
        }
        public void klikLink(object o, EventArgs ea)
        {
            int teller = 0;
            for (int i = 0; i < but.Count; i++)
            {
                if(but[i] == (Button)o)
                {
                    teller = i;
                }
            }
            GameBase.InfoPageLink(teller);
        }
    }
}