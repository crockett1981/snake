using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace snake
{
    public class StateChanger
    {
        private readonly List<State> _states;

        public StateChanger()
        {
            _states = new List<State>();
        }

        public void ChangeState(State state, ContentManager contentManager)
        {
            if (_states.Any())
            {
                _states[^1].Destroy();
                _states.Remove(_states[^1]);
            }
            
            _states.Add(state);
            _states[^1].LoadContent(contentManager);
        }

        public void Update(GameTime gameTime)
        {
            _states[^1].Update(gameTime, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _states[^1].Draw(spriteBatch);
        }
    }
}