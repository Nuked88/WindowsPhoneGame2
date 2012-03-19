using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
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
    /// <summary>
    /// Questo è il tipo principale per il gioco
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
      enum State
        {
            Walking
        }
State mCurrentState = State.Walking;
        
        Map map;
        private Microsoft.Xna.Framework.Rectangle m_panelRectangle;
        IDisplayDevice mapDisplayDevice;
        int a = 0,b=250;
        Texture2D character;
        public Layer collision;
 Actor1 myChar;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        xTile.Dimensions.Rectangle viewport;
        
        //First state we have when character is walking
        

        public Game1()
        {
           
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // La frequenza fotogrammi è di 30 fps per impostazione predefinita per Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Estendere la durata della batteria in caso di blocco.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Consente al gioco di eseguire tutte le operazioni di inizializzazione necessarie prima di iniziare l'esecuzione.
        /// È possibile richiedere qualunque servizio necessario e caricare eventuali
        /// contenuti non grafici correlati. Quando si chiama base.Initialize, tutti i componenti vengono enumerati
        /// e inizializzati.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: aggiungere qui la logica di inizializzazione

            // set map viewport to match window size
            viewport = new xTile.Dimensions.Rectangle(0, 250,
               graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            //initialize xtile map 
            mapDisplayDevice = new XnaDisplayDevice( this.Content, this.GraphicsDevice);
            map = Content.Load<Map>("Maps\\Map01");
            //xtile res
            map.LoadTileSheets(mapDisplayDevice);

            //xtile rendering

            m_panelRectangle = new Microsoft.Xna.Framework.Rectangle(
                0, viewport.Height - 56, viewport.Width, 56);
            viewport.Y = 250;
           
            base.Initialize();  
        }

        /// <summary>
        /// LoadContent verrà chiamato una volta per gioco e costituisce il punto in cui caricare
        /// tutto il contenuto.
        /// </summary>
        protected override void LoadContent()
        {
            // Creare un nuovo SpriteBatch, che potrà essere utilizzato per disegnare trame.
            spriteBatch = new SpriteBatch(GraphicsDevice);
              

            //load xtile map

           
            character = Content.Load<Texture2D>("npc1");

            myChar = new Actor1(character, new Point(0, 0), new Microsoft.Xna.Framework.Rectangle(0, 0, character.Width, character.Height), map);
            // TODO: utilizzare this.content per caricare qui il contenuto del gioco
        }

        /// <summary>
        /// UnloadContent verrà chiamato una volta per gioco e costituisce il punto in cui scaricare
        /// tutto il contenuto.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: scaricare qui tutto il contenuto non gestito da ContentManager
        }

        /// <summary>
        /// Consente al gioco di eseguire la logica per, ad esempio, aggiornare il mondo,
        /// controllare l'esistenza di conflitti, raccogliere l'input e riprodurre l'audio.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Update(GameTime gameTime)
        {
            // Consente di uscire dal gioco
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: aggiungere qui la logica di aggiornamento

            map.Update(gameTime.ElapsedGameTime.Milliseconds);

            
            
             foreach (TouchLocation location in TouchPanel.GetState())
    {
      
            collision = myChar.collisiona;

            if (mCurrentState == State.Walking)
            {
               
                Point newPos = myChar.Position;
                
                 //newPos.X = (int)location.Position.X;
                //    newPos.Y = (int)location.Position.Y;
                newPos.X += 15;
                allvar.startpos = viewport.Y; 

                if (!myChar.calculateCollision(newPos, true))
                {
                    myChar.Position.X = newPos.X;
                   // myChar.Position.Y = newPos.Y;
                }
                // In case of collision then modify the position of the player to stick to the water rather than just
                // leaving the original player position unmodified
                else
                {
                    myChar.Position.X = (((int)newPos.X + myChar.Collisionbox.Width) / collision.TileWidth) *
                        collision.TileWidth - myChar.Collisionbox.Width;
                }
                    // In case of collision then modify the position of the player to stick to the water rather than just
                    // leaving the original player position unmodified



                //Debug.WriteLine("Collision X: " + location + " Collision Y: " + newPos.Y + "\n");
                base.Update(gameTime);
            } 
             }
        }

        /// <summary>
        /// Viene chiamato quando il gioco deve disegnarsi.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
 myChar.Position.Y = b;
            // TODO: aggiungere qui il codice di disegno

            //render xtile map
            map.Draw(mapDisplayDevice, viewport);
            myChar.draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
