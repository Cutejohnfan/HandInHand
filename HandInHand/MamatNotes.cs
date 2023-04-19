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
    public class MamatNotes : StoryboardObjectGenerator
    {

        public void Notes(int StartTime, int EndTime, int FadeTime, int ParticlesAmount, 
                          int ParticlesRadius,string HightlightSpritePath,
                          double HighlightSpriteScale, double ParticlesSpriteScale,
                          double StartRotation, double EndRotation, bool RandomRotation, bool ComboColor)
        {
            string[] notes = new string[]{

            "sb/notes/bassclef.png",
            "sb/notes/beamnotes.png",
            "sb/notes/flat.png",
            "sb/notes/minim.png",
            "sb/notes/quaver.png",
            "sb/notes/sharpflat.png",
            "sb/notes/trebleclef.png"
            
             };

            string[] typesofcolors = new string[]
            {

                        "#FF647F","#A020F0","#FF8000" // Pink, Purple, Orange

            };

            var hitobjectLayer = GetLayer("ObjectNotes");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) &&
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;


                // If you want glow...
                var colorrandomselect = Random(3);
                var objectcolor = typesofcolors[colorrandomselect];  

                var hSprite = hitobjectLayer.CreateSprite(HightlightSpritePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Scale(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + FadeTime, HighlightSpriteScale *1.2, HighlightSpriteScale * 2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 0.2, 0);
                hSprite.Additive(hitobject.StartTime, hitobject.StartTime + FadeTime);
                if (ComboColor) hSprite.Color(hitobject.StartTime, objectcolor);

                for (int i = 0; i < ParticlesAmount; i++)
                {
                    var randomselect = Random(7);
                    var SpritePath = notes[randomselect];   
                    colorrandomselect = Random(3);
                    objectcolor = typesofcolors[colorrandomselect];  
                    var RandomRotate = Random(StartRotation,EndRotation);

                    var position_X = hitobject.Position.X + Random(-ParticlesRadius, ParticlesRadius);
                    var position_Y = hitobject.Position.Y + Random(-ParticlesRadius, ParticlesRadius);
                

                    var pSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                    pSprite.Move(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + 500, hitobject.Position,position_X,position_Y);
                    pSprite.Fade(hitobject.StartTime + 850, hitobject.StartTime + 1000, 1, 0);
                    pSprite.Scale(OsbEasing.InExpo, hitobject.StartTime + 600, hitobject.StartTime + 1000, ParticlesSpriteScale * Random(0.3, 0.4), ParticlesSpriteScale * 0.1);
                    pSprite.Color(hitobject.StartTime, objectcolor);
                    pSprite.Rotate(hitobject.StartTime, hitobject.StartTime,MathHelper.DegreesToRadians(RandomRotate), MathHelper.DegreesToRadians(RandomRotate));

                    // var glowSprite = hitobjectLayer.CreateSprite(HightlightSpritePath, OsbOrigin.Centre, hitobject.Position);
                    // glowSprite.Move(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + 500, hitobject.Position,position_X,position_Y);
                    // glowSprite.Fade(hitobject.StartTime + 850, hitobject.StartTime + 1000, 0.1, 0);
                    // glowSprite.Color(hitobject.StartTime, objectcolor);
                    // glowSprite.Scale(OsbEasing.InExpo, hitobject.StartTime + 600, hitobject.StartTime + 1000, 1 , ParticlesSpriteScale * 0.1);

                    if (ComboColor) pSprite.Color(hitobject.StartTime, objectcolor);

                    // if (StartRotation != EndRotation)
                    //     if (RandomRotation)
                    //         pSprite.Rotate(hitobject.StartTime, hitobject.StartTime + FadeTime, MathHelper.DegreesToRadians(Random(StartRotation, StartRotation)), MathHelper.DegreesToRadians(Random(StartRotation, EndRotation)));
                    //     else pSprite.Rotate(hitobject.StartTime, hitobject.StartTime + FadeTime, MathHelper.DegreesToRadians(StartRotation), MathHelper.DegreesToRadians(EndRotation));
                }
            }

        }

        public void transitioncircles(int starttime, int endtime, int FadeTime, string HightlightSpritePath, 
                                      double HighlightSpriteScale, int BeatDivisor)
        {
            string[] typesofcolors = new string[]
            {

                        "#FF647F","#A020F0","#FF8000" // Pink, Purple, Orange

            };

            double FadeIncreases = 0.05;
            

            var layer = GetLayer("BridgeNotes");
            foreach (var hitobject in Beatmap.HitObjects)
            {

                var amount = Random(5,10);
                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime - 5 <= hitobject.StartTime))
                    continue;


                var colorrandomselect = Random(3);
                var objectcolor = typesofcolors[colorrandomselect];  

                var hSprite = layer.CreateSprite(HightlightSpritePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                hSprite.Scale(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + FadeTime, HighlightSpriteScale *1.2, HighlightSpriteScale * 2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, FadeIncreases, 0);
                hSprite.Additive(hitobject.StartTime, hitobject.StartTime + FadeTime);
                if (true) hSprite.Color(hitobject.StartTime, objectcolor);

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + timestep;

                        var complete = hitobject.EndTime - endTime < 5;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = hSprite.PositionAt(startTime);
                        Log("Old Start position value:" + startPosition);
                        Log("Hit object position time" + hitobject.PositionAtTime(endTime));

                        var vectorstartposition = (Vector2)startPosition;

                        Log("Middle Start position value:" + vectorstartposition);

                        Vector2 vectorsubtraction;

                        vectorsubtraction.X = 35;
                        vectorsubtraction.Y = 0;

                        var Avectorcalculation = vectorstartposition-vectorsubtraction;

                        Log("Finale Start position value:" + Avectorcalculation); //Settled


                        var Bvectorcalculation = hitobject.PositionAtTime(endTime)-vectorsubtraction;






                        //hSprite.Move(startTime, endTime, Avectorcalculation, Bvectorcalculation);

                        hSprite.Move(startTime, endTime, startPosition, hitobject.PositionAtTime(endTime)); //Default

                        if (complete) break;
                        startTime += timestep;
                    }
                }

                if(FadeIncreases>=0.99)
                {
                    FadeIncreases=1;

                }
                else
                {
                    FadeIncreases+=0.05;
                } 
                Log(FadeIncreases);


            }
        }

        public void Ring(int starttime)
        {
            var endtime = starttime + 10 ;
            var FadeTime=600;
            var HighlightSpriteScale=0.3;

            var layer = GetLayer("Ring");
            foreach (var hitobject in Beatmap.HitObjects)
            {
 
                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime - 5 <= hitobject.StartTime))
                    continue;

                    
                    var ring = layer.CreateSprite("sb/ring.png", OsbOrigin.Centre, hitobject.Position);
                    ring.Scale(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + FadeTime, HighlightSpriteScale *0.1, HighlightSpriteScale * 1.4);
                    ring.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                    ring.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
            
            }
        }

        public void MiddleRing(int starttime)
        {
            var endtime = starttime + 10 ;
            var FadeTime=600;
            var HighlightSpriteScale=0.4;

            var layer = GetLayer("BiggerRing");
            foreach (var hitobject in Beatmap.HitObjects)
            {
 
                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime - 5 <= hitobject.StartTime))
                    continue;


                    var ring = layer.CreateSprite("sb/ring.png", OsbOrigin.Centre, hitobject.Position);
                    ring.Scale(OsbEasing.OutCubic, hitobject.StartTime, hitobject.StartTime + FadeTime, HighlightSpriteScale*0.1, HighlightSpriteScale * 1.6);
                    ring.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                    ring.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
            
            }
        }

        public void BiggerRing(int starttime)
        {
            var endtime = starttime + 10 ;
            var FadeTime=600;
            var HighlightSpriteScale=0.4;

            var layer = GetLayer("BiggerRing");
            foreach (var hitobject in Beatmap.HitObjects)
            {
 
                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime - 5 <= hitobject.StartTime))
                    continue;


                    var ring = layer.CreateSprite("sb/ring.png", OsbOrigin.Centre, hitobject.Position);
                    ring.Scale(OsbEasing.OutCubic, hitobject.StartTime, hitobject.StartTime + FadeTime, HighlightSpriteScale*0.1, HighlightSpriteScale * 1.8);
                    ring.Move(hitobject.StartTime, hitobject.Position.X,hitobject.Position.Y+10);
                    ring.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
            
            }
        }

        public override void Generate()
        {
            Notes(180350,223475,500,1,100,"sb/dot.png",0.5,0.5,0,360,true,true);
            transitioncircles(22850,30350,500,"sb/dot.png",0.9,8); 
            Ring(29882);
            MiddleRing(30350);
            transitioncircles(67850,75350,500,"sb/dot.png",0.9,8);
            
            Ring(14882);
            BiggerRing(15350);

            Ring(45351);


            MiddleRing(74882);
            BiggerRing(75350);

            MiddleRing(44882);

            Ring(60351);

            

            MiddleRing(104882);
            BiggerRing(105350);

            MiddleRing(89882);
            BiggerRing(90350);

            MiddleRing(164882);
            BiggerRing(165350);

            MiddleRing(239882);
            BiggerRing(240350);

            Ring(120350);
            Ring(135350);

            transitioncircles(142850,150350,500,"sb/dot.png",0.9,8);

            transitioncircles(217850,224413,500,"sb/dot.png",0.9,8);

            transitioncircles(285351,300351,500,"sb/dot.png",0.9,8);


            MiddleRing(149882);
            BiggerRing(150350);

            MiddleRing(179882);
            BiggerRing(180350);

            Ring(210350);

            MiddleRing(224882);
            BiggerRing(225350);

            MiddleRing(224882);
            BiggerRing(225350);
            
            
            MiddleRing(254882);
            BiggerRing(255350);

            MiddleRing(299882);
            BiggerRing(300351);

            Ring(270351);
            MiddleRing(285351);
        }
    }
}