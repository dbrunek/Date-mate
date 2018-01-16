using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    public class Text
    {
        public String Titel;
        public List<String> tekst = new List<String>();

        public Text(String s)
        {
            Titel = s;
        }
        public void AddAlinea(String s)
        {
            tekst.Add(s);
        }
        public List<String> getTekst
        {
            get { return tekst; }
            set { }
        }
        public String getTitel
        {
            get { return Titel; }
            set { }
        }
    }
}