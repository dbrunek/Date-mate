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
    class TextPage : Activity
    {
        Text t;
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            string nummer = this.Intent.GetStringExtra("start");

            t = GameBase.getTextinfo;

            ScrollView upmenu = new ScrollView(this);
            upmenu.SetBackgroundColor(Color.LightCyan);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.LightCyan);
            menu.SetPadding(40, 0, 40, 0);

            upmenu.AddView(menu);

            TextView q1 = new TextView(this); q1.Text = t.getTitel; q1.TextSize = 25; q1.SetTextColor(Color.Black); menu.AddView(q1);

            TextView alinea;
            foreach(String s in t.getTekst)
            {
                alinea = new TextView(this); alinea.Text = s; alinea.TextSize = 12; alinea.SetTextColor(Color.Black); menu.AddView(alinea);
                alinea.SetPadding(0, 5, 0, 5);
            }

            LinearLayout buttonmenu = new LinearLayout(this);
            buttonmenu.Orientation = Orientation.Horizontal;
            buttonmenu.SetBackgroundColor(Color.LightCyan);
            buttonmenu.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
            buttonmenu.SetPadding(0, 5, 0, 0);

            int w = Resources.DisplayMetrics.WidthPixels;

            if (nummer != "0")
            {
                Button Previous = new Button(this); Previous.Text = "Previous Page"; Previous.SetWidth(w/2); Previous.Click += klikprevious; buttonmenu.AddView(Previous);
            }
            if (int.Parse(nummer) == GameBase.getTextCount - 1)
            {
                Button Next = new Button(this); Next.Text = "Ready"; Next.SetWidth(w/2); Next.Click += klikready; buttonmenu.AddView(Next);
            }
            else
            {
                if (nummer == "0")
                {
                    Button Next = new Button(this); Next.Text = "Next Page"; Next.SetWidth(w); Next.Click += kliknext; buttonmenu.AddView(Next);
                }
                else
                {
                    Button Next = new Button(this); Next.Text = "Next Page"; Next.SetWidth(w/2); Next.Click += kliknext; buttonmenu.AddView(Next);
                }
            }

            menu.AddView(buttonmenu);
            this.SetContentView(upmenu);
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