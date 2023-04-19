using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Subtitles;
using System;

namespace StorybrewScripts
{
    class Lyrica2 : StoryboardObjectGenerator
    {
        StoryboardLayer layer;

        FontGenerator font;
        public override void Generate()
        {
            layer = GetLayer("Subs2");
            var font = LoadFont("a.ttf", new FontDescription()
            {
                FontPath = "a.ttf",
                FontSize = 100,
                Color = Color4.White,
                TrimTransparency = true
            });

            GenerateText(1054, 2694, new Vector2(320, 240), 0.5f, "目を閉じて", font);
        }
        void GenerateText(int startTime, int endTime, Vector2 Position, float scale, string text, FontGenerator font)
        {
            var lineWidth = 0f;
            var lineHeight = 0f;
            var letterY = Position.Y;

            foreach (var letter in text)
            {
                var texture = font.GetTexture(letter.ToString());
                lineWidth += texture.BaseWidth * scale;
                lineHeight = Math.Max(lineHeight, texture.BaseHeight * scale);
            }

            var letterX = Position.X - lineWidth * 0.5f;
            foreach (var letter in text)
            {
                var texture = font.GetTexture(letter.ToString());
                var letterPos = new Vector2(letterX, letterY) + texture.OffsetFor(OsbOrigin.Centre) * scale; // The main issue is here, how to make it aligned properly?

                if (!texture.IsEmpty)
                {
                    var sprite = GetLayer("").CreateSprite(texture.Path);
                    sprite.Move(OsbEasing.OutExpo, startTime-100, startTime, new Vector2(320, 280), letterPos); //Pos before hand
                    sprite.Fade(endTime - 100, endTime, 1, 0);
                    sprite.Scale(startTime, scale);
                }
                letterX += texture.BaseWidth * scale;
            }
            letterY += lineHeight;
        }
    }
}