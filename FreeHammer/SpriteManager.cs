using System;
using System.Collections;
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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // Graphics objects
        SpriteBatch spriteBatch;

        // list of all the sprites
        List<Sprite> allSprites;

        // Constructor
        public SpriteManager(Game game, GraphicsDevice graphicsDevice)
            : base(game)
        {
            // create the spriteBatch
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // Initialize the sprite list
            allSprites = new List<Sprite>();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: update the sprites animations if any
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            int i = 0;

            // start up the spriteBatch
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            // iterate through the list and draw em all
            for (i = 0; i < allSprites.Count; i++)
            {
                allSprites[i].Draw(spriteBatch);
            }

            // close down the spritebatch
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Add a sprite to the list
        public void AddSprite(Sprite sprite)
        {
            allSprites.Add(sprite);
        }

        // remove a sprite from the list
        public void RemoveSprite(Sprite sprite)
        {
            allSprites.Remove(sprite);
        }
    }
}