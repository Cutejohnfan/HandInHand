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
    public class BackgroundMake : StoryboardObjectGenerator
    {
        StoryboardLayer layer;

    [Configurable]
    public int sizex = 2000;

    [Configurable]
    public int sizey = 2000;

    [Configurable]
    public int stupidvalueresettooslow = 0;

    [Configurable]
    public int startx = -275;

    [Configurable]
    public int starty = 240;

    [Configurable]
    public int endx = 829;

    [Configurable]
    public int endy = 240;

    public void barsweeplefttoright(int starttime)
        {
        var A = 1200; //SizeX
        var B = 1200; //SizeY
        var C = 320; //StartX
        var D = 240; //StartY
        var E = 1920; //EndX
        var F = 240; //EndY
        var endtime = starttime + 819;
        var initialrotation = -30;
        var finalrotation = 0;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
        blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
        blacktransition.Fade(starttime,endtime,1,1);
        blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
        blacktransition.Move(OsbEasing.OutQuart,starttime,endtime+300,C,D,E,F);
        blacktransition.Rotate(starttime,endtime,initialrotationconversion,finalrotaitonconversion);
        }   

    public void barsweeprighttoleft(int starttime)
        {
        var A = 1250; //SizeX
        var B = 1200; //SizeY
        var C = 1920; //StartX
        var D = 240; //StartY
        var E = 320; //EndX
        var F = 240; //EndY
        var endtime = starttime + 1280;
        var initialrotation = -30;
        var finalrotation = 0;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
        blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
        blacktransition.Fade(starttime,endtime,1,1);
        blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
        blacktransition.Move(OsbEasing.InOutQuart,starttime-150,starttime+350,C,D,E,F);
        blacktransition.Rotate(starttime,endtime,initialrotationconversion,finalrotaitonconversion);
        blacktransition.Move(OsbEasing.InOutQuart,starttime+350,starttime+1050,E,F,C,D);
        }    

        public void kiaitransitionbarsgoright(int starttime)
        {
        var A = 200; //SizeX
        var B = 1200; //SizeY
        var C = 1920; //StartX
        var D = 240; //StartY
        var E = -280; //EndX
        var F = 240; //EndY
        var endtime = starttime + 1280;
        var initialrotation = -10;
        var finalrotation = 10;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var timer=starttime;
        var timer2=starttime+938;

        var fillscreenx = 715;
        var fillscreeny = 240;

        var intervals = 937;
        var intervals2 = 1237;

        //1 by 1

            for(int x=0;x<=1;x++) // How many lines
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer,timer+1280,initialrotationconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer,timer+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer,timer+480,C,D,E,F);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            timer+=380;
            }
            
            for(int x=0;x<=4;x++) // How many lines
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer2,timer2+200,finalrotaitonconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer2,timer2+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer2,timer2+450,E,F,fillscreenx,fillscreeny);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            blacktransition.Move(OsbEasing.OutQuart,timer2+intervals,timer2+intervals2,fillscreenx,fillscreeny,E,F);
            timer2+=118;
            fillscreenx-=203;
            intervals-=117;
            }
        }


        public void kiaitransitionbarleftrightbutgoleft(int starttime) // 1/1 Left Right, Drum left right togetehr like 2nd kiai
        {
        var A = 250; //SizeX
        var B = 1200; //SizeY
        var C = 1920; //StartX
        var D = 240; //StartY
        var E = -280; //EndX
        var F = 240; //EndY
        var endtime = starttime + 1280;
        var initialrotation = 10;
        var finalrotation = -10;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var timer=starttime-50;
        var timer2=starttime+938;

        var fillscreenx = 715;
        var fillscreeny = 240;

        var intervals = 937;
        var intervals2 = 1237;

        int[] Startsleftthenright = new int[]{ // The 3 possible x cord to move
           -280,1920
        };

        int[] Startsrightthenleft = new int[]{ // The 3 possible x cord to move
           1920,-280
        };

        int[] GoingLeft = new int[]{
            C,D,E,F
        };

        int[] GoingRight = new int[]{
            E,F,C,D
        };
        //1 by 1

            for(int x=0;x<=0;x++) // How many lines
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer,timer+1280,initialrotationconversion,initialrotationconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer,timer+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer,timer+480,GoingLeft[0],GoingLeft[1],GoingLeft[2],GoingLeft[3]);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            }

            timer+=469+50;
            for(int x=0;x<=0;x++) // How many lines
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer,timer+1280,finalrotaitonconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer,timer+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer,timer+1280,GoingRight[0],GoingRight[1],GoingRight[2],GoingRight[3]);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            }
            

            int[] DrumsUp = new int[]{  // The 3 Location
            -28,146
            };

            var value = 1050; //Decerement here
            timer2=starttime+850;
            intervals = 0;
            var minusoffset = 0;
            var counter=0;
            var Hah = 150;
            var ahsad = 150;

            for(int x=0;x<=1;x++) //Drums From Right
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer2,timer2+640,initialrotationconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer2,timer2+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer2+intervals,timer2+intervals+480+Hah,1920,240,DrumsUp[counter],240);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            blacktransition.Move(OsbEasing.OutQuart,timer2+value+minusoffset,timer2+value+480+minusoffset+ahsad,DrumsUp[counter],240,1920,240);

            timer2+=118;
            intervals+=100;
            minusoffset-=117;
            counter+=1;
            }

            int[] DrumsDown = new int[]{  // The 3 possible rotation
            670,495
            };

            var Gvalue = 819; //Decerement here
            var Gtimer2=starttime+1087;
            var Gintervals = 0;
            var Gminusoffset = 0;
            var Gcounter=0;

            for(int x=0;x<=1;x++) //Drums From Left
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(Gtimer2,Gtimer2+640,finalrotaitonconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(Gtimer2,Gtimer2+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,Gtimer2+Gintervals,Gtimer2+Gintervals+480+Hah,-280,240,DrumsDown[Gcounter],240);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            blacktransition.Move(OsbEasing.OutQuart,Gtimer2+Gvalue+Gminusoffset,Gtimer2+Gvalue+480+Gminusoffset+ahsad,DrumsDown[Gcounter],240,1000,240);

            Gtimer2+=0 ;
            Gintervals+=100;
            Gminusoffset-=0;
            Gcounter+=1;
            }

            var Ablacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            Ablacktransition.Rotate(timer2,timer2+640,initialrotationconversion,finalrotaitonconversion);
            Ablacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            Ablacktransition.Fade(Gtimer2,Gtimer2+1280,1,1);
            Ablacktransition.Move(OsbEasing.OutQuart,Gtimer2+Gintervals,Gtimer2+Gintervals+480-130,1920,240,320,240);
            Ablacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            Ablacktransition.Move(OsbEasing.OutQuart,Gtimer2+Gvalue+Gminusoffset,Gtimer2+Gvalue+480+Gminusoffset+ahsad,320,240,1000,240);

        }

        public void barsweeprighttoright(int starttime)
        {
        var A = 1250; //SizeX
        var B = 1200; //SizeY
        var C = 1920; //StartX
        var D = 240; //StartY
        var E = 320; //EndX
        var F = 240; //EndY
        var endtime = starttime + 1280;
        var initialrotation = -30;
        var finalrotation = 0;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
        blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
        blacktransition.Fade(starttime,endtime,1,1);
        blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
        blacktransition.Move(OsbEasing.InOutQuart,starttime-150,starttime+350,C,D,E,F);
        blacktransition.Rotate(starttime,endtime,initialrotationconversion,finalrotaitonconversion);
        blacktransition.Move(OsbEasing.InOutQuart,starttime+350,starttime+1050,E,F,C,D);
        }    

        public void barsweeplefttoleft(int starttime)
        {
        var A = 1250; //SizeX
        var B = 1200; //SizeY
        var C = -1250; //StartX
        var D = 240; //StartY
        var E = 320; //EndX
        var F = 240; //EndY
        var endtime = starttime + 1280;
        var initialrotation = -30;
        var finalrotation = 0;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
        blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
        blacktransition.Fade(starttime,endtime,1,1);
        blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
        blacktransition.Move(OsbEasing.InOutQuart,starttime-150,starttime+350,C,D,E,F);
        blacktransition.Rotate(starttime,endtime,initialrotationconversion,finalrotaitonconversion);
        blacktransition.Move(OsbEasing.InOutQuart,starttime+350,starttime+1050,E,F,C,D);
        } 

        public void kiaitransitionbarszigs(int starttime)
        {
            // Y = -240 TOP , 720 BOTOOMM
            // x = -35 LEFT , 551 RIGHT (wrong)
        var A = 175; //SizeX
        var B = 480; //SizeY
        var C = stupidvalueresettooslow; //StartX
        var E = -280; //EndX
        var F = 240; //EndY
        var endtime = starttime + 1280;
        var initialrotation = 0;
        var finalrotation = 0;
        var initialrotationconversion = (initialrotation*(Math.PI/180));
        var finalrotaitonconversion = (finalrotation*(Math.PI/180));
        layer = GetLayer("SlantedBarTransition");
        var timer=starttime;

        var timer4 = starttime; //Startimed but starts at the end

        var fillscreenx = 715;

        var intervalsnegative = 934;

        var RandomXposition = Random(-35,551);
        var Yposition = 720;
        var Ypositionend = -240;


        //1 by 1

            for(int x=0;x<=1;x++) // 1/1
            {
            
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer,timer+1280,initialrotationconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer,timer+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer,timer+480,RandomXposition,Yposition,RandomXposition,Ypositionend);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            timer+=469;
            RandomXposition-=400;
            Yposition-=960;
            Ypositionend+=960;
            }

            int[] DrumsUp = new int[]{  // The 3 Location
            670,-28,320
            };

            var value = 1050; //Decerement here
            var timer2=starttime+850;
            var intervals = 0;
            var minusoffset = 0;
            var counter=0;

            for(int x=0;x<=2;x++) //Drums Up
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(timer2,timer2+1280,initialrotationconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(timer2,timer2+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,timer2+intervals,timer2+intervals+480,DrumsUp[counter],Yposition,DrumsUp[counter],F);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            blacktransition.Move(OsbEasing.OutQuart,timer2+value+minusoffset,timer2+value+480+minusoffset,DrumsUp[counter],F,DrumsUp[counter],E);

            timer2+=118;
            intervals+=100;
            minusoffset-=117;
            counter+=1;
            }

            int[] DrumsDown = new int[]{  // The 3 possible rotation
            146,495
            };

            var Gvalue = 936; //Decerement here
            var Gtimer2=starttime+970;
            var Gintervals = 0;
            var Gminusoffset = 0;
            var Gcounter=0;

            for(int x=0;x<=1;x++) //Drums Up
            {
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.Rotate(Gtimer2,Gtimer2+1280,initialrotationconversion,finalrotaitonconversion);
            blacktransition.ScaleVec(starttime,endtime,A,B,A,B);
            blacktransition.Fade(Gtimer2,Gtimer2+1280,1,1);
            blacktransition.Move(OsbEasing.OutQuart,Gtimer2+Gintervals,Gtimer2+Gintervals+480,DrumsDown[Gcounter],Ypositionend,DrumsDown[Gcounter],F);
            blacktransition.Color(starttime,endtime,"#FF92A5","#FF92A5");
            blacktransition.Move(OsbEasing.OutQuart,Gtimer2+Gvalue+Gminusoffset,Gtimer2+Gvalue+1210 +Gminusoffset,DrumsDown[Gcounter],F,DrumsDown[Gcounter],Ypositionend);

            Gtimer2+=118;
            Gintervals+=100;
            Gminusoffset-=117;
            Gcounter+=1;
            }



        }

    public void blackending(int starttime, int endtime)
    {
    layer = GetLayer("ending");
    var blacktransition = layer.CreateSprite("sb/p.png");
    blacktransition.Scale(starttime,5000);
    blacktransition.Move(starttime,240,360);
    blacktransition.Fade(starttime,endtime,0,1);
    blacktransition.Color(starttime,endtime,"#000000","#000000");
    }    

    public void Movement1()
    {
        var rate = 30;
        int startTime = 15350;
        int endTime = 307851;

        layer = GetLayer("ShakeBg");
        var sprite = layer.CreateSprite("sb/hatsunemiku/1.png");
        sprite.Scale(startTime, 480/900.0);
        sprite.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/750.0, 480/900.0);
        sprite.Fade(startTime,0.8);
        sprite.Fade(75350,0);

        sprite.Fade(255350,0.9);
        sprite.Scale(OsbEasing.OutQuart,255350,255350+600,480/750.0, 480/900.0);
        sprite.Scale(OsbEasing.OutQuart,105350,105350+600,480/750.0, 480/900.0);
        sprite.Fade(105350,0.9);
        sprite.Fade(120350,0);
        //sprite.Scale(OsbEasing.OutQuart,74882,75350,480/900.0,480/910.0);

        layer = GetLayer("blurBg");
        var blur = layer.CreateSprite("sb/hatsunemiku/1blur.png");
        blur.Scale(startTime, 480/750.0);
        blur.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/750.0, 480/900.0);
        //blur.Scale(OsbEasing.OutQuart,74882,75350,480/900.0,480/910.0);

        blur.Fade(startTime,0.8);
        blur.Fade(15350,0.8);
        blur.Fade(OsbEasing.OutQuart,30350,31288,0.8,0);
        blur.Fade(OsbEasing.OutQuart,45351,46288,0,0.8);
        blur.Fade(OsbEasing.OutQuart,60351,61288,0.8,0.4);
        blur.Fade(75350,0);
        blur.Fade(75350,0);



        int[] xCord = new int[]{ // The 3 possible x cord to move
           260,280,301
        };

        int[] yCord = new int[]{// The 3 possible y cord to move
            220,250,260
        };

        double[] rotation = new double[]{  // The 3 possible rotation
            0.02, 0.04, 0.06
        };

        var previousCord = new Vector2(280,250);

        double previousRotation = 0;

        var loopTime = (endTime-startTime)/rate;

        for(int i = 0; i < rate; i++){

            var xCordInd = Random(3); // Generates which x cord to move

            var yCordInd = Random(3);// Generates which y cord to move

            var rotInd = Random(3);// Generates which rotation to use

            var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

            sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
            blur.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

            previousCord = tempCord;

            var tempRot = rotation[rotInd];

            sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);
            blur.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

            previousRotation = tempRot;
        }
    }     

    public void Movement2()
    {
        var rate = 10;
        int startTime = 75350;
        int endTime = 105350;

        layer = GetLayer("ShakeBg");
        var sprite = layer.CreateSprite("sb/hatsunemiku/2.png");
        sprite.Scale(startTime, 480/650.0);
        sprite.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);
        sprite.Fade(startTime,0.9);

        //blur.Fade(OsbEasing.OutQuart,105350,105819,0,0.5);



        int[] xCord = new int[]{ // The 3 possible x cord to move
           260,280,300
        };

        int[] yCord = new int[]{// The 3 possible y cord to move
            220,250,260
        };

        double[] rotation = new double[]{  // The 3 possible rotation
            0.02, 0.04, 0.06
        };

        var previousCord = new Vector2(280,250);

        double previousRotation = 0;

        var loopTime = (endTime-startTime)/rate;

        for(int i = 0; i < rate; i++){

            var xCordInd = Random(3); // Generates which x cord to move

            var yCordInd = Random(3);// Generates which y cord to move

            var rotInd = Random(3);// Generates which rotation to use

            var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

            sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

            previousCord = tempCord;

            var tempRot = rotation[rotInd];

            sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

            previousRotation = tempRot;
        }
    }    

    public void Movement3()
    {
        var rate = 10;
        int startTime = 120350;
        int endTime = 150350;

        layer = GetLayer("ShakeBg");
        var sprite = layer.CreateSprite("sb/hatsunemiku/3.png");
        sprite.Scale(startTime, 480/650.0);
        sprite.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);
        sprite.Fade(startTime,0.8);

        layer = GetLayer("blurBg");
        var blur = layer.CreateSprite("sb/hatsunemiku/3blur.png");
        blur.Scale(startTime, 480/650.0);
        blur.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);

        blur.Fade(startTime,0.8);
        blur.Fade(OsbEasing.OutQuart,135350,136288,0.8,0.4);


        int[] xCord = new int[]{ // The 3 possible x cord to move
           260,280,300
        };

        int[] yCord = new int[]{// The 3 possible y cord to move
            220,250,260
        };

        double[] rotation = new double[]{  // The 3 possible rotation
            0.02, 0.04, 0.06
        };

        var previousCord = new Vector2(280,250);

        double previousRotation = 0;

        var loopTime = (endTime-startTime)/rate;

        for(int i = 0; i < rate; i++){

            var xCordInd = Random(3); // Generates which x cord to move

            var yCordInd = Random(3);// Generates which y cord to move

            var rotInd = Random(3);// Generates which rotation to use

            var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

            sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
            blur.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

            previousCord = tempCord;

            var tempRot = rotation[rotInd];

            sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);
            blur.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

            previousRotation = tempRot;
        }
    }

    public void Movement4()
    {
        var rate = 10;
        int startTime = 150350;
        int endTime = 180350;

        layer = GetLayer("ShakeBg");
        var sprite = layer.CreateSprite("sb/hatsunemiku/4.png");
        sprite.Scale(startTime, 480/650.0);
        sprite.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);
        sprite.Fade(startTime,0.9);

        // layer = GetLayer("blurBg");
        // var blur = layer.CreateSprite("sb/hatsunemiku/4blur.png");
        // blur.Scale(startTime, 480/750.0);
        // blur.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/750.0, 480/900.0);
        // blur.Fade(startTime,0);


        int[] xCord = new int[]{ // The 3 possible x cord to move
           260,280,300
        };

        int[] yCord = new int[]{// The 3 possible y cord to move
            220,250,260
        };

        double[] rotation = new double[]{  // The 3 possible rotation
            0.02, 0.04, 0.06
        };

        var previousCord = new Vector2(280,250);

        double previousRotation = 0;

        var loopTime = (endTime-startTime)/rate;

        for(int i = 0; i < rate; i++){

            var xCordInd = Random(3); // Generates which x cord to move

            var yCordInd = Random(3);// Generates which y cord to move

            var rotInd = Random(3);// Generates which rotation to use

            var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

            sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
            //blur.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

            previousCord = tempCord;

            var tempRot = rotation[rotInd];

            sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);
            //blur.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

            previousRotation = tempRot;
        }
    }   

    public void Movement5()
    {
        var rate = 10;
        int startTime = 180350;
        int endTime = 225350;

        layer = GetLayer("ShakeBg");
        var sprite = layer.CreateSprite("sb/hatsunemiku/5.png");
        sprite.Scale(startTime, 480/650.0);
        sprite.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);
        sprite.Fade(startTime,0.8);

        layer = GetLayer("blurBg");
        var blur = layer.CreateSprite("sb/hatsunemiku/5blur.png");
        blur.Scale(startTime, 480/650.0);
        blur.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);
        blur.Fade(OsbEasing.OutQuart,180350,181288,0,0.8);
        blur.Fade(OsbEasing.OutQuart,195350,196288,0.8,0.4);
        blur.Fade(OsbEasing.OutQuart,210350,211288,0.4,0);


        blur.Fade(startTime,0);


        int[] xCord = new int[]{ // The 3 possible x cord to move
           260,280,300
        };

        int[] yCord = new int[]{// The 3 possible y cord to move
            220,250,260
        };

        double[] rotation = new double[]{  // The 3 possible rotation
            0.02, 0.04, 0.06
        };

        var previousCord = new Vector2(280,250);

        double previousRotation = 0;

        var loopTime = (endTime-startTime)/rate;

        for(int i = 0; i < rate; i++){

            var xCordInd = Random(3); // Generates which x cord to move

            var yCordInd = Random(3);// Generates which y cord to move

            var rotInd = Random(3);// Generates which rotation to use

            var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

            sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
            blur.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

            previousCord = tempCord;

            var tempRot = rotation[rotInd];

            sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);
            blur.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

            previousRotation = tempRot;
        }
    }   

    public void Movement6()
    {
        var rate = 10;
        int startTime = 225350;
        int endTime = 255350;

        layer = GetLayer("ShakeBg");
        var sprite = layer.CreateSprite("bg.png");
        sprite.Scale(startTime, 480/650.0);
        sprite.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/650.0, 480/850.0);
        sprite.Fade(startTime,0.8);

        // layer = GetLayer("blurBg");
        // var blur = layer.CreateSprite("sb/hatsunemiku/6blur.png");
        // blur.Scale(startTime, 480/750.0);
        // blur.Scale(OsbEasing.OutQuart,startTime,startTime+600,480/750.0, 480/900.0);

        // blur.Fade(startTime,0);


        int[] xCord = new int[]{ // The 3 possible x cord to move
           260,280,300
        };

        int[] yCord = new int[]{// The 3 possible y cord to move
            220,250,260
        };

        double[] rotation = new double[]{  // The 3 possible rotation
            0.02, 0.04, 0.06
        };

        var previousCord = new Vector2(280,250);

        double previousRotation = 0;

        var loopTime = (endTime-startTime)/rate;

        for(int i = 0; i < rate; i++){

            var xCordInd = Random(3); // Generates which x cord to move

            var yCordInd = Random(3);// Generates which y cord to move

            var rotInd = Random(3);// Generates which rotation to use

            var tempCord = new Vector2(xCord[xCordInd],yCord[yCordInd]);

            sprite.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);
            //blur.Move(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousCord,tempCord);

            previousCord = tempCord;

            var tempRot = rotation[rotInd];

            sprite.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);
            // blur.Rotate(OsbEasing.InOutSine,startTime+(loopTime*i),startTime+(loopTime*(i+1)),previousRotation,tempRot);

            previousRotation = tempRot;
        }
    }   
     

        public void flash(int startime)
        {
            layer = GetLayer("Flash");
            var flashe = layer.CreateSprite("sb/p.png");
            flashe.Scale(startime,1000);
            flashe.Fade(startime,startime+200,0.4,0);
        }

        public void fadein(int startime)
        {
            layer = GetLayer("black");
            var blacy = layer.CreateSprite("sb/p.png");
            blacy.Color(startime,"000000");            
            blacy.Scale(startime,1000);
            blacy.Fade(startime,startime+200,1,0);
        }

        public void blackopacity(int startime, int endtime, double startopacity, double endopacity)
        {
            layer = GetLayer("black");
            var blacy = layer.CreateSprite("sb/p.png");
            blacy.Color(startime,"000000");            
            blacy.Scale(startime,1000);
            blacy.Fade(startime,startime+200,startopacity,endopacity);
            blacy.Fade(startime+200,endtime,endopacity,endopacity);
        }

        public void ring(int startime)
        {
            layer = GetLayer("ring");
            var ringy = layer.CreateSprite("sb/ring.png",OsbOrigin.Centre);
            ringy.Scale(OsbEasing.InOutQuart,startime,startime+1000,0,50);
            ringy.Fade(startime,startime+200,1,1);
            ringy.Move(startime,288,255);
        }

        public void vinette(int startime,int endtime)
        {
            layer = GetLayer("viggnete");
            var viggete = layer.CreateSprite("sb/v.png",OsbOrigin.Centre);
            viggete.Scale(startime-200,480.0/1080); 
            viggete.Fade(startime-200,startime,0,1);
            viggete.Fade(startime,endtime,1,1);
        }

        public void intro()
        {

            int constant = 500;
            var akjdkja = 30; 

            int[] IntroPosition = new int[]{  // The 3 possible rotation
            38-constant,538+constant
            };


            int[] TwoEdges = new int[]{  // The 3 possible rotation
            38+akjdkja,538+akjdkja
            };

            int[] Output = new int[]{  // The 3 possible rotation
            38-constant,538+constant
            };

            var counterA=0;
            var counterB=0;
            var counterC=0;

            // layer = GetLayer("Black");
            // var BlackOnly = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            // BlackOnly.Scale(0,15350,1000,1000);
            // BlackOnly.Color(0,15350,"#000000","#000000");

            for(int k=0;k<=1;k++)
            { 
            layer = GetLayer("DoubleEdges");
            var viggete = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);  
            viggete.ScaleVec(14882,17225,500,700,500,700);

            viggete.Move(OsbEasing.OutExpo,14882,15233,IntroPosition[counterA],240,TwoEdges[counterB],240);
            //viggete.Move(OsbEasing.OutExpo,15350,15819,TwoEdges[counterB],240,Output[counterC],240);
            //After
            //viggete.Move(0,15350,TwoEdges[counterB],240,TwoEdges[counterB],240);
            viggete.Move(OsbEasing.OutExpo,15350,15819,TwoEdges[counterB],240,Output[counterC],240);


            //viggete.Fade(0,351,0,0);
            viggete.Fade(14882,1);
            viggete.Fade(15819,0);
            viggete.Color(14882,15350,"#FF92A5","#FF92A5");
            counterA++;
            counterB++;
            counterC++;
            }

        }

        // public void randombarangleinvisible(int start,int end,int BeatDivisor, int FadeDuration) // This functions make a void circle, but must have transparent bg, good function
        // {
        //     var asoda = 260;

        //     int[] UpDownEdgesStart = new int[]{ 
        //     -170,170
        //     };
        //     var edgescounterupStart=0;

        //     int[] UpDownEdgesEnd = new int[]{ 
        //     -290,290
        //     };
        //     var edgescounterupEnd=0;


        //     int[] LeftRightEdgesStart = new int[]{  // The 3 possible rotation
        //     -asoda,asoda
        //     };
        //     var edgescounterleftStart=0;

        //     int[] LeftRightEdgesEnd = new int[]{  // The 3 possible rotation
        //     -385,385
        //     };
        //     var edgescounterleftEnd=0;
        

        //     var hitobjectLayer = GetLayer("CircleLa");
        //     foreach (var hitobject in Beatmap.HitObjects)
        //     {
        //         if ((start != 0 || end != 0) &&
        //             (hitobject.StartTime < start - 5 || end - 5 <= hitobject.StartTime))
        //             continue;
        //             var circle = hitobjectLayer.CreateSprite("sb/ringblack.png", OsbOrigin.Centre, hitobject.Position);
        //             circle.Fade(OsbEasing.In, hitobject.StartTime,  hitobject.StartTime + FadeDuration+199, 1 , 1);
        //             circle.Fade(hitobject.StartTime + FadeDuration+200,0);
        //             circle.ScaleVec(OsbEasing.OutQuad, hitobject.StartTime,  hitobject.StartTime + FadeDuration-100, 0.1,0.1,1.8,1.8);
        //             circle.ScaleVec(OsbEasing.OutQuad, hitobject.StartTime + FadeDuration-100,  hitobject.StartTime + FadeDuration+1000, 1.8,1.8,2,2);
        //             circle.Color(hitobject.StartTime,"#FF92A5");

        //             // var backgroundBlue = hitobjectLayer.CreateSprite("sb/p.png", OsbOrigin.Centre, hitobject.Position);
        //             // backgroundBlue.Scale(hitobject.StartTime,1000);
        //             // backgroundBlue.Fade(hitobject.StartTime,hitobject.StartTime + FadeDuration,0,1);
        //             // backgroundBlue.Color(hitobject.StartTime,"#FF92A5");
        //             // backgroundBlue.Fade(hitobject.StartTime + FadeDuration,1);

        //             for(int o=0;o<=1;o++) //Up Down
        //             {
        //                 var edges = hitobjectLayer.CreateSprite("sb/p.png", OsbOrigin.Centre);
        //                 edges.ScaleVec(hitobject.StartTime,1200,320);
        //                 edges.Fade(OsbEasing.Out, hitobject.StartTime,  hitobject.StartTime + FadeDuration-100, 1 , 1);
        //                 edges.Move(hitobject.StartTime, hitobject.StartTime + FadeDuration-200, hitobject.Position.X , hitobject.Position.Y+UpDownEdgesStart[edgescounterupStart],
        //                                                                                     hitobject.Position.X , hitobject.Position.Y+UpDownEdgesEnd[edgescounterupEnd]);
        //                 edges.Color(hitobject.StartTime,"#FF92A5");
        //                 edgescounterupStart+=1;
        //                 edgescounterupEnd+=1;

        //             }
        //             edgescounterupStart=0;
        //             edgescounterupEnd=0;

        //             for(int l=0;l<=1;l++)
        //             {
        //                 var edges = hitobjectLayer.CreateSprite("sb/p.png", OsbOrigin.Centre);
        //                 edges.ScaleVec(hitobject.StartTime,500,1200);
        //                 edges.Fade(OsbEasing.Out, hitobject.StartTime,  hitobject.StartTime + FadeDuration-100, 1 , 1);
        //                 edges.Move(hitobject.StartTime, hitobject.StartTime + FadeDuration-200, hitobject.Position.X+LeftRightEdgesStart[edgescounterleftStart] , hitobject.Position.Y,
        //                                                                                     hitobject.Position.X+LeftRightEdgesEnd[edgescounterleftEnd] , hitobject.Position.Y);
        //                 edges.Color(hitobject.StartTime,"#FF92A5");
        //                 edgescounterleftStart+=1;
        //                 edgescounterleftEnd+=1;
        //             }
        //             edgescounterleftStart=0;
        //             edgescounterleftEnd=0;
                
        //         //  if (hitobject is OsuSlider)
        //         // {
        //         //     var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
        //         //     var startTime = hitobject.StartTime;
        //         //     while (true)
        //         //     {
        //         //         var endTime = startTime + timestep;

        //         //         var complete = hitobject.EndTime - endTime < 5;
        //         //         if (complete) endTime = hitobject.EndTime;

        //         //         var startPosition = circle.PositionAt(startTime);
        //         //         circle.Move(startTime, endTime, startPosition, hitobject.PositionAtTime(endTime));

        //         //         if (complete) break;
        //         //         startTime += timestep;
        //         //     }
        //         // }
        //     }


        // }

        public void finalkiaibridge(int starttime)
        {
            var sizex = 910;
            var sizey = 265;
            var endtime = starttime + 1280;
            layer = GetLayer("BridgePart");
            var blacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            blacktransition.ScaleVec(starttime,endtime,sizex,sizey,sizex,sizey);
            blacktransition.Color(starttime,"000000");
            blacktransition.Move(OsbEasing.OutQuart,starttime,starttime+400,-595,123,320,123);
            //blacktransition.Fade

            layer = GetLayer("BridgePart");
            var Ablacktransition = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            Ablacktransition.ScaleVec(starttime,endtime,sizex,sizey,sizex,sizey);
            Ablacktransition.Color(starttime,"000000");
            Ablacktransition.Move(OsbEasing.OutQuart,starttime+469,starttime+869 ,1235,388,320,388);

            // blacktransition.Color(starttime+469,starttime+938,"000000","000000");
            // Ablacktransition.Color(starttime+469,starttime+938,"000000","000000");

            blacktransition.Fade(starttime, starttime+1875,1,1);
            Ablacktransition.Fade(starttime, starttime+1875,1,1);


        }

        public void transitiongray(int starttime,int endtime)
        {
            layer = GetLayer("GrayOverlay");
            var Gray = layer.CreateSprite("sb/p.png",OsbOrigin.Centre); 
            Gray.Scale(starttime, 1000);
            Gray.Fade(OsbEasing.InQuad,starttime,starttime+3750,0,1);
            Gray.Fade(endtime,0);
            Gray.Color(starttime,"#000000");

        }

        public void dotinvert(int starttime)
        {
            layer = GetLayer("DotInvert");
            var Gray = layer.CreateSprite("sb/DotInvert.png",OsbOrigin.Centre); 
            Gray.Move(starttime,320,260);
            Gray.Scale(OsbEasing.OutExpo,starttime-100,starttime+468, 150,0.01);
            Gray.Scale(OsbEasing.OutExpo,starttime+468,starttime+900,0.01,20);
            Gray.Fade(starttime,1);
            Gray.Fade(starttime+1280,0);
            Gray.Color(starttime,"#FF92A5");

            var GrayA = layer.CreateSprite("sb/p.png",OsbOrigin.Centre);
            GrayA.Scale(starttime+234, 1000);
            GrayA.Fade(OsbEasing.OutExpo,starttime+234,starttime+468,0,1);
            GrayA.Fade(starttime+468,starttime+500,1,0);
            GrayA.Color(starttime,"#FF92A5");

        }


        public void BackgroundBgBlack()
        {
            layer = GetLayer("");
            var bg = layer.CreateSprite("bg.png",OsbOrigin.Centre); 
            bg.Fade(0, 0f);
            Log("Executed");
        }


            // var Gray = layer.CreateSprite("sb/p.png"); 
            // Gray.Scale(0,1000);
            // Gray.Scale(starttime, 1000);
            // Gray.Fade(starttime,1);
            // Gray.Fade(endtime,0);
            // Gray.Color(starttime,"#000000");



        public override void Generate()
        {

            
            BackgroundBgBlack();
            //barsweeplefttoright(351);
            intro();
            flash(15350);
            dotinvert(119882);
            //randombarangleinvisible(14882,15350,16,300);

            //transitiongray(67850,75350);
            //transitiongray(22850,30350);
        
            barsweeplefttoleft(149882);
            barsweeprighttoright(74882);
            kiaitransitionbarsgoright(103475);
            kiaitransitionbarleftrightbutgoleft(178475);
            finalkiaibridge(223475);
            kiaitransitionbarszigs(253475);

            ring(15350);
            flash(30350);
            //flash(45351);
            ring(60351);
            flash(75350);
            flash(105350);
            flash(120350);
            flash(180350);
            flash(225350);
            flash(255350);
            ring(135350);
            flash(150350);
            //blackending(307851 ,308319);

            Movement1();
            Movement2();
            Movement3();
            Movement4();
            Movement5();
            Movement6();

        }
    }
}
