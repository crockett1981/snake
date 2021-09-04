using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    public class Cherry
    {
        public Vector2 Position { set; get; }
        private readonly Texture2D _texture;

        public Cherry(Vector2 position, ContentManager contentManager)
        {
            Position = position;
            _texture = contentManager.Load<Texture2D>("cherry");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}