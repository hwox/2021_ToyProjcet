Shader "Custom/clickPosShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Center ("Center", Vector) = (0, 0, 0, 0)
		_Radius ("Radius", Range(0,100)) = 1
		_Border ("Border", Range(0,100)) = 10
		_AreaColor ("Area Color", Color) = (1, 0.2, 1, 1)
	}

	SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

		CGPROGRAM
		#pragma surface surf Lambert noambient alpha:fade

		struct Input
		{
			float2 uv_MainTex;
			float3 viewDir;
			float3 worldPos;
		};

		sampler2D _MainTex;
		float2 _Center;
		float _Radius;
		float _Border;
		fixed3 _AreaColor;

		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
			float dist = distance(_Center, IN.worldPos);

			if (dist > _Radius && dist < _Radius + _Border)
			{
				o.Albedo = _AreaColor.rgb;
			}
			else
			{
				o.Albedo = mainTex.rgb;
			}

			o.Alpha = mainTex.a;
		}

		ENDCG
    }
}
