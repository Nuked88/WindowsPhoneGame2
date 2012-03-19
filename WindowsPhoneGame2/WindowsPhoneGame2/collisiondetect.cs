using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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
    class collisiondetect
    {
        Map map;
        Texture2D Texture;
        public Layer collision;
        public Point Position;
        public Microsoft.Xna.Framework.Rectangle Collisionbox;

        /// <summary>
        /// Checks for collisions
        /// </summary>
        /// <param name="newPos"></param>
        /// <param name="horizontal">true if cheking horizontal collisions, false in case of vertical collisions</param>
        /// <returns></returns>
        public bool calculateCollision(Point newPos, bool horizontal)
        {
            //   Debug.WriteLine("Collision X: " + Collisionbox.X + " Collision Y: " + Collisionbox.Y + "\n");

            bool collided = false;

            if (horizontal)
            {
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
        private bool CheckTile(int x, int y)
        {
            Location location = new Location(x, y);

            Tile tile = collision.Tiles[collision.GetTileLocation(location)];

            if (tile != null)
            {
                if (tile.TileIndex == 15)
                {
                    return true;
                }
            }
            Debug.WriteLine(tile.TileIndex);
            return false;
        }

    }
}
