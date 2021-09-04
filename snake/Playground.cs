using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake
{
    public class Playground
    {
        private Snake _snake;
        private Direction _direction;
        private Cherry _cherry;

        public void LoadContent(ContentManager contentManager)
        {
            _cherry = new Cherry(new Vector2(10.0f, 10.0f), contentManager);
            _snake = new Snake(new Vector2(100.0f, 100.0f), 3, contentManager);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Up))
                _direction = Direction.Up;
            if (state.IsKeyDown(Keys.Down))
                _direction = Direction.Down;
            if (state.IsKeyDown(Keys.Left))
                _direction = Direction.Left;
            if (state.IsKeyDown(Keys.Right))
                _direction = Direction.Right;
            
            _snake.Move(gameTime, _direction);

            if (Collision(_snake.HeadPosition, _cherry.Position))
            {
                _snake.Expand();
                _cherry.Position = ChangePosition();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _snake.Draw(spriteBatch);
            _cherry.Draw(spriteBatch);
        }

        private static bool Collision(Vector2 a, Vector2 b)
        {
            return a.X < b.X + 8 &&
                   a.X + 8 > b.X &&
                   a.Y < b.Y + 8 &&
                   a.Y + 8 > b.Y;
        }

        private static Vector2 ChangePosition()
        {
            Random random = new Random();
            Vector2 temp;
            temp.X = random.Next(10, 100);
            temp.Y = random.Next(10, 100);
            return temp;
        }
    }
}