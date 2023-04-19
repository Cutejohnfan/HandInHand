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
    
    public class Lyrica : StoryboardObjectGenerator
    {
        

        StoryboardLayer layer;
        

        FontGenerator japaneseFont;

        Random rnd;

        [Configurable]
        public int ahsdaojaj = 0;

        [Configurable]
        public int GlowRadius = 0;

        [Configurable]
        public Color4 GlowColor = new Color4(255, 255, 255, 100);

        [Configurable]
        public bool AdditiveGlow = true;

        [Configurable]
        public int OutlineThickness = 3;

        [Configurable]
        public Color4 OutlineColor = new Color4(50, 50, 50, 200);

        [Configurable]
        public int ShadowThickness = 0;

        [Configurable]
        public Color4 ShadowColor = new Color4(0, 0, 0, 100);


        public override void Generate()
        {

		    layer = GetLayer("Subs");
            rnd = new Random(420);
            japaneseFont = LoadFont("sb/lyrics", new FontDescription() // Can just go storybrew to copy paste this
            {
                FontPath = "a.ttf",
                FontSize = 150, // SizeW
                Color = Color4.White, // Color
                Padding = Vector2.Zero, // Spacing around character
                FontStyle = System.Drawing.FontStyle.Regular, // Font regular,bold,italic,etc
                TrimTransparency = true, // Remove excessive transpacy in font
                EffectsOnly = false,
                Debug = false,
            }
            ,
            new FontGlow()
            {
                Radius = 12,
                Color = new Color4(255,255,255,150),
            }
            // new FontOutline()
            // {
            //     Thickness = OutlineThickness,
            //     Color = OutlineColor,
            // },
            // new FontShadow()
            // {
            //     Thickness = ShadowThickness,
            //     Color = ShadowColor,
            // }
            );
            SubtitleLines("&目を閉じて",1054,4569);
            SubtitleLines("%視えるその",2929,4569);
            SubtitleLines("&指先へ",4804,8319);
            SubtitleLines("%めがけた",6679,8319);
            SubtitleLines("&口ずさむ",8554,12069);
            SubtitleLines("%その歌を",10429,12069);
            SubtitleLines("$続けてそう",12304,15350);
            SubtitleLines("&Hand in hand",15350,19100);
            SubtitleLines("%君のその手は",16522,19100);
            SubtitleLines("&知らない",19100,22850);
            SubtitleLines("%誰かの手も",20272,22850);
            SubtitleLines("&Hand in hand",22850,26132);
            SubtitleLines("%握ってるんだ",24022,26132);
            SubtitleLines("&ずっと",26132,29179);
            SubtitleLines("%ずっと",28007,29179);
            SubtitleLines("$ミライまで",29179,32226);

            //First calm
            SubtitleLines("&まだ",44882,48163);
            SubtitleLines("%泣かないで",46054,48163);
            SubtitleLines("&気付かない",48397,51913);
            SubtitleLines("%だけだよ",49804,51913);
            SubtitleLines("&言葉",52382,55663);
            SubtitleLines("%や想い",53554,55663);
            SubtitleLines("$見えづらいからね",55897,59882);


            SubtitleLines("&好きな人",61054,64804);
            SubtitleLines("%好きなこと",62929,64804);
            SubtitleLines("&好きな場所",64804,68554);
            SubtitleLines("%めがけた",66679,68554);
            SubtitleLines("&優しさが",68554,72304);
            SubtitleLines("%変えるんだ",70429,72304);
            SubtitleLines("$明日をそう",72304,75350);
            
            //2nd kiai
            SubtitleLines("&Hand in hand",75350,79100);
            SubtitleLines("%君が叫んだ",76522,79100);
            SubtitleLines("&歌は",79100,82850);
            SubtitleLines("%誰かの手も",80272,82850);
            SubtitleLines("&Hand in hand",82850,86600);
            SubtitleLines("%包みこむから",84022,86600);
            SubtitleLines("&途切れないで",86600,90350);
            SubtitleLines("%だからね",89413,90350);

            SubtitleLines("&Hand in hand",90350,94100);
            SubtitleLines("%強い気持ちは",91522,94100);
            SubtitleLines("&誰かの",94100,97850);
            SubtitleLines("%肩を抱く",95272,97850);
            SubtitleLines("&Hand in hand",97850,101132);
            SubtitleLines("%覚えていてね",99022,101132);
            SubtitleLines("&ずっと",101132,104179);
            SubtitleLines("%ずっと",103007,104179);
            SubtitleLines("$ミライまで",104179,106991);

            //2nd calm

            SubtitleLines("&何気ない",119882,123163);
            SubtitleLines("%言葉",121522,123163);
            SubtitleLines("&覚えてない",123397,126913);
            SubtitleLines("%メロディー",124804,126913);
            SubtitleLines("&知らない",127382,130663);
            SubtitleLines("%うちに",128554,130663);
            SubtitleLines("$笑顔を作ってる",130897,135350);

            SubtitleLines("&その声で",136054,139804);
            SubtitleLines("%その指で",137929,139804);
            SubtitleLines("&その胸で",139804,143554);
            SubtitleLines("%描いた",141679,143554);
            SubtitleLines("&愛しさは",143554,147304);
            SubtitleLines("%伝わるよ",145429,147304);
            SubtitleLines("$明日へそう",147304,150350);

            //3rd kiai

            SubtitleLines("&Hand in hand",150350,154100);
            SubtitleLines("%君が掴んだ",151522,154100);
            SubtitleLines("&その手は",154100,157850);
            SubtitleLines("%遠くまで",155975,157850);
            SubtitleLines("&Hand in hand",157850,161600);
            SubtitleLines("%違う誰かの",159022,161600);
            SubtitleLines("&涙拭う",161600,165350);
            SubtitleLines("%だからね",164413,165350);
            SubtitleLines("&Hand in hand",165350,169100);
            SubtitleLines("%強い気持ちは",166522,169100);
            SubtitleLines("&誰かの",169100,172850);
            SubtitleLines("%肩を抱く",170975,172850);
            SubtitleLines("&Hand in hand",172850,176132);
            SubtitleLines("%覚えていてね",174022,176132);
            SubtitleLines("&ずっと",176132,179179);
            SubtitleLines("%ずっと",178007,179179);
            SubtitleLines("$ミライまで",179179,182225);

            // SubtitleLines("&Mapset:R3aCt10n",182225,184569);
            // SubtitleLines("%Storyboard:R3aCt10n",184569,188788);
            // SubtitleLines("Hitsounds:R3aCt10n",188788,193007);
            SubtitleLines("&目を閉じて",196054,199804);
            SubtitleLines("%視えるその",197929,199804);
            SubtitleLines("&指先へ",199804,203554);
            SubtitleLines("%めがけた",201679,203554);
            SubtitleLines("&口ずさむ",203554,207304);
            SubtitleLines("%その歌を",205429,207304);
            SubtitleLines("$続けてそう",207304,210350);

            SubtitleLines("&Hand in hand",210350,214100);
            SubtitleLines("%君が掴んだ",211522,214100);
            SubtitleLines("&その手は遠",214100,217850);
            SubtitleLines("%くまで",216444,217850);
            SubtitleLines("&Hand in hand",217850,221600);
            SubtitleLines("%違う誰かの",219022,221600);
            SubtitleLines("&涙拭う",221600,225350);
            SubtitleLines("%だからね",224413,225350);


            SubtitleLines("&Hand in hand",225350,229100);
            SubtitleLines("%君が叫んだ",226522,229100);
            SubtitleLines("&歌は誰",229100,232850);
            SubtitleLines("%かの手も",230975,232850);
            SubtitleLines("&Hand in hand",232850,236600);
            SubtitleLines("%包みこむから",234022,236600);
            SubtitleLines("&途切れないで",236600,240350);
            SubtitleLines("%だからね",239413,240350);

            SubtitleLines("&Hand in hand",240350,244100);
            SubtitleLines("%強い気持ちは",241522,244100);
            SubtitleLines("&誰かの肩",244100,247850);
            SubtitleLines("%を抱く",245975,247850);
            SubtitleLines("&Hand in hand",247850,251132);
            SubtitleLines("%覚えていてね",249022,251132);
            SubtitleLines("&ずっと",251132,254179);
            SubtitleLines("%ずっと",253007,254179);
            SubtitleLines("$ミライまで",254179,257226);
            SubtitleLines("$Thank you for playing!",300351,307851);
        }
    
        public void SubtitleLines(string line, int starttime, int endtime)
        {
                double scale = 0.25;
                double lineWidth = 0.5f;
                int fadeduration = 200;

                double posX = 286;
                double posY = 255 ;

                int spawnTime = 0;


                var removingthecharacters = String.Join("",line.Split('#','~','`','-','*','%','&','@'));

                double sequences = 0.0;

                sequences = (removingthecharacters.Length/2.0);

                Log(sequences); //Debug check wording


                double valuepositionshifted = 0;



                if(sequences == 2.5) //Updated Today
                {
                    valuepositionshifted = 72.5 * sequences;
                }
                else if(sequences == 1) //Updated Today
                {
                    valuepositionshifted = 64 * sequences;
                }
                else if(sequences == 2) //Updated Today
                {
                    valuepositionshifted = 71.5 * sequences;
                }
                else if(sequences == 1.5)
                {
                    valuepositionshifted = 67 * sequences;
                }
                else if(sequences == 1)
                {
                    valuepositionshifted = 70 * sequences;
                }
                else if(sequences == 3)
                {
                    valuepositionshifted = 75 * sequences;
                }
                else if(sequences == 6)
                {
                    valuepositionshifted = 31.5 * sequences;
                }
                else
                {
                    valuepositionshifted = (30 * sequences);
                }

                for(int i=0; i<line.Length; i++)
                {
                    if(line[i] == '$')
                    {
                        if(sequences == 3)
                        {
                            valuepositionshifted = 31 * sequences;
                        }
                        if(sequences == 4.5)
                        {
                            valuepositionshifted = 33.5 * sequences;
                        }
                        if(sequences == 4)
                        {
                            valuepositionshifted = 32.5 * sequences;
                        }
                        if(sequences == 11)
                        {
                            valuepositionshifted = 15 * sequences;
                        }

                    }
                }

                if(sequences == 11.5)
                {
                    Log("11.5 detected");
                    valuepositionshifted = 14.5 * sequences;
                }


                posX = posX - valuepositionshifted;


                for(int i=0; i<line.Length; i++)
                {
                    if(line[i] == '`' || line[i] == '~' || line[i] == '-'|| line[i] == '*'|| line[i] == '%' || line[i] == '&' || line[i]=='#' || line[i] =='$' || line[i] =='@')
                    {
                        var ASOHDHAS = 35;
                        var AJSDOASAD = 10;
                        if(line[i] == '~') // 3/2
                        {
                        spawnTime += 673;
                        starttime += spawnTime;
                        //Delay or Fast Forward
                        continue; //Skip so we don't render this character

                        }
                        else if(line[i]=='#') //test
                        {
                            spawnTime += 1641;
                            starttime += spawnTime;
                            continue;

                        }
                        else if(line[i] =='-') // 1/2
                        {
                        spawnTime += 235;
                        starttime += spawnTime;
                        //Delay or Fast Forward
                        continue; //Skip so we don't render this character
                        }
                         
                        else if(line[i] == '`') // 1/4
                        {
                        spawnTime += 468;
                        starttime += spawnTime;
                        //Delay or Fast Forward
                        continue; //Skip so we don't render this character
                        }

                        else if(line[i] == '*')
                        {
                        spawnTime += 703; //5/4
                        starttime += spawnTime;
                        continue;

                        }

                        // else if(line[i] == '!')
                        // {
                        // spawnTime += 938; // 2/1 
                        // starttime += spawnTime;
                        // //Delay or Fast Forward
                        // continue; //Skip so we don't render this character
                        // }

                        else if(line[i] == '&') //Special Situation trigger, one upper left
                        {
                            
                        posX = 285+ASOHDHAS;
                        posX = posX - valuepositionshifted;
                        posY = 225+AJSDOASAD;
                        //Delay or Fast Forward
                        continue; //Skip so we don't render this character
                        }

                        else if(line[i] == '%') //Special Situation, one lower right
                        {
                        posX = 310+ASOHDHAS;
                        posY = 285+AJSDOASAD;
                        //Delay or Fast Forward
                        continue; //Skip so we don't render this character
                        }

                        else if(line[i] == '$') //Special Situation, Center
                        {
                        posX = 301+ahsdaojaj;
                        posY = 250.5+10;
                        posX = posX - valuepositionshifted;
                        //Delay or Fast Forward
                        continue; //Skip so we don't render this character
                        }
                        else if(line[i] == '@') //Special Situation, For I
                        {

                        }


                    }   

                var characteraverage = (line.Length / 2);
                var currentcharacters = line[i];
                string charconvertedtostring = currentcharacters.ToString();

                
                //string characterconversion = new String(line, 1); //Faled
                foreach (var letter in charconvertedtostring) 
                {
                var texture = japaneseFont.GetTexture(charconvertedtostring); //The issue is here, line.ToString converts entire line. But i only want the characters. Solved
                lineWidth += (texture.BaseWidth * scale);
                }
                //Idea is that depending on length, add 100? on X to go left

                foreach (var letter in charconvertedtostring) 
                {
                var texture = japaneseFont.GetTexture(charconvertedtostring);
                if(!texture.IsEmpty)
                {
                
                        var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2((float)(posX),250));
                        sprite.Scale(starttime, scale);
                        sprite.Fade(starttime, starttime + fadeduration,0,1);

                        sprite.Move(OsbEasing.OutCirc, starttime, starttime+fadeduration, (float)posX , posY+20 , (float)posX , posY );

                        sprite.Move(OsbEasing.OutCirc, endtime-fadeduration, endtime, (float)posX , posY , (float)posX, posY-20 );

                        sprite.Fade(endtime-fadeduration, endtime,1,0);
                }
                posX += texture.BaseWidth * scale;

                spawnTime=0; // Move forward the time so we get something like typing effect
                }


                //Use font generator to create 1 char sprite in here then spawn it
                //spawnTime+=1000; // Move forward the time so we get something like typing effect
                }

                // foreach (var letter in line) // For each character inside lyric string line
                // {
                //     var texture = japaneseFont.GetTexture(letter.ToString());
                //     lineWidth += texture.BaseWidth * scale;
                // }   

                // foreach (var letter in line) 
                // { 
                //     var texture = japaneseFont.GetTexture(letter.ToString());

                //     if(!texture.IsEmpty)
                //     {

                //             var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2((float)(posX-(0.5*lineWidth)),250));
                //             sprite.Scale(starttime, scale);
                //             sprite.Fade(starttime, starttime + fadeduration,0,1);

                //             sprite.Move(OsbEasing.OutCirc, starttime, starttime+fadeduration, (float)posX-(0.5*lineWidth) , posY+20 , (float)posX-(0.5*lineWidth) , posY );

                //             sprite.Move(OsbEasing.OutCirc, endtime-fadeduration, endtime, (float)posX-(0.5*lineWidth) , posY , (float)posX-(0.5*lineWidth) , posY-20 );

                //             sprite.Fade(endtime-fadeduration, endtime,1,0);



                //     }
                //     posX += texture.BaseWidth * scale;
                //     spawnTime+=1000; // Move forward the time so we get something like typing effect
                // }
        }


        // public void GenerateLine(string line, int starttime, int endtime)
        // {
        //     double scale = 0.22;
        //     double lineWidth = 0.5f;
        //     int fadeduration = 200;

        //     double posX = 265;
        //     double posY = 250 ;

        //     string convertsline = line;

        //     foreach (var letter in line) // For each character inside lyric string line
        //     {
        //         var texture = japaneseFont.GetTexture(letter.ToString());
        //         lineWidth += texture.BaseWidth * scale;
        //     }   

        //     foreach (var letter in line) 
        //     { 
        //         var texture = japaneseFont.GetTexture(letter.ToString());

        //         if(!texture.IsEmpty)
        //         {
        //             // if(line.Contains("~")||line.Contains("`"))
        //             // {
        //             //     //Select everything until it hits 0 or ~ or `

        //             //     //Example is Hand i~n hand

        //             //     int firstindexesA = line.IndexOf('~'); //First Index
        //             //     Log("First ~ is " + firstindexesA);

        //             //     var firstindexesB = line.LastIndexOf("~"); //Check for more Index
        //             //     Log("Last index is " + firstindexesB);


        //             //     if(firstindexesA == firstindexesB) //In case theres only one indexes
        //             //     {
        //             //         int lastindexes = line[line.Length-1];

        //             //         //Thoughtprocess, select a range on alphabets? select ~ to d, then make new variable with it?
        //             //         //Uses substring maybe?
        //             //         //Regex?

        //             //         //Then put into a new variable, and create sprite?

        //             //         var sprite = layer.CreateSprite(???,OsbOrigin.Centre, new Vector2((float)(posX-(0.5*lineWidth)),250));

        //             //     }

        //             //     // int location = line.IndexOf('~'); // Another method...
        //             //     // while(location != -1)
        //             //     // {
        //             //     //     location = line.IndexOf('~', location + 1);
        //             //     //     Log("Position of ~ is " + location);
        //             //     // }

        //             //     //Removing works, later ba
        //             //     // var charsToRemove = new string[] {"~","`"}; //Removes ~ or `
        //             //     // foreach (var c in charsToRemove)
        //             //     // {
        //             //     //     line = line.Replace(c, string.Empty);
        //             //     // }

        //             //     //Display
        //             // }
        //             // else //No ~
        //             // {
        //                 var sprite = layer.CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2((float)(posX-(0.5*lineWidth)),250));
        //                 sprite.Scale(starttime, scale);
        //                 sprite.Fade(starttime, starttime + fadeduration,0,1);

        //                 sprite.Move(OsbEasing.OutCirc, starttime, starttime+fadeduration, (float)posX-(0.5*lineWidth) , posY+20 , (float)posX-(0.5*lineWidth) , posY );

        //                 sprite.Move(OsbEasing.OutCirc, endtime-fadeduration, endtime, (float)posX-(0.5*lineWidth) , posY , (float)posX-(0.5*lineWidth) , posY-20 );

        //                 sprite.Fade(endtime-fadeduration, endtime,1,0);


        //             //}
        //         }

        //         posX += texture.BaseWidth * scale;


        //     }

        // }
    }
}
