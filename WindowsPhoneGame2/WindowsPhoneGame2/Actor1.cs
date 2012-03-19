using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.IO;
using xTile;
using xTile.Dimensions;
using xTile.Display;
using xTile.Layers;
using xTile.Tiles;
using xTile.Format;
using xTile.ObjectModel;
using xTile.Pipeline;
using System.Diagnostics;
namespace WindowsPhoneGame2
{
    class Actor1
    {
          Map map;
        Texture2D Texture;
        public Layer collisiona;
        public Point Position;
        public Microsoft.Xna.Framework.Rectangle Collisionbox;

        public Actor1(Texture2D texture, Point position, Microsoft.Xna.Framework.Rectangle collisionBox, Map map)
            
        {
            this.map = map;
            collisiona = map.Layers[3];
            Position = position;
            Texture = texture;
            Collisionbox = collisionBox;
        }

        /// <summary>
        /// Checks for collisions
        /// </summary>
        /// <param name="newPos"></param>
        /// <param name="horizontal">true if cheking horizontal collisions, false in case of vertical collisions</param>
        /// <returns></returns>
        public bool calculateCollision(Point newPos, bool horizontal)
        {
            //Debug.WriteLine("Collision X: " + Collisionbox.X + " Collision Y: " + Collisionbox.Y + "\n");

            bool collided = false;

            if (horizontal)
            {
                Debug.WriteLine(newPos.Y);
                // Right side of the sprite
                if (newPos.X > Position.X)
                {
                    // Scan every pixel from top to bottom on the rigth side of the sprite
                    for (int i = 0; i < Collisionbox.Height; i++)
                    {
                        if (CheckTile((int)newPos.X + Collisionbox.Width, Position.Y + i))
                        {
                            collided = true;
                            break;
                        }
                    }
                }
                // Left side of the sprite
                else if (newPos.X < Position.X)
                {
                    // Scan every pixel from top to bottom on the left side of the sprite
                    for (int i = 0; i < Collisionbox.Height; i++)
                    {
                        if (CheckTile((int)newPos.X, Position.Y + i))
                        {
                            collided = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                // Upper part of the sprite
                if (newPos.Y < Position.Y)
                {
                    // Scan every pixel from left to right on the upper part of the sprite
                    for (int i = 0; i < Collisionbox.Width; i++)
                    {
                        if (CheckTile((int)Position.X + i, newPos.Y))
                        {
                            collided = true;
                            break;
                        }
                    }
                }
                // Bottom part of the sprite
                else if (newPos.Y > Position.Y)
                {
                    // Scan every pixel from left to right on the bottom part of the sprite
                    for (int i = 0; i < Collisionbox.Width; i++)
                    {
                        if (CheckTile((int)Position.X + i, newPos.Y + Collisionbox.Height))
                        {
                            collided = true;
                            break;
                        }
                    }
                }
            }

            return collided;
        }

        /// <summary>
        /// Checks a tile in a given position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>true in case of water</returns>
        public bool CheckTile(int x, int y)
        {
            y = (int)allvar.startpos + y;
            Location location = new Location(x, y);

            Tile tile =  collisiona.Tiles[collisiona.GetTileLocation(location)];

            if (tile != null)
            {
                if (tile.TileIndex == 20)
                {
                    return true;
                }
            }
           // 
            return false;
        }

        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();

            spritebatch.Draw(Texture, new Vector2(Position.X, Position.Y), Color.White);

            spritebatch.End();
        }
    
    }
}
