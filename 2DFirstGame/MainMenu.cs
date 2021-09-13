using _2DFirstGame.DrawingHandler;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DFirstGame
{
    public class MainMenu : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private DrawingHelper _drawingHelper;

        private int currentlySelected = 1;
        private float newGameScale = 0.5f;
        private float loadGameScale = 0.5f;
        private float optionsScale = 0.5f;

        private int test;

        private bool isPressed = false;

        public MainMenu()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawingHelper = new DrawingHelper(_spriteBatch,
                Content.Load<Texture2D>(@"StringDrawing\Numbers"),
                Content.Load<Texture2D>(@"StringDrawing\Characters"),
                Content.Load<Texture2D>(@"StringDrawing\Specials"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Utils.Keyboard.GetState();
            if (Utils.Keyboard.HasBeenPressed(Keys.Up))
            {
                currentlySelected--;
            }
            if (Utils.Keyboard.HasBeenPressed(Keys.Down))
            {
                currentlySelected++;
            }

            changeSelected();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            _drawingHelper.DrawString(new Vector2(100, 100), "new game", newGameScale);
            _drawingHelper.DrawString(new Vector2(100, 200), "load", loadGameScale);
            _drawingHelper.DrawString(new Vector2(100, 300), "options", optionsScale);
            _spriteBatch.End();
        }

        private void changeSelected()
        {
            switch (currentlySelected)
            {
                case 1:
                    newGameScale = 1f;
                    loadGameScale = 0.5f;
                    optionsScale = 0.5f;
                    break;
                case 2:
                    loadGameScale = 1f;
                    newGameScale = 0.5f;
                    optionsScale = 0.5f;
                    break;
                case 3:
                    optionsScale = 1f;
                    newGameScale = 0.5f;
                    loadGameScale = 0.5f;
                    break;
            }
        }
    }
}
