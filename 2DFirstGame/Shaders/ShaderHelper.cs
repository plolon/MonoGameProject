using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.Shaders
{
    public class ShaderHelper
    {
        private List<Effect> effects;

        public ShaderHelper(ContentManager content)
        {
            effects = new List<Effect>();
            LoadEffects(content);
        }

        public Effect GetEffect(Effects effectType)
        {
            return effects[(int)effectType];
        }

        private void LoadEffects(ContentManager content)
        {
            Effect linearFade = content.Load<Effect>(@"Shaders\LinearFade");
            linearFade.Parameters["Visibility"].SetValue(0.7f);
            effects.Add(linearFade);
            Effect gaussianBlur = content.Load<Effect>(@"Shaders\GaussianBlur");
            effects.Add(gaussianBlur);
        }

        public enum Effects
        {
            LinearFade,
            Blur,
        }
    }
}
