using _2DFirstGame.DrawingHandler;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace _2DFirstGame
{
    public class Game2 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private FPS_Handler _frameCounter;
        private DrawingHelper _drawingHelper;

        private Background background;
        private AnimationString gameOverString;
        private bool isGameOver = false;

        public Game2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _frameCounter = new FPS_Handler();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawingHelper = new DrawingHelper(_spriteBatch,
                Content.Load<Texture2D>(@"StringDrawing\Numbers"),
                Content.Load<Texture2D>(@"StringDrawing\Characters"),
                Content.Load<Texture2D>(@"StringDrawing\Specials"));
            gameOverString = new AnimationString(_spriteBatch, _drawingHelper, new Vector2(75, 175), "GAME OVER");
            background = new Background(Content.Load<Texture2D>(@"Textures\brick"), _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Utils.Keyboard.GetState();
            if (Utils.Keyboard.IsPressed(Keys.Up) || Utils.Keyboard.IsPressed(Keys.W))
            {
                background.Move(Direction.Down);
            }
            if (Utils.Keyboard.IsPressed(Keys.Down) || Utils.Keyboard.IsPressed(Keys.S))
            {
                background.Move(Direction.Up);
            }
            if (Utils.Keyboard.IsPressed(Keys.Right) || Utils.Keyboard.IsPressed(Keys.D))
            {
                background.Move(Direction.Left);
            }
            if (Utils.Keyboard.IsPressed(Keys.Left) || Utils.Keyboard.IsPressed(Keys.A))
            {
                background.Move(Direction.Right);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            string fps = getFPS(gameTime);

            if (isGameOver)
            {
                gameOverString.Draw();
            }
            else
            {
                background.Draw(_spriteBatch);
                _drawingHelper.DrawString(new Vector2(15, 15), getFPS(gameTime), 0.3f);
            }
            _spriteBatch.End();
        }

        private string getFPS(GameTime gameTime)
        {

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _frameCounter.Update(deltaTime);
            return $"FPS: {_frameCounter.AverageFramesPerSecond.ToString("F0")}";
        }
    }
}
