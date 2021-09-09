using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using snake.gui;

namespace snake
{
    public class Playground : State
    {
        private Snake _snake;
        private Direction _direction;
        private Cherry _cherry;
        private Wall _wall;
        private Text _text;
        private int _score;
        private ContentManager _contentManager;

        public static Playground Instance()
        {
            return new Playground();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _cherry = new Cherry(new Vector2(100.0f, 100.0f), contentManager);
            _snake = new Snake(new Vector2(100.0f, 100.0f), 3, contentManager);
            _wall = new Wall(contentManager);
            _text = new Text(contentManager);
            _contentManager = contentManager;
            
            base.LoadContent(contentManager);
        }

        public override void Update(GameTime gameTime, StateChanger stateChanger)
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
            
            if(_wall.Collision(new Rectangle((int)_snake.HeadPosition.X, (int)_snake.HeadPosition.Y, 40, 40)))
                stateChanger.ChangeState(MainMenu.Instance(), _contentManager);
            
            _snake.Move(gameTime, _direction);

            if (Collision(_snake.HeadPosition, _cherry.Position))
            {
                _snake.Expand();
                _cherry.Position = ChangePosition();
                ++_score;
            }
            
            base.Update(gameTime, stateChanger);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _snake.Draw(spriteBatch);
            _cherry.Draw(spriteBatch);
            _wall.Draw(spriteBatch);
            _text.SetText(spriteBatch, new Vector2(2.0f, 2.0f), "Score: " + _score);
            
            base.Draw(spriteBatch);
        }

        private static bool Collision(Vector2 a, Vector2 b)
        {
            return a.X < b.X + 40 &&
                   a.X + 40 > b.X &&
                   a.Y < b.Y + 40 &&
                   a.Y + 40 > b.Y;
        }

        private static Vector2 ChangePosition()
        {
            Random random = new Random();
            Vector2 temp;
            temp.X = random.Next(40, 1240);
            temp.Y = random.Next(40, 680);
            return temp;
        }
    }
}