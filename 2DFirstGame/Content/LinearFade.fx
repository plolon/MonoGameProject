#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
float Visibility;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};


struct VertexShaderOutput
{
	float2 texCoord : TEXCOORD0;
	float4 color : COLOR0;
};

float4 LinearFadePixelShader(VertexShaderOutput input) : COLOR0
{
	return float4(tex2D(SpriteTextureSampler, input.texCoord) * sin((input.texCoord.y - 0.5) * 3.15) * Visibility) * input.color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL LinearFadePixelShader();
	}
};