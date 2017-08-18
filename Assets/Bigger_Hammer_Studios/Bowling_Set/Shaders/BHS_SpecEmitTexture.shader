﻿Shader "BHS/BowlingKit/BHS_SpecEmitTexture"
{
Properties
{
	_MainTex ("Texture", 2D) = "white"{}
	_SpecMap ("SpecMap", 2D) = "black"{}
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1.0)
	_SpecPower ("Specular Power", Range(0, 1)) = 0.5
	_EmitMap ("Emissive Texture", 2D) = "black"{}
	_EmitPower ("Emit Power", Range (0, 2)) = 1.0
}
	SubShader
	{
		Tags {"RenderType" = "Opaque"}
		CGPROGRAM
		#pragma surface surf BlinnPhong
		#pragma exclude_renderers flash

		sampler2D _MainTex;
		sampler2D _SpecMap;
		float _SpecPower;
		sampler2D _EmitMap;
		float _EmitPower;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_SpecMap;
			float2 uv_EmitMap;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 tex = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 specTex = tex2D (_SpecMap, IN.uv_SpecMap);
			fixed4 emitTex = tex2D (_EmitMap, IN.uv_EmitMap);

			o.Albedo = tex.rgb;
			o.Specular = _SpecPower;
			o.Gloss = specTex.rgb;
			o.Emission = emitTex.rgb * _EmitPower;
		}
		ENDCG
	}
	Fallback "Specular"
}
