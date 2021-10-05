#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;

sampler SpriteTextureSampler : register(s0);
Texture2D <float4> myTex2D;
float Visibility;

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 GaussianBlur(VertexShaderOutput input) : COLOR0
{
		float4 tex;
		tex = myTex2D.Sample(SpriteTextureSampler, input.TextureCoordinates.xy) * .6f;
		tex += myTex2D.Sample(SpriteTextureSampler, input.TextureCoordinates.xy + (0.005)) * .2f;
		return tex;
}
float4 LinearFade(VertexShaderOutput input) : COLOR
{
	return float4(tex2D(SpriteTextureSampler, input.TextureCoordinates) * sin((input.TextureCoordinates.y - 0.5) * 3.15) * Visibility) * input.Color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL GaussianBlur();
	}
	pass P1
	{
		PixelShader = compile PS_SHADERMODEL LinearFade();
	}
};