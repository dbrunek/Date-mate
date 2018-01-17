using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    public static class Userinfo
    {
        public static List<string> Data = new List<string>();

        public static void Opslaan(String q, String a)
        {
            String qa = "q" + q + "|" + a;
            Data.Add(qa);
        }
        public static void Checkopslaan(List<boynextdoor> b)
        {
            String s = "";
            foreach(boynextdoor n in b)
            {
                s = s + n.answer + "|" + n.ja + " ";
            }
            s = "c" + s;
            Data.Add(s);
        }
        public static List<Text> userText(List<Text> t)
        {
            return t;
        }
    }
}