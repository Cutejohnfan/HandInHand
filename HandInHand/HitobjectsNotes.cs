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
    public class HitobjectsNotes : StoryboardObjectGenerator
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

                    "#B9E9C9","#FFFF8A"

                    };

        public void musicnotes(int starttime, int endtime)
        {
            var layer = GetLayer("ObjectNotes");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                var amount = Random(5,10);
                if ((starttime != 0 || endtime != 0) && 
                    (hitobject.StartTime < starttime - 5 || endtime - 5 <= hitobject.StartTime))
                    continue;

                for(int t=0; t<amount; t++)
                {
                
                var randomselect = Random(7);
                var SpritePath = notes[randomselect];   
                var colorrandomselect = Random(2);
                var objectcolor = typesofcolors[colorrandomselect];             
                var FadeDuration = 100;
                var SpriteScale = 0.1;

                var hitobjectrandomduration = Random(300,500);

                double dist = Random(0,100);
                double angle = Random(0, Math.PI * 2);
                Vector2 randomPoint = new Vector2(
                hitobject.Position.X + (float) (Math.Sqrt(dist) + Math.Cos(angle)),
                hitobject.Position.Y + (float) (Math.Sqrt(dist) + Math.Sin(angle))
                );



                var hSprite = layer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime + FadeDuration, SpriteScale, SpriteScale * 0.2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.EndTime + FadeDuration, 1, 0);
                hSprite.Color(hitobject.StartTime, objectcolor);
                hSprite.Move(OsbEasing.OutExpo,hitobject.StartTime, hitobject.StartTime + hitobjectrandomduration,hitobject.Position,hitobject.Position);
                }


            }
        }

        public void transitioncircles(int starttime, int endtime)
        {
            var layer = GetLayer("BridgeNotes");

        }
        public override void Generate()
        {
		    
            musicnotes(180350,223475);
        }
    }
}
