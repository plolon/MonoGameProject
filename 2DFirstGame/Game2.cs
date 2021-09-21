using _2DFirstGame.DrawingHandler;
using _2DFirstGame.DrawingHandler.String.Utils;
using _2DFirstGame.Tiles;
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
        private TexturesUtil texturesUtil;

        private AnimationString gameOverString;
        private bool isGameOver = false;

        private Level level0;

        public Game2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Logger.Info("Game changed panel", null);
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
            texturesUtil = new TexturesUtil(_spriteBatch,
                Content.Load<Texture2D>(""),
                Content.Load<Texture2D>(""),
                Content.Load<Texture2D>(""));
            level0 = new Level(texturesUtil, @"levels\level0.txt");
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Utils.Keyboard.GetState();
            if (Utils.Keyboard.IsPressed(Keys.Up) || Utils.Keyboard.IsPressed(Keys.W))
            {
                level0.Update(Direction.Down);
            }
            if (Utils.Keyboard.IsPressed(Keys.Down) || Utils.Keyboard.IsPressed(Keys.S))
            {
                level0.Update(Direction.Up);
            }
            if (Utils.Keyboard.IsPressed(Keys.Right) || Utils.Keyboard.IsPressed(Keys.D))
            {
                level0.Update(Direction.Left);
            }
            if (Utils.Keyboard.IsPressed(Keys.Left) || Utils.Keyboard.IsPressed(Keys.A))
            {
                level0.Update(Direction.Right);
            }

            if(Utils.Keyboard.GetState().GetPressedKeys() != null)
            {
                foreach(var key in Utils.Keyboard.GetState().GetPressedKeys())
                {
                    Logger.Info($"Pressed: {key.ToString()}", System.ConsoleColor.Red);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            //string fps = getFPS(gameTime);

            if (isGameOver)
            {
                gameOverString.Draw();
            }
            else
            {
                level0.Draw();
               _drawingHelper.DrawString(new Vector2(10, 10), getFPS(gameTime), 0.2f);
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
