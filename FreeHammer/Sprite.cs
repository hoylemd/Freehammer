using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeHammer
{
    public class Sprite
    {
        // texture for the sprite
        public Texture2D texture { get; private set; }

        // offset of the center of the sprite from the top left corner
        Point centerOffset { get; set; }

        // size and location of the sprite
        Rectangle imageRect { get; set; }

        // the colour/alpha mask to draw the sprite with
        Color mask { get; set; }

        // Constructor
        public Sprite(Texture2D tex, Point offset, Point size, Color msk)
        {
            // set up all the data
            this.texture = tex;
            this.centerOffset = offset;
            this.imageRect = new Rectangle(0, 0, size.X, size.Y);
            this.mask = msk;
        }

        /* EXPECTS A BEGUN spriteBatch */
        // Draw moethod for the sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, imageRect, this.mask);
        }

        // Update Method
        // takes in the new location of the sprite
        public void Update(Point location)
        {
            this.imageRect = new Rectangle(
                location.X - this.centerOffset.X, 
                location.Y - this.centerOffset.Y, 
                this.imageRect.Width, 
                this.imageRect.Height);
        }

    }

}
