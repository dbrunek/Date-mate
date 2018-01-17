using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    [Activity(Label = "")]
    class TextPage : Activity
    {
        Text t;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            string nummer = this.Intent.GetStringExtra("start");

            t = GameBase.getTextinfo;

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            TextView q1 = new TextView(this); q1.Text = t.getTitel; q1.TextSize = 20; q1.SetTextColor(Color.Black); menu.AddView(q1);

            TextView alinea;
            foreach(String s in t.getTekst)
            {
                alinea = new TextView(this); alinea.Text = s; alinea.TextSize = 10; alinea.SetTextColor(Color.Black); menu.AddView(alinea);
            }

            if (nummer != "0")
            {
                Button Previous = new Button(this); Previous.Text = "Previous Page"; Previous.Click += klikprevious; menu.AddView(Previous);
            }
            if (int.Parse(nummer) == GameBase.getTextCount - 1)
            {
                Button Next = new Button(this); Next.Text = "Ready"; Next.Click += klikready; menu.AddView(Next);
            }
            else
            {
                Button Next = new Button(this); Next.Text = "Next Page"; Next.Click += kliknext; menu.AddView(Next);
            }

            this.SetContentView(menu);
        }
        public void kliknext(object o, EventArgs ea)
        {
            GameBase.nextText();

        }
        public void klikprevious(object o, EventArgs ea)
        {
            GameBase.previousText();
        }
        public void klikready(object o, EventArgs ea)
        {
            GameBase.startInfoPage();

        }
    }
}