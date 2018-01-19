using System;
using System.Threading.Tasks;
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
            String qa = a + "|" + q;
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
        public static void agreeopslaan(List<string> s)
        {
            for(int i = 0; i < s.Count; i++)
            {
                Data.Add(s[i]);
            }
        }
        public static void delete()
        {
            Data = new List<string>();
        }
        public static List<Text> userText(List<Text> t)
        {
            List<Text> retext = new List<Text>();
            int stress = 0;
            int anxiety = 0;
            int selfesteem = 0;

            if(Data[3].Substring(0,1) == "Y")
            {
                retext.Add(t[3]);
            }
            if(Data[4].Substring(0,1) == "Y")
            {
                retext.Add(t[0]);
            }

            Data[11] = ((int.Parse(Data[11].Substring(0, 1)) * -1) + 4).ToString() + Data[11].Substring(1,(Data[11].Length -1));
            Data[12] = ((int.Parse(Data[12].Substring(0, 1)) * -1) + 4).ToString() + Data[12].Substring(1, (Data[11].Length - 1));
            Data[15] = ((int.Parse(Data[15].Substring(0, 1)) * -1) + 4).ToString() + Data[15].Substring(1, (Data[11].Length - 1));

            for (int i = 5; i < 10; i++)
            {
                stress = stress + int.Parse(Data[i].Substring(0,1));
            }
            for (int i = 10; i < 16; i++)
            {
               anxiety = anxiety + int.Parse(Data[i].Substring(0, 1));
            }
            for (int i = 16; i < 22; i++)
            {
                selfesteem = selfesteem + int.Parse(Data[i].Substring(0, 1));
            }
            if(stress + anxiety < 25)
            {
                retext.Add(t[1]);
            }
            if (selfesteem < 15)
            {
                retext.Add(t[2]);
            }
            return retext;
        }
    }
}