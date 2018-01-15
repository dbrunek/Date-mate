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
        protected override void OnCreate(Bundle b)
        {
            base.OnCreate(b);

            LinearLayout menu = new LinearLayout(this);
            menu.Orientation = Orientation.Vertical;
            menu.SetBackgroundColor(Color.Yellow);

            TextView q1 = new TextView(this); q1.Text = "TextPage"; q1.TextSize = 10; q1.SetTextColor(Color.Black); menu.AddView(q1);

            this.SetContentView(menu);
        }
    }
}