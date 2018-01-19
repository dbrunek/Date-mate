using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;


namespace Date_mate
{
    [Activity(Label = "Date_Mate", MainLauncher = true)]
    public class Main : Activity
    {
        Button start;

        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.LightCyan);
            menu.SetPadding(40, 0, 40, 0);

            TextView titel = new TextView(this); titel.Text = "Date Mate"; titel.TextSize = 80; titel.SetTextColor(Color.Black); menu.AddView(titel);

            start = new Button(this); start.Text = "Start"; start.Click += startgame; menu.AddView(start);

            Button info = new Button(this); info.Text = "Dating info"; info.Click += startinfo; menu.AddView(info);

            this.SetContentView(menu);
        }
        public void startinfo(object o, EventArgs ea)
        {
            GameBase.startgame(true);
        }
        public void startgame(object o, EventArgs ea)
        {
            GameBase.startgame(false);
        }

    }
}

