using System;
using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Graphics;

namespace Date_mate
{
    public static class GameBase
    {
        public static List<Question> questions = new List<Question>();
        public static List<Text> textData = new List<Text>();
        public static List<Text> texts = new List<Text>();
        public static String number = "0";
        public static String textnumber = "0";

        public static void startgame(bool bo)
        {

            QuestionData();
            TextData();

            //Context mContext = Application.Context;
            //Intent i = new Intent(mContext, typeof(InfoPage));
            //i.PutExtra("start", number);
            //mContext.StartActivity(i);
            if(bo)
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(InfoPage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(inleidPage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }

        }
        public static void endgame()
        {
            number = "0";
            textnumber = "0";
            textData = new List<Text>();
            texts = new List<Text>();
            Userinfo.delete();

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(Main));
            mContext.StartActivity(i);
        }
        public static void nextquestion(string s)
        {
            number = s;
            if (s == "8" || s == questions.Count.ToString())
            {
                startText();
            }
            else if (questions[int.Parse(number)].Ask.Substring(0, 1) == "x")
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(CheckPage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
            else if (questions[int.Parse(number)].Ask.Substring(0, 1) == "q")
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(agreePage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(QuestionPage));
                i.PutExtra("start", number);
                mContext.StartActivity(i);
            }
        }
        public static void startText()
        {
            texts = Userinfo.userText(textData);
            List<Text> bv = new List<Text>();

            if (texts.Count == 0)
            {
                startInfoPage();
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(TextPage));
                i.PutExtra("start", textnumber);
                mContext.StartActivity(i);
            }
        }
        public static void nextText()
        {
            int t = int.Parse(textnumber);
            t++;
            textnumber = t.ToString();

            if (texts.Count == int.Parse(textnumber))
            {
                startInfoPage();
            }
            else
            {
                Context mContext = Application.Context;
                Intent i = new Intent(mContext, typeof(TextPage));
                i.PutExtra("start", textnumber);
                mContext.StartActivity(i);
            }
        }
        public static void previousText()
        {
            int t = int.Parse(textnumber);
            t--;
            textnumber = t.ToString();

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(TextPage));
            i.PutExtra("start", textnumber);
            mContext.StartActivity(i);
        }
        public static void startInfoPage()
        {
            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(InfoPage));
            mContext.StartActivity(i);
        }
        public static void InfoPageLink(int t)
        {

            Context mContext = Application.Context;
            Intent i = new Intent(mContext, typeof(InfoPageLinkPage));
            i.PutExtra("start", t.ToString());
            mContext.StartActivity(i);
        }
        public static Text getSpecificText(String s)
        {
            return textData[int.Parse(s)];
        }
        public static List<Text> getTextData
        {
            get { return textData; }
            set { }
        }
        public static int getTextCount
        {
            get { return texts.Count; }
            set { }
        }
        public static Text getTextinfo
        {
            get { return texts[int.Parse(textnumber)]; }
            set { }
        }
        public static Question Quest
        {
            get { return questions[int.Parse(number)]; }
            set { }
        }
        public static void QuestionData()
        {
            Question q0 = new Question("What is your age?");
            q0.AddAnswer("10-18");
            q0.AddAnswer("118-21");
            q0.AddAnswer("122-25");
            q0.AddAnswer("126-40");
            q0.AddAnswer("130+");
            questions.Add(q0);
            Question q1 = new Question("What is your gender");
            q1.AddAnswer("2Man");
            q1.AddAnswer("2Women");
            questions.Add(q1);
            Question q2 = new Question("How much experience do you have with dating??");
            q2.AddAnswer("3No experience (Never dated before)");
            q2.AddAnswer("3Not much experience (Have had a few dates)");
            q2.AddAnswer("3Avarage experience (Have had multiple dates with a few different persons)");
            q2.AddAnswer("3A fair bit of experience (Have had frequent dates with different persons)");
            q2.AddAnswer("3A lot of experience (Have had a lot of dates dates with different persons)");
            questions.Add(q2);
            Question q3 = new Question("Do you think you need to improve in finding a good dating location?");
            q3.AddAnswer("4Yes");
            q3.AddAnswer("4No");
            questions.Add(q3);
            Question q4 = new Question("Do you think you have to improve in avoiding awkward silences/ not knowing what to talk about?");
            q4.AddAnswer("5Yes");
            q4.AddAnswer("5No");
            questions.Add(q4);
            Question q5 = new Question("qHow much do you agree with the following statements about yourself in the context of dating:");
            q5.AddAnswer("6I can correctly identify other people’s emotions.");
            q5.AddAnswer("6I can correctly identify other people’s needs.");
            q5.AddAnswer("6I recall what other persons recently have said.");
            q5.AddAnswer("6I recall what other people have said at the beginning of the conservation.");
            q5.AddAnswer("6I can focus on other people.");
            questions.Add(q5);
            Question q6 = new Question("qHow much do you agree with the following statements about yourself in the context of dating:");
            q6.AddAnswer("7I feel calm.");
            q6.AddAnswer("7I am tense.");
            q6.AddAnswer("7I feel upset.");
            q6.AddAnswer("7I am relaxed.");
            q6.AddAnswer("7I feel content.");
            q6.AddAnswer("7I am worried.");
            questions.Add(q6);
            Question q7 = new Question("qHow much do you agree with the following statements about yourself:");
            q7.AddAnswer("8I feel confident about my appearance and attitude.");
            q7.AddAnswer("8I feel confident in conservations.");
            q7.AddAnswer("8I can enjoy social situations without being focused on how other think of me.");
            q7.AddAnswer("8I am not shy to share my honest opinion without being focused on what others think of me.");
            q7.AddAnswer("8In social situations, I feel relaxed and can focus and listen well to others.");
            q7.AddAnswer("8In social situations, I often do not fully feel present because I am too focused on what to say next.");
            questions.Add(q7);
        }
        public static void TextData()
        {
            Text t1 = new Text("Awkward silences/Not knowing what to say");
            t1.AddAlinea("-Learn some basic icebreakers");
            t1.AddAlinea("You don't need world-class speaking skills to make good small talk. Just remember a few simple questions you can use to fill the silence. Ask the person you are dating basic thing like: Where are you from and what do you do for fun?");
            t1.AddAlinea("-Think of topics ahead of time");
            t1.AddAlinea("Before going to the date, think of a few go to topics to jumpstart a dead conversation. This will help you to fill the silences so that you aren’t scrambling for words in the moment.");
            t1.AddAlinea("-Avoid flat responses");
            t1.AddAlinea("Responding with a simple yes or no is sure to create awkward silences. Avoid asking questions that prompt simple yes or no answers. If your date asks you one of these questions, be sure to add to it in order to keep the conversation moving. For example, if someone asks you, “Do you like sports?”, don’t simply say “yes” or “no.” Instead, explain your response and share some personal information. You could say something like, “Yes, I love to ski. I’ve been skiing since I was a young child. Some of my favorite family memories are on the slopes. What sports do you enjoy?”");
            t1.AddAlinea("-Take off the pressure");
            t1.AddAlinea("If you put a great deal of pressure on yourself to keep the conversation going, you will divert your focus from the actual conversation. Instead, be present and respond to what the other person is saying. Be open to allowing the conversation to go in whichever path it takes. When in doubt, take a deep breath and relax. Your prepared topics are just to get the conversation flowing. If you've moved on to new subjects, you've already succeeded!");
            t1.AddAlinea("-Share information gradually");
            t1.AddAlinea("If you blurt out everything at once, the conversation probably won’t last very long. Instead, gradually insert information about yourself into the conversation and allow time for the other person to contribute as well. This will prolong your conversation and keep awkward silences to a minimum.");
            t1.AddAlinea("-Talk about your passions");
            t1.AddAlinea("If you're enthusiastic and proud about what you do, your date will most likely respond to that passion. Talk about the personal achievements or goals that make you unique and give insight to your personality.");
            t1.AddAlinea("-Tell a story");
            t1.AddAlinea("During a pause, share new information about yourself in the form of an entertaining story. You could say something like, “The funniest thing happened to me the other night.” Then share a memorable experience that you had. Maybe you recently were locked out of your house and had to find a way to break in. A good story will engage the other person and take the conversation further.");
            t1.AddAlinea("-Change the subject");
            t1.AddAlinea("It may not be that you have run out of things to say, only that the topic of conversation has been played out. Take the conversation in a different direction by talking about the news or the weather or your favorite book — anything to break away from the previous conversation.");
            t1.AddAlinea("-Find the general tone");
            t1.AddAlinea("Sometimes awkward silences are the result of an inappropriate comment. If you aren’t sure whether the person will appreciate your racy sense of humor, hold off on making the joke until you are confident it will be well received.");
            t1.AddAlinea("-Listen carefully to your acquaintance and respond accordingly");
            t1.AddAlinea("As with any good conversation, the biggest key is to listen. If they respond to your question with a short, flat statement such as Yep or Nope\that might indicate that they aren’t very comfortable talking about that particular subject. Instead, talk about something that you know they’re interested in.");
            t1.AddAlinea("-Build on previous statements");
            t1.AddAlinea("This is a natural way to fill a silence. If you mentioned the pouring rain and your new companion expressed concern about his dog getting sick in the cold, wet weather, this is a great way to move the conversation along. Now you can spend some time talking about dogs, which will likely lead to another topic. By finding common ground with the current subject and adding additional relevant information, the conversation will continue.");
            t1.AddAlinea("-Ask questions");
            t1.AddAlinea("Find out about the person's hobbies and interests. People love talking about what they like! This is a great way to get to know them better and to change the subject in a positive way in the event of a pause. This will also make future conversations less awkward, as the two of you learn about each other's interests.");
            t1.AddAlinea("-Accepting the silence");
            t1.AddAlinea("Just because there is a pause in the conversation doesn’t mean it has to be awkward. Perhaps the person is thinking before responding or maybe there is simply a natural pause. Take this opportunity to connect in other ways such as by making eye contact or just being present with the person. Silence doesn’t have to be awkward. It can be filled in other ways besides words.");
            t1.AddAlinea("-Avoid awkward behaviour");
            t1.AddAlinea("Focusing on something other than your conversation partner is a sure way to make them uncomfortable and add to the awkwardness. For example, don't take out your phone and start checking for messages. Not only will they feel unimportant, but they might even leave! Find productive ways to deal with silence that involve both of you. If you really feel the need to look at your phone, you can involve the other person by showing them a short video clip or sharing a song with them. This can spark a new conversation.");
            textData.Add(t1);
            Text t2 = new Text("Anxiety and Stress");
            t2.AddAlinea("Anxiety and stress are for a lot of people big factors in dates. It can cause awkward situations or a bad impression to the other person. The best way of dealing with stress and anxiety is by doing mindfullnes exercises to help you relax and focus. So here are 6 usefull mindfullnes exercises");
            t2.AddAlinea("1. Mindfull breathing");
            t2.AddAlinea("This exercise can be done standing up or sitting down, and pretty much anywhere at any time. If you can sit down in the meditation (lotus) position, that's great, if not, no worries. Either way, all you have to do is be still and focus on your breath for just one minute.");
            t2.AddAlinea("1. Start by breathing in and out slowly. One breath cycle should last for approximately 6 seconds.");
            t2.AddAlinea("2. Breathe in through your nose and out through your mouth, letting your breath flow effortlessly in and out of your body.");
            t2.AddAlinea("3. Let go of your thoughts. Let go of things you have to do later today or pending projects that need your attention. Simply let thoughts rise and fall of their own accord and be at one with your breath.");
            t2.AddAlinea("4. Purposefully watch your breath, focusing your sense of awareness on its pathway as it enters your body and fills you with life.");
            t2.AddAlinea("5. Then watch with your awareness as it works work its way up and out of your mouth and its energy dissipates into the world.");
            t2.AddAlinea("If you are someone who thought they’d never be able to meditate, guess what? You are halfway there already! If you enjoyed one minute of this mind-calming exercise, why not try two or three?");
            t2.AddAlinea("2. Mindfull observation");
            t2.AddAlinea("This exercise is simple but incredibly powerful because it helps you notice and appreciate seemingly simple elements of your environment in a more profound way.The exercise is designed to connect us with the beauty of the natural environment, something that is easily missed when we are rushing around in the car or hopping on and off trains on the way to work.");
            t2.AddAlinea("1. Choose a natural object from within your immediate environment and focus on watching it for a minute or two. This could be a flower or an insect, or even the clouds or the moon.");
            t2.AddAlinea("2. Don’t do anything except notice the thing you are looking at. Simply relax into watching for as long as your concentration allows.");
            t2.AddAlinea("3. Look at this object as if you are seeing it for the first time.");
            t2.AddAlinea("4. Visually explore every aspect of its formation, and allow yourself to be consumed by its presence.");
            t2.AddAlinea("5. Allow yourself to connect with its energy and its purpose within the natural world.");
            t2.AddAlinea("3. Mindful awareness");
            t2.AddAlinea("This exercise is designed to cultivate a heightened awareness and appreciation of simple daily tasks and the results they achieve.");
            t2.AddAlinea("Think of something that happens every day more than once; something you take for granted, like opening a door, for example.At the very moment you touch the doorknob to open the door, stop for a moment and be mindful of where you are, how you feel in that moment and where the door will lead you.");
            t2.AddAlinea("Similarly, the moment you open your computer to start work, take a moment to appreciate the hands that enable this process and the brain that facilitates your understanding of how to use the computer.These ‘touch point' cues don’t have to be physical ones.");
            t2.AddAlinea("For example: Each time you think a negative thought, you might choose to take a moment to stop, label the thought as unhelpful and release the negativity. Or, perhaps each time you smell food, you take a moment to stop and appreciate how lucky you are to have good food to eat and share with your family and friends.");
            t2.AddAlinea("Choose a touch point that resonates with you today and, instead of going through your daily motions on autopilot, take occasional moments to stop and cultivate purposeful awareness of what you are doing and the blessings these actions brings to your life.");
            t2.AddAlinea("4. Mindful listening");
            t2.AddAlinea("This exercise is designed to open your ears to sound in a non-judgmental way, and indeed to train your mind to be less swayed by the influence of past experiences and preconception.");
            t2.AddAlinea("So much of what we “feel” is influenced by past experience. For example, we may dislike a song because it reminds of us of a breakup or another period of life when things felt negative. So the idea of this exercise is to listen to some music from a neutral standpoint, with a present awareness that is unhindered by preconception.");
            t2.AddAlinea("Select a piece of music you have never heard before. You may have something in your own collection that you have never listened to, or you might choose to turn the radio dial until something catches your ear.");
            t2.AddAlinea("1. Close your eyes and put on your headphones.");
            t2.AddAlinea("2. Try not to get drawn into judging the music by its genre, title or artist name before it has begun. Instead, ignore any labels and neutrally allow yourself to get lost in the journey of sound for the duration of the song.");
            t2.AddAlinea("3. Allow yourself to explore every aspect of track. Even if the music isn’t to your liking at first, let go of your dislike and give your awareness full permission to climb inside the track and dance among the sound waves.");
            t2.AddAlinea("4. Explore the song by listening to the dynamics of each instrument. Separate each sound in your mind and analyze each one by one.");
            t2.AddAlinea("5. Hone in on the vocals: the sound of the voice, its range and tones. If there is more than one voice, separate them out as you did in step 4.");
            t2.AddAlinea("The idea is to listen intently, to become fully entwined with the composition without preconception or judgment of the genre, artist, lyrics or instrumentation. Don't think, hear.");
            t2.AddAlinea("5. Mindfull immersion");
            t2.AddAlinea("The intention of this exercise is to cultivate contentment in the moment and escape the persistent striving we find ourselves caught up in on a daily basis.Rather than anxiously wanting to finish an everyday routine task in order to get on with doing something else, take that regular routine and fully experience it like never before.");
            t2.AddAlinea("For example: if you are cleaning your house, pay attention to every detail of the activity. Rather than treat this as a regular chore, create an entirely new experience by noticing every aspect of your actions:");
            t2.AddAlinea("Feel and become the motion when sweeping the floor, sense the muscles you use when scrubbing the dishes, develop a more efficient way of wiping the windows clean.The idea is to get creative and discover new experiences within a familiar routine task.");
            t2.AddAlinea("Instead of labouring through and constantly thinking about finishing the task, become aware of every step and fully immerse yourself in the progress. Take the activity beyond a routine by aligning yourself with it physically, mentally and spiritually.Who knows, you might even enjoy the cleaning for once!");
            t2.AddAlinea("6. Minfull appreciaton");
            t2.AddAlinea("In this last exercise, all you have to do is notice 5 things in your day that usually go unappreciated.These things can be objects or people; it’s up to you. Use a notepad to check off 5 by the end of the day.The point of this exercise is to simply give thanks and appreciate the seemingly insignificant things in life, the things that support our existence but rarely get a second thought amidst our desire for bigger and better things.");
            t2.AddAlinea("For example: electricity powers your kettle, the postman delivers your mail, your clothes provide you warmth, your nose lets you smell the flowers in the park, your ears let you hear the birds in the tree by the bus stop, but…");
            t2.AddAlinea("-Do you know how these things/processes came to exist, or how they really work?");
            t2.AddAlinea("-Have you ever properly acknowledged how these things benefit your life and the lives of others?");
            t2.AddAlinea("-Have you ever thought about what life might be like without these things?");
            t2.AddAlinea("-Have you ever stopped to notice their finer, more intricate details?");
            t2.AddAlinea("-Have you ever sat down and thought about the relationships between these things and how together they play an interconnected role in the functioning of the earth?");
            t2.AddAlinea("Once you have identified your 5 things, make it your duty to find out everything you can about their creation and purpose to truly appreciate the way in which they support your life.");
            textData.Add(t2);
            Text t3 = new Text("Low self-esteem");
            t3.AddAlinea("Low self-esteem can have big impact on a date, but also in generall low self-esteem can cause you not to live life to the fullest. With these 5 tips you can improve your self confidence and higher you self-esteem.");
            t3.AddAlinea("1. Think hard about the root cause(s) of your insecurities. The first step to defeating a formidable foe is to learn about them, and this situation is no different. Identifying the events that led to a low sense of self-worth can provide invaluable information for challenging these negative beliefs.");
            t3.AddAlinea("2. After you identify these root causes to your insecurities, the next step will be to think about these causes and how they affect you right now and in the future.");
            t3.AddAlinea("3. Be kind to yourself. If you find yourself being excessively negative to yourself, stop and consider how you would feel if someone said these things about a close friend or family member. Extend that kindness and compassion to yourself.");
            t3.AddAlinea("4. Make a plan. Set achievable and realistic short-term goals for yourself to complete in the next week or so. That sense of achievement, however small the achievement, can be an excellent boost to your motivation and commitment to improve.");
            t3.AddAlinea("5. Celebrate your success. When you meet a goal, successfully challenge a negative thought, or catch yourself extending kindness towards yourself, mark the achievement with a celebration! Taking the time to revel in your success and enjoy the moment can give you the inspiration you need to continue your journey to self-improvement.");
            textData.Add(t3);
            Text t4 = new Text("Dating locations");
            t4.AddAlinea("The location of a date can be very important. A good date location can add a lot of stuff to talk about and can make a date much more exciting, but a bad dating location can distract you from the date and have a negative impact on the date. So here are some idea for fun and exciting date locations.");
            t4.AddAlinea("-On a bench in a park");
            t4.AddAlinea("Secure a spot on a bench or on the lawn on a busy street or in a crowded park and let the people around you serve as food for thought.");
            t4.AddAlinea("-The zoo");
            t4.AddAlinea("Who doesn't love seeing exotic animals and cuddly zoo creatures (at a comfortable distance)? This one's a easy date idea if you do it when it isn't too busy.");
            t4.AddAlinea("-Flea market");
            t4.AddAlinea("If you want to breeze through an hour or two on a date while getting some shopping in, invite your date to a flea market with enoigh activities so you'll never get bored. Large flea markets typicall invole shopping, food and drinks so you can catch up over and iced coffe or peruse the tents together.");
            t4.AddAlinea("-Arcade games");
            t4.AddAlinea("For those with a short attention span and a adventurous spirit. Get to know your date over an adrenaline-racing round of arcade games. Play up your competitive side or join forces as a team against another pair with a game of table football.");
            t4.AddAlinea("-Botanical garden");
            t4.AddAlinea("There's no better place to explore on a date than the pretty manicured lawns and gardens of a botanical garden. Pro tip: plan to go later in the day or after the summer rush if you don't want to find yourself sweating in a greenhouse at mid-day.");
            t4.AddAlinea("-Planetarium");
            t4.AddAlinea("The hushed atmosphere of a planetarium combined with the dark room make for an ideal ambiance for a first date. Spend an evening gazing at the starts and learning about the constellations, with lots of hand-holding potential.");
            textData.Add(t4);
        }
    }
}