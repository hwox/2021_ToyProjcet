Shader "Custom/clickPosShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("NoiseTex", 2D) = "White" {}
		_Cut ("Alpha Cut", Range(0,1)) = 0.1
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

		CGPROGRAM
		#include "UnityCG.cginc"
		#pragma surface surf Lambert noambient alpha:fade

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_NoiseTex;
			float3 viewDir;
		};

		sampler2D _MainTex;
		sampler2D _NoiseTex;
		float _Cut ;

		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
			float4 noise = tex2D(_NoiseTex, IN.uv_NoiseTex);

			o.Albedo = mainTex.rgb;
			
			float rim = saturate(dot(o.Normal, IN.viewDir));
			rim = pow(1 - rim, 3);

			float alpha;
			if (noise.r >= _Cut)
			{
				alpha = rim;
			}
			else
			{
				alpha = 0;
			}

			float outline;
			if (noise.r >= _Cut * 1.3)
			{
				outline = 0;
			}
			else
			{
				outline = 0.5;
			}

			o.Emission = mainTex.rgb;
			o.Albedo = outline * _LightColor0.rgb;
			o.Alpha = alpha;
		}

		ENDCG
    }
}
