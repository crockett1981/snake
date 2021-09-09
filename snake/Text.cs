using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    public class Text
    {
        private readonly SpriteFont _font;
        
        public Text(ContentManager contentManager)
        {
            _font = contentManager.Load<SpriteFont>("font");
        }

        public void SetText(SpriteBatch spriteBatch, Vector2 position, string text)
        {
            spriteBatch.DrawString(_font, text, position, Color.Black);
        }
        
        public void SetText(SpriteBatch spriteBatch, Vector2 position, string text, Color color)
        {
            spriteBatch.DrawString(_font, text, position, color);
        }
    }
}