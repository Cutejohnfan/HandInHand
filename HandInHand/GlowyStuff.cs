using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class GlowyStuff : StoryboardObjectGenerator
    {
        StoryboardLayer layer;
        StoryboardLayer layer2;

        [Configurable]

        public int imtoolazytoadjustrestart = 0;

        [Configurable]

        public int output2value = 0;

        public void intro()
        {
            var starttime = 7850;
            var endtime=15350;
            var particleAmount = Random(2,4);

            string[] typesofcolors = new string[]
            {

                        "#FF7F50","#FFFF8A","#CB8AFF","#97ED6E" // Pink, Purple, Orange

            };

            layer = GetLayer("glow");
            for(int t = starttime; t < endtime; t += 428 ) //How many times it happens, for this case its 5 times/waves
            {
                for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
                {
                    var randomcolor = Random(0,3);
                    var RandomXstart = Random(0,640);
                    var RandomYstart = Random(0,480);

                    //Log(RandomXstart);

                    var RandomXend = Random(-30,30);
                    var RandomYend = Random(-30,30);

                    double RandomScale = Random(0.000,1.200);

                    var sprite = layer.CreateSprite("sb/dot.png"); 
                    sprite.Fade(t+1000,t+2000,0,0.4);
                    //sprite.Fade(endtime,0);
                    sprite.Move(OsbEasing.InQuad,t,t+10000,RandomXstart,RandomYstart,RandomXstart+RandomXend,RandomYstart+RandomYend);
                    sprite.Scale(OsbEasing.InQuad,t,t+5000,0,RandomScale);
                    sprite.Color(t,typesofcolors[randomcolor]);
                    sprite.Additive(t);



                }
            }


        }

        public void pentagram(int starttime, int endtime)
        {
            layer = GetLayer("penta");
            int particleAmount = 1;
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;
            int loopTimes = (endtime - starttime) / 5000;
  
            for(int t = starttime; t < endtime; t += 937 ) //How many times it happens, for this case its 5 times/waves
            {
                for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
                {

                    randomX = Random(-100,754); // Random X axis //also the limit of X
                    randomY = Random(0,480); // Random Y axis //Also the limit of Y
                    rndTime = Random (-400,400); //Random Time

                    var sprite = layer.CreateSprite("sb/pentagon.png"); 

                    string[] typesofcolors = new string[]
                    {

                    "#B9E9C9","#FFFF8A"

                    };

                    var randomtypeofcolorchoose = Random(2);

                    sprite.Color(t + rndTime, typesofcolors[randomtypeofcolorchoose]);

                    rndTET = Random(0, 2*Math.PI);
                    r = Random(10,35);
                    x = randomX + r * Math.Cos(rndTET);
                    y = randomY + r * Math.Sin(rndTET);

                    rndSCL = Random(70,90) / 100.0; //Randomized Scale

                    sprite.Fade(t,t+1000,0.4,0.4);

                    sprite.Scale(t,t+1000,rndSCL,rndSCL);



                    sprite.Rotate(t,t+5000,0,3);
                    sprite.Fade(t+5000,t+5000,0.4,0);
                    sprite.Move(t,t+4500,randomX,590,x,-300);

                }
            }
            
        }
        // public void dot(int starttime, int endtime)
        // {
        //     layer = GetLayer("dot");
        //     var colora = new Color4(67,240,208, 1);
        //     var colorb = new Color4(252, 96, 96, 1);

        //     int particleAmount = Random(25,35);
        //     int randomX, randomY, r, rndTime;
        //     double rndTET, rndSCL;
        //     double x,y;


        //     int loopTimes = (endtime - starttime) / 5000;
  
        //     for(int t = starttime; t < starttime+5000; t += 1000 ) //How many times it happens, for this case its 5 times/waves
        //     {
        //         for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
        //         {

        //             randomX = Random(-100,754); // Random X axis //also the limit of X
        //             randomY = Random(0,480); // Random Y axis //Also the limit of Y
        //             rndTime = Random (-400,400); //Random Time

        //             var sprite = layer.CreateSprite("sb/dot.png"); 

        //             sprite.Color(t + rndTime, "FFFFFF");
        //             sprite.Color(101783,103629,"FFFFFF","#FFFF00");
        //             sprite.Color(105475,"FFFFFF");

        //             sprite.Color(142398,147937,"FFFFFF","#FFFF00");
        //             sprite.Color(149783,"FFFFFF");

        //             rndTET = Random(0, 2*Math.PI);
        //             r = Random(10,35);
        //             x = randomX + r * Math.Cos(rndTET);
        //             y = randomY + r * Math.Sin(rndTET);
        //             rndSCL = Random(5,10) / 100.0; //Randomized Scale

        //             sprite.StartLoopGroup(t + rndTime, loopTimes);
        //             sprite.Fade(0,1000,0,1);
        //             sprite.Scale(0,1000,0,rndSCL);
        //             sprite.Fade(5000,5000,1,0);
        //             //sprite.Scale(4000,5000,1,0);
        //             sprite.Move(0,5000,randomX,490,x,-300);
        //             //sprite.Move(0,5000,randomX,randomY,x,y);
        //             sprite.EndGroup();

        //         }
        //     }
        // }

        public void myowndotbutituseseasingslow(int startime,int endtime)
        {
            layer = GetLayer("SlowDotFront"); 
            layer2 = GetLayer("SlowDotBack"); 

            int particleAmount = Random(5,9);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            for(int t=startime; t<endtime-2000 ; t+=468) // A affects here, t
            {
                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 17000;
                var output2 = 5000;

                layer = GetLayer("SlowDotFront"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 

                // C affects here
                sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);
                sprite.Fade(t+output2,t+output2,1,0);
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480

                var sprite2 = layer.CreateSprite("sb/dot.png"); 
                sprite2.Fade(t,t+100,0,1);
                sprite2.Scale(t,t+100,0,rndSCL);
                sprite2.Fade(t+output2,t+output2,1,0);
                sprite2.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                

                }


            }

        }
        

        public void myowndotbutituseseasingslowtransitiontomedium(int startime,int endtime)
        {
            layer = GetLayer("MediumTransition"); 

            double particlemin = 5;
            double particlemax = 10;
            double particleAmount = Random(particlemin,particlemax);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;
            var snapcalculate = (endtime - startime)/468;

            var slowtomedium = (17000-10000)/snapcalculate;

            var output = 17000;



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
                //Log("debug");
                endlife-=slowtomedium;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;
                
                particleAmount = Random(particlemin,particlemax);

                // Log(t);
                // Log(endlife);
                // Log(constant);
                // Log("Result " + endparticleconstant);
                // Log("Result of endparticle no constant " + endparticle);

                // B affects here

                for(int abc=0; abc<(int)particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //layer = GetLayer("Slowtransition"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 

            
                // C affects here
                //sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);

                                //Weird?
                                //Log("Dot end particle end is " + endparticleconstant); //Debug
                                //sprite.Fade(endparticleconstant,endparticleconstant+200,1,0); //Why command overlapped when endtime is more than starttime???

                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                //Idea: speed increase overtime, 17000 to 10000
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }

                Log("Speed is now: " + output);

                output-=slowtomedium;
                particlemin+=0.3;
                particlemax+=0.3;
                


            }

        }

        public void myowndotbutituseseasingmedium(int startime,int endtime)
        {
            int particleAmount = Random(5,9);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            for(int t=startime; t<endtime-3000 ; t+=468) // A affects here, t
            {
                //Log("T value now is " + t);
                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 10000;
                var output2 = 3500;

                // C affects here
                layer = GetLayer("MediumDotFront"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 
                sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);
                sprite.Fade(t+output2,t+output2,1,0);
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                layer = GetLayer("MediumDotBack"); 
                sprite = layer.CreateSprite("sb/dot.png"); 
                sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);
                sprite.Fade(t+output2,t+output2,1,0);
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480

                }


            }

        }

        public void myowndotbutituseseasingmediumtransitiontoslow(int startime,int endtime)
        {
            layer = GetLayer("MediumTransition"); 


            double particlemin = 10;
            double particlemax = 15;
            double particleAmount = Random(particlemin,particlemax);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;

            //Debug is 1875

            var snapcalculate = (endtime - startime)/468; //Debug 4

            var mediumtoslow = (17000-10000)/snapcalculate; //Debug 1750

            var output = 10000;



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {

                particleAmount = Random(particlemin,particlemax);
                
                
                //Log("debug");
                endlife+=mediumtoslow;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // Log(t);
                // Log(endlife);
                // Log(constant);
                // Log("Result " + endparticleconstant);
                // Log("Result of endparticle no constant " + endparticle);

                // B affects here

                for(int abc=0; abc<(int)particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //layer = GetLayer("Slowtransition"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 

            
                // C affects here
                //sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);

                                //Weird?
                                //Log("Dot end particle end is " + endparticleconstant); //Debug
                                //sprite.Fade(endparticleconstant,endparticleconstant+200,1,0); //Why command overlapped when endtime is more than starttime???

                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                //Idea: speed increase overtime, 17000 to 10000
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }

                //Log("Speed is now: " + output);

                output+=mediumtoslow;
                particlemin-=0.1;
                particlemax-=0.1;
                


            }

        }

        public void myowndotbutituseseasingmediumtransitiontofast(int startime,int endtime)
        {
            layer = GetLayer("FastTransition"); 


            int particleAmount = Random(15,20);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;
            var snapcalculate = (endtime - startime)/468;

            var mediumtofast = (10000-6000)/snapcalculate;

            var output = 10000;



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
                //Log("debug");
                endlife-=mediumtofast;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // Log(t);
                // Log(endlife);
                // Log(constant);
                // Log("Result " + endparticleconstant);
                // Log("Result of endparticle no constant " + endparticle);

                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,700); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //layer = GetLayer("Slowtransition"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 

            
                // C affects here
                //sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);

                                //Weird?
                                //Log("Dot end particle end is " + endparticleconstant); //Debug
                                //sprite.Fade(endparticleconstant,endparticleconstant+200,1,0); //Why command overlapped when endtime is more than starttime???

                sprite.Move(OsbEasing.OutQuart,t,t+output+1200,randomX,randomY,x,y);
                //Idea: speed increase overtime, 17000 to 10000
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }

                //Log("Speed is now: " + output);

                output-=mediumtofast;
                


            }

        }

        public void myowndotbutituseseasingfasttransitiontomedium(int startime,int endtime)
        {
            layer = GetLayer("FastTransition"); 


            int particleAmount = Random(23,25);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = endtime-startime+468;//2343 current; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            var gradient = 0;
            var snapcalculate = (endtime - startime)/468;

        

            var Fasttomedium = (10000-6000)/snapcalculate;

            var output = 6000;

            Log("Snap calculate " + snapcalculate);
            Log("Fasttomedium " + Fasttomedium);



            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                Log("Speed is now: " + output);
                
                
                //Log("debug");
                endlife+=Fasttomedium;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // Log(t);
                // Log(endlife);
                // Log(constant);
                // Log("Result " + endparticleconstant);
                // Log("Result of endparticle no constant " + endparticle);

                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,700); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-300,-200);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                //layer = GetLayer("Slowtransition"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 

            
                // C affects here
                //sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);

                                //Weird?
                                //Log("Dot end particle end is " + endparticleconstant); //Debug
                                //sprite.Fade(endparticleconstant,endparticleconstant+200,1,0); //Why command overlapped when endtime is more than starttime???

                sprite.Move(OsbEasing.OutQuart,t,t+output+1000,randomX,randomY,x,y);
                //Idea: speed increase overtime, 17000 to 10000
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }

                //Log("Speed is now: " + output);

                output+=Fasttomedium;



            }

        }

        

        public void myowndotbutituseseasingfast(int startime,int endtime)
        {
            int particleAmount = Random(4,8);
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            for(int t=startime; t<endtime-1000 ; t+=234) // A affects here, t
            {
                //Log("T value now is " + t);
                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 6000;
                var output2 = output2value;

                // C affects here
                layer = GetLayer("FastDotFront"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 
                sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);
                sprite.Fade(t+output2,t+output2,1,0);
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);

                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale

                layer = GetLayer("FastDotBack"); 
                sprite = layer.CreateSprite("sb/dot.png"); 
                sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);
                sprite.Fade(t+output2,t+output2,1,0);
                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480

                }


            }

        }

        public void myowndotbutituseseasingfasttransition(int startime,int endtime)
        {
            layer = GetLayer("MediumTransition"); 

            int particleAmount = Random(5,10 );
            int randomX, randomY, r, rndTime;
            double rndTET, rndSCL;
            double x,y;

            var endlife = 2343; // Or 1875 if back;
            var constant = 0; //Offset

            var endparticle = 0;
            var endparticleconstant = 0;

            for(int t=startime; t<endtime-1; t+=468) // A affects here, t
            {
                
                
               //Log("debug");
                endlife-=468;
                endparticle = t + endlife;
                endparticleconstant = t + endlife + constant;

                // Log(t);
                // Log(endlife);
                // Log(constant);
                // Log("Result " + endparticleconstant);
                // Log("Result of endparticle no constant " + endparticle);

                // B affects here

                for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
                {
                // Initializing variables
                randomX = Random(-100,754); // Random X axis //also the limit of X
                randomY = Random(500,600); // Random Y axis //Also the limit of Y
                rndTime = Random (-400,400); //Random Time
                rndTET = Random(0, 2*Math.PI);
                r = Random(10,35);
                x = randomX + r * Math.Cos(rndTET);
                //y = randomY + r * Math.Sin(rndTET);
                y = Random(-200,-100);
                rndSCL = Random(5,10) / 100.0; // Randomized Scale
                var output = 6000;
                var output2 = output2value;


                //layer = GetLayer("Slowtransition"); 
                var sprite = layer.CreateSprite("sb/dot.png"); 

            
                // C affects here
                //sprite.Fade(t,t+100,0,1);
                sprite.Scale(t,t+100,0,rndSCL);

                                //Weird?
                                //Log("Dot end particle end is " + endparticleconstant); //Debug
                                sprite.Fade(endparticleconstant,endparticleconstant+200,1,0); //Why command overlapped when endtime is more than starttime???

                sprite.Move(OsbEasing.OutQuart,t,t+output,randomX,randomY,x,y);
    
                
                //0 is top left
                //X-axis = 0-640 , Y-axis = 0-480
                }
                

            }

        }

        // public void myowndot(int startime,int endtime,int lifespeed)
        // {
        //     // Initializing variables
        //     layer = GetLayer("dot"); 
        //     int particleAmount = Random(25,35);
        //     int randomX, randomY, r, rndTime;
        //     double rndTET, rndSCL;
        //     double x,y;

        //     // Lifespeed affects this stuff: And input is in 4-5 digits, 1,000 - 99,999
        //     // Assuming we set 10,000 as fast, 50,000 is slow
        //     // Hypothetically, the lower the number, the faster it goes and vice versa.

        //     // A) Duration of the particles
        //     // 1870 is 1 beat
        //     // 935 is half beat
        //     // The slower the particle = the earlier it ends

        //     var calculationa = (int)(lifespeed*0.0625 + 1875);

        //     // Fast
        //     // lifespeed * ?? = 2,500
        //     // 10,000 * ?? = 2,500

        //     // Slow
        //     // lifespeed * ?? = 5,000
        //     // 50,000 * ?? = 5,000
        //     // x =  0.0625, y = 1875

        //     // D) Unconvinently, number of particles is also affected by A)
        //     // Ensure that particles are more or less the same even when changing
            
            
            
        //     // B) Spread of particles
        //     var calculationb = lifespeed;
            
        //     // C) Speed
        //     var calculationc = (int)(lifespeed * 0.125 + 3750);
        //     // Shorter number = faster
        //     // It is tested that 5000 is fast

        //     // Fast
        //     // lifespeed * ??? = 5,000
        //     // 10,000 * x + y = 5,000

        //     // Slow
        //     // lifespeed * ??? = 10,000
        //     // 50,000 * x + y = 10,000

        //     //x = 0.125, y = 3750


            

            

        //     for(int t=startime; t<endtime; t+=calculationa) // A affects here, t
        //     {
        //         //("T value now is " + t);
        //         // B affects here

        //         for(int abc=0; abc<particleAmount; abc++) //Basically generating the particles
        //         {
        //         // Initializing variables
        //         randomX = Random(-100,754); // Random X axis //also the limit of X
        //         randomY = Random(0,480); // Random Y axis //Also the limit of Y
        //         rndTime = Random (-400,400); //Random Time
        //         rndTET = Random(0, 2*Math.PI);
        //         r = Random(10,35);
        //         x = randomX + r * Math.Cos(rndTET);
        //         y = randomY + r * Math.Sin(rndTET);
        //         rndSCL = Random(5,10) / 100.0; // Randomized Scale


        //         var sprite = layer.CreateSprite("sb/dot.png"); 

        //         // C affects here
        //         sprite.Fade(t,t+100,0,1);
        //         sprite.Scale(t,t+100,0,rndSCL);
        //         sprite.Fade(t+calculationc,t+calculationc+100,1,0);
        //         sprite.Move(t,t+calculationc,randomX,490,x,-300);

        //         }


        //     }



        // }

        // public void musicnotes(int starttime, int endtime)
        // {
        //     var bassclef = "sb/notes/bassclef.png";
        //     var beamnotes = "sb/notes/beamnotes.png";
        //     var flat = "sb/notes/flat.png";
        //     var minim = "sb/notes/minim.png";
        //     var quaver = "sb/notes/quaver.png";
        //     var sharpflat = "sb/notes/sharpflat.png";
        //     var trebleclef = "sb/notes/trebleclef.png";

        //     string[] musicnotes = new string[]
        //     {
        //         bassclef,beamnotes,flat,minim,quaver,sharpflat,trebleclef
        //     };

        //     int particleAmount = Random(10,15);
        //     int randomX, randomY, r, rndTime;
        //     double rndTET, rndSCL;
        //     double x,y;


        //     int loopTimes = (endtime - starttime) / 5000;
  
        //     for(int t = starttime; t < starttime+5000; t += 1000 ) //How many times it happens, for this case its 5 times/waves
        //     {
        //         for (int i = 0; i < particleAmount ; i++) //Counter for particles, also particle life
        //         {

        //             randomX = Random(-100,754); // Random X axis //also the limit of X
        //             randomY = Random(0,480); // Random Y axis //Also the limit of Y
        //             rndTime = Random (-400,400); //Random Time

        //             var randomangleinit = Random(1,10);
        //             var randomangleconversioninit = (randomangleinit*(Math.PI/180));

        //             var randomanglefinan = Random(-1,-10);
        //             var randomangleconversionfinan = (randomanglefinan*(Math.PI/180));

        //             var randomnotes = Random(0,6);

        //             var tempnotes = musicnotes[randomnotes];

        //             var spriteconvertsion = tempnotes;

        //             var sprite = layer.CreateSprite(spriteconvertsion);

        //             sprite.Color(t + rndTime, "FFFFFF");
        //             sprite.Color(101783,103629,"FFFFFF","#FFFF00");
        //             sprite.Color(105475,"FFFFFF");

        //             sprite.Color(142398,147937,"FFFFFF","#FFFF00");
        //             sprite.Color(149783,"FFFFFF");

        //             rndTET = Random(0, 2*Math.PI);
        //             r = Random(10,35);
        //             x = randomX + r * Math.Cos(rndTET);
        //             y = randomY + r * Math.Sin(rndTET);

        //             rndSCL = Random(5,10) / 100.0; //Randomized Scale

        //             sprite.StartLoopGroup(t + rndTime, loopTimes);
        //             sprite.Fade(0,1000,0,1);
        //             sprite.Scale(0,1000,0,rndSCL);
        //             sprite.Fade(5000,5000,1,0);
        //             //sprite.Scale(4000,5000,1,0);
        //             sprite.Move(0,5000,randomX,490,x,-300);
        //             //sprite.Move(0,5000,randomX,randomY,x,y);
        //             sprite.Rotate(0,5000,randomangleconversioninit,randomangleconversionfinan);
        //             sprite.EndGroup();

        //         }
        //     }            


        // }
        public override void Generate()
        { //SLOW START 1 BAR EARLY, ENDS 2 BAR EARLY    
        //MEDIUM START 1 BAR EARLY, ENDS 1 BAR EARLY
        //FAST DOESNT NEED, POINT A POINT B.
		//dot(15350,302226); 

        //intro();

        myowndotbutituseseasingslow(15350,24491);// 1 small tick after
        myowndotbutituseseasingslowtransitiontomedium(22850,30585);
        myowndotbutituseseasingmedium(30585,42069);
        myowndotbutituseseasingmediumtransitiontoslow(39726,46288);
        myowndotbutituseseasingslow(45351,56366);
        myowndotbutituseseasingslowtransitiontomedium(54726,60116);
        myowndotbutituseseasingmedium(60116,70429);
        myowndotbutituseseasingmediumtransitiontofast(67382,75819);
        myowndotbutituseseasingfast(75819,101132);
        myowndotbutituseseasingfasttransitiontomedium(99725,104882);
        myowndotbutituseseasingmedium(105350,117538);
        myowndotbutituseseasingmediumtransitiontoslow(114725,119882);
        myowndotbutituseseasingslow(120350,129491);
        myowndotbutituseseasingslowtransitiontomedium(127850,134882);
        myowndotbutituseseasingmedium(135350,143788);
        myowndotbutituseseasingmediumtransitiontofast(140975,150350);
        myowndotbutituseseasingfast(150585,175663);
        myowndotbutituseseasingfasttransitiontomedium(174725,179882);
        myowndotbutituseseasingmedium(180350,213163);
        myowndotbutituseseasingmediumtransitiontofast(210350,224179);
        myowndotbutituseseasingfast(224413,250663);
        myowndotbutituseseasingfasttransitiontomedium(249725,255819);
        myowndotbutituseseasingmedium(256522,303163);
        
        // // myowndot(30350,45351,10000);
        // //musicnotes(30350,45351);
        pentagram(30350,43007);
        pentagram(105350,117069);
        pentagram(255350,300351);
            
        }
    }
}
