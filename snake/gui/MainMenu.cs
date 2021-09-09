using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake.gui
{
    public class MainMenu : State
    {
        private List<string> _options;
        private int _index;
        private Text _text;
        private KeyboardState _oldState;
        private ContentManager _contentManager;

        public static MainMenu Instance()
        {
            return new MainMenu();
        }
        
        public override void LoadContent(ContentManager contentManager)
        {
            _options = new List<string>
            {
                "Start",
                "Quit"
            };

            _index = 0;
            _text = new Text(contentManager);
            _contentManager = contentManager;
            
            base.LoadContent(contentManager);
        }

        public override void Update(GameTime gameTime, StateChanger stateChanger)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up) && _oldState.IsKeyUp(Keys.Up) && _index > 0)
                --_index;
            if (state.IsKeyDown(Keys.Down) && _oldState.IsKeyUp(Keys.Down))
                ++_index;
            if (state.IsKeyDown(Keys.Enter) && _oldState.IsKeyUp(Keys.Enter))
            {
                if(_index == 0)
                    stateChanger.ChangeState(Playground.Instance(), _contentManager);
                else 
                    System.Environment.Exit(0);
            }

            _oldState = state;
            
            base.Update(gameTime, stateChanger);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _options.Count; ++i)
            {
                Color drawing = Color.White;
                
                if (i == _index)
                    drawing = Color.Gray;
                
                _text.SetText(spriteBatch, new Vector2(1280.0f / 2.0f, 720.0f / 2.0f + (i * 24)), _options[i], drawing);
            }
            
            base.Draw(spriteBatch);
        }

        public override void Destroy()
        {
            _contentManager.Unload();
            base.Destroy();
        }
    }
}