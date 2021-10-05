using _2DFirstGame.DrawingHandler;
using _2DFirstGame.Shaders;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2DFirstGame
{
    public class Game3 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private DrawingHelper _drawingHelper;
        Texture2D background;
        RenderTarget2D target;
        ShaderHelper shaders;

        public Game3()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
            
        }

        protected override void Initialize()
        {
            target = new RenderTarget2D(GraphicsDevice, 1080, 720);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("background");
            shaders = new ShaderHelper(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //clear
            GraphicsDevice.Clear(Color.Black);
            //load effects (can use passes)
            Effect eff1 = shaders.GetEffect(ShaderHelper.Effects.Blur);
            Effect eff2 = shaders.GetEffect(ShaderHelper.Effects.LinearFade);
            //set render target
            GraphicsDevice.SetRenderTarget(target);
            //draw first effect
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            eff2.CurrentTechnique.Passes[0].Apply();
            _spriteBatch.Draw(background, new Vector2(0, background.Height), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.FlipVertically, 0f);

            //draw second effect from targer
            GraphicsDevice.SetRenderTarget(null);
            eff1.CurrentTechnique.Passes[0].Apply();
            _spriteBatch.Draw(target, Vector2.Zero, Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            _spriteBatch.End();

        }
    }
}
