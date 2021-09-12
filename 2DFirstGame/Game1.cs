using _2DFirstGame.DrawingHandler;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DFirstGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private FPS_Handler _frameCounter;
        private DrawingHelper _drawingHelper;

        public Game1()
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
            _drawingHelper = new DrawingHelper(_spriteBatch, Content.Load<Texture2D>(@"StringDrawing\Numbers"), Content.Load<Texture2D>(@"StringDrawing\Characters"));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            string fps = getFPS(gameTime);
            // TODO: Display fps
            _drawingHelper.DrawString(new Vector2(15, 15), getFPS(gameTime), 0.3f);
            _spriteBatch.End();
        }

        private string getFPS(GameTime gameTime)
        {

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _frameCounter.Update(deltaTime);
            return $"FPS {_frameCounter.AverageFramesPerSecond.ToString("F0")}";
        }
    }
}
