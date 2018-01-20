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
    class InfoPage : Activity
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

            TextView q1 = new TextView(this); q1.Text = "All information pages" ; q1.TextSize = 25; q1.SetTextColor(Color.Black); menu.AddView(q1);

            List<Text> t = GameBase.getTextData;

            Button Link;

            for(int i = 0; i < t.Count; i++)
            {
                Link = new Button(this); Link.Text = t[i].getTitel; Link.Click += klikLink; menu.AddView(Link);
                but.Add(Link);
            }

            LinearLayout buttonmenu = new LinearLayout(this);
            buttonmenu.Orientation = Orientation.Horizontal;
            buttonmenu.SetBackgroundColor(Color.LightCyan);
            buttonmenu.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            buttonmenu.SetPadding(0, 5, 0, 0);
            int w = Resources.DisplayMetrics.WidthPixels;

            Button bu = new Button(this); bu.Text = "Ready"; bu.SetWidth(w/2); bu.Click += klikready; buttonmenu.AddView(bu);
            Button end = new Button(this); end.Text = "Main menu"; end.SetWidth(w / 2);  end.Click += klikend; buttonmenu.AddView(end);

            menu.AddView(buttonmenu);
            this.SetContentView(upmenu);
        }
        public void klikready(object o, EventArgs ea)
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(CheckListPage));
            mContext.StartActivity(i);
        }
        public void klikend(object o, EventArgs ea)
        {
            GameBase.endgame();
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