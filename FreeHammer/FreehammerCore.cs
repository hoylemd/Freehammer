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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace FreeHammer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FreehammerCore : Microsoft.Xna.Framework.Game
    {
        // Graphics control objects
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteManager spriteManager;

        // texture Pointers
        Texture2D starTex;

        // sprite Pointers
        Sprite starSprite;
        Sprite tempSprite;

        // mouse state registers
        MouseState prevMouse;
        MouseState currentMouse;
        Point mouseLocation;

        // Sprite effect masks
        Color transparentMask = new Color(new Vector4(1, 1, 1, 0.5f));

        // Constructor
        public FreehammerCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Set mouse visible
            IsMouseVisible = true;

            // set up the sprite manager
            spriteManager = new SpriteManager(this, GraphicsDevice);

            // Add sprite Manager component
            Components.Add(spriteManager);

            // return to base
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load in the star texture
            starTex = Content.Load<Texture2D>("img/blue/BlueStar");

            // create the star sprite
            starSprite = new Sprite(
                            starTex,
                            new Point(50, 50),
                            new Point(100, 100),
                            Color.White
                        );

            // load it into the sprite manager
            spriteManager.AddSprite(starSprite);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // register the mouse states
            prevMouse = currentMouse;
            currentMouse = Mouse.GetState();
            mouseLocation = new Point(currentMouse.X, currentMouse.Y);

            // Mouse Left button events
            if (currentMouse.LeftButton == ButtonState.Pressed)
            {
                // button down
                if (prevMouse.LeftButton == ButtonState.Released)
                {
                    // Create the position preview sprite
                    tempSprite = new Sprite(
                            starTex,
                            new Point(50, 50),
                            new Point(100, 100),
                            transparentMask
                        );

                    // set it's location
                    tempSprite.Update(mouseLocation);

                    // add it to the manager
                    spriteManager.AddSprite(tempSprite);
                }
                // button held
                else
                {
                    // update the preview sprite's location
                    tempSprite.Update(mouseLocation);
                }
            }
            else
            {
                // button up
                if (prevMouse.LeftButton == ButtonState.Pressed)
                {
                    //move the sprite
                    starSprite.Update(new Point(prevMouse.X, prevMouse.Y));

                    //remove the preview sprite
                    spriteManager.RemoveSprite(tempSprite);
                    tempSprite = null;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
