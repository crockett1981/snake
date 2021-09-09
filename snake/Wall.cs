using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    public class Wall
    {
        private readonly Texture2D _texture;
        private readonly Rectangle _border;
        
        public Wall(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("brick");
            _border = new Rectangle(40, 40, 1280 - 40, 720 - 40);
        }

        public bool Collision(Rectangle source)
        {
            return source.X < _border.X || source.X > _border.Width ||
                   source.Y < _border.Y || source.Y > _border.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _border.Width + 40; i += 40)
            {
                spriteBatch.Draw(_texture, new Rectangle(i, 0, 40, 40), Color.White);
                spriteBatch.Draw(_texture, new Rectangle(i, 680, 40, 40), Color.White);
            }

            for (int i = 40; i < _border.Height; i += 40)
            {
                spriteBatch.Draw(_texture, new Rectangle(0, i, 40, 40), Color.White);
                spriteBatch.Draw(_texture, new Rectangle(1240, i, 40, 40), Color.White);
            }
        }
    }
}