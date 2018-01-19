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
    class CheckListPage : Activity
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

            TextView t1 = new TextView(this); t1.Text = "Looks like you are Ready for your date. Here is a helpfull checklist to see if you forgot anything."; t1.TextSize = 15; t1.SetTextColor(Color.Black); menu.AddView(t1);

            List<String> checks = new List<string>();
            checks.Add("Take a shower");
            checks.Add("Brush your teeth");
            checks.Add("Do your hair");
            checks.Add("Put on perfume/deodorant");
            checks.Add("Put on adequate clothing");
            checks.Add("Go to the toilet beforehand");
            if (Userinfo.Data[1].Substring(0, 1) == "W")
            {
                checks.Add("Do your makeup");
            }

            for (int te = 0; te < checks.Count; te++)
            {
                CheckBox c1 = new CheckBox(this); c1.Text = checks[te]; menu.AddView(c1);
                but.Add(c1);
            }

            LinearLayout buttonmenu = new LinearLayout(this);
            buttonmenu.Orientation = Orientation.Horizontal;
            buttonmenu.SetBackgroundColor(Color.LightCyan);
            buttonmenu.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
            buttonmenu.SetPadding(0, 5, 0, 0);
            int w = Resources.DisplayMetrics.WidthPixels;

            Button Back = new Button(this); Back.Text = "Back"; Back.SetWidth(w / 2); Back.Click += klikback; buttonmenu.AddView(Back);
            Button Ready = new Button(this); Ready.Text = "Ready"; Ready.SetWidth(w / 2); Ready.Click += klikready; buttonmenu.AddView(Ready);

            menu.AddView(buttonmenu);
            this.SetContentView(upmenu);
        }
        public void klikready(object o, EventArgs ea)
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(Endscreen));
            mContext.StartActivity(i);
        }
        public void klikback(object o, EventArgs ea)
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(InfoPage));
            mContext.StartActivity(i);
        }
    }
}