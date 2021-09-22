Shader "Unlit/newCartoonShader"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_BumpMap("Normal Map", 2D) = "bump" {}
	}
	Subshader
	{
		Tags{ "RenderType" = "Opaque" }

		cull back
		CGPROGRAM
		#pragma surface surf _lightFunc

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		sampler2D _MainTex;
		sampler2D _BumpMap;

		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			o.Albedo = mainTex.rgb;
			o.Alpha = 1.0f;
		}

		// 라이트 함수
		float4 Lighting_lightFunc(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
		{
			float3 bandedDiffuse;
			float nDotLight = dot(s.Normal, lightDir) * 0.5f + 0.5f;

			float bandNum = 3.0f;
			bandedDiffuse = ceil(nDotLight * bandNum) / bandNum;

			float rim = abs(dot(s.Normal, viewDir));
			if (rim > 0.3)
			{
				rim = 1;
			}
			else
			{
				rim = -1;
			}

			float4 outColor;
			outColor.rgb = (s.Albedo) * bandedDiffuse * _LightColor0.rgb * rim * atten;
			outColor.a = s.Alpha;
			return outColor;
		}
		ENDCG
	}
}
