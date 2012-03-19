
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Graphics;
namespace WindowsPhoneGame2
{

        public struct allvar
        {
            public static Vector2 posizione, center_img, c_sprite, p2;
            public static byte velup, velside;
            public static Texture2D img_anime, sprite1;
            public static SpriteBatch spriteBatch;
            public static int screen_height, screen_width, position, speed, stop = 0;
            public static Texture2D new_texture;
            public static Vector2 new_position;
            public static Vector2 new_speed;
            public static float radius = 7.0f / 2;
            public static float rotate1, a = 1, startpos = 0, temposx = 0, temposy = 0;
            public static string moving = "down", texto = "", tmoving = "";
            // Text management
            public static SpriteFont spFont;
            public static SpriteBatch spBatch;



        }
    

}
