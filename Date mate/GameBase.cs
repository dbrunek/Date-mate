using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    public class GameBase
    {
        public GameBase()
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(Question));
            mContext.StartActivity(i);
        }
    }
}