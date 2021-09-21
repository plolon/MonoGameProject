using _2DFirstGame.DrawingHandler;
using _2DFirstGame.DrawingHandler.String.Utils;
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

        private Background background;

        private int currentlySelected = 1;
        private float newGameScale = 0.5f;
        private float loadGameScale = 0.5f;
        private float optionsScale = 0.5f;

        private AnimationString title;

        public MainMenu()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Logger.Info("Game runned", null);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawingHelper = new DrawingHelper(_spriteBatch,
                Content.Load<Texture2D>(@"StringDrawing\Numbers"),
                Content.Load<Texture2D>(@"StringDrawing\Characters"),
                Content.Load<Texture2D>(@"StringDrawing\Specials"));
            background = new Background(Content.Load<Texture2D>(@"Textures\brick"), _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            title = new AnimationString(_spriteBatch, _drawingHelper, new Vector2(50, 20), "game title");
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
            background.Draw(_spriteBatch);
            title.Draw();
            _drawingHelper.DrawString(new Vector2(100, 150), "new game", newGameScale);
            _drawingHelper.DrawString(new Vector2(100, 250), "load", loadGameScale);
            _drawingHelper.DrawString(new Vector2(100, 350), "options", optionsScale);
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
