using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    public class Snake
    {
        private const float Speed = 40.0f;
        private const int Time = 300;
        
        private float _time;
        private readonly List<Tail> _tails;
        private readonly Tail _tail;
        private readonly Texture2D _texture;

        public Snake(Vector2 position, int length, ContentManager contentManager)
        {
            _tails = new List<Tail>();
            _tail = new Tail(position);
            _tails.Add(_tail);
            Tail.Init(_tails, length);
            _texture = contentManager.Load<Texture2D>("snake");
        }

        public void Expand()
        {
            _tails.Add(new Tail(_tails[^1].Position));
        }

        public void Move(GameTime gameTime, Direction direction)
        {
            _time += gameTime.ElapsedGameTime.Milliseconds;
            if (_time > Time)
            {
                _time -= Time;
                
                switch (direction)
                {
                    case Direction.Up:
                        _tails[0].Position.Y -= Speed;
                        break;
                
                    case Direction.Down:
                        _tails[0].Position.Y += Speed;
                        break;
                
                    case Direction.Left:
                        _tails[0].Position.X -= Speed;
                        break;
                
                    case Direction.Right:
                        _tails[0].Position.X += Speed;
                        break;
                    
                    default:
                        _tails[0].Position.Y += Speed;
                        break;
                }
                
                _tail.PreviousPosition = _tail.Position;
                Tail.Move(_tails);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var dest in _tails.Select(tail => new Rectangle((int)tail.Position.X, (int)tail.Position.Y, 40, 40)))
                spriteBatch.Draw(_texture, dest, Color.White);
        }

        public Vector2 HeadPosition => _tails[0].Position;
    }
}