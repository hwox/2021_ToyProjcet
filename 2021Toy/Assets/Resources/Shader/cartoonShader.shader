Shader "Unlit/cartoonShader"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (0,0,0,1)
		_OutlineWidth("Outline width", Range(0.01, 1.0)) = 0.1 // outline 사이즈
	}

		CGINCLUDE
		#include "UnityCG.cginc"

		struct vertexInput 
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct vertexOutput
		{
			float4 vertex : SV_POSITION;
		};

		float _OutlineWidth;
		float4 _OutlineColor;

		vertexOutput vert(vertexInput v)
		{
			vertexOutput o;

			float3 _normalized = normalize(v.normal); 
			float3 _outlinePos = v.vertex + _normalized * (_OutlineWidth * 0.1f);

			o.vertex = UnityObjectToClipPos(_outlinePos);  // 이걸 다시월드 스페이스로 바꿔줌
			return o;
		}

		ENDCG

		SubShader
		{
			cull front
			Pass{
			// 렌더링 아웃라인

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

				half4 frag(vertexOutput i) : SV_Target
				{
					return _OutlineColor;
				}

			ENDCG
			}

			cull back
			// surface 
			CGPROGRAM
			#pragma surface surf _lightFunc noambient

			struct Input
			{
				float2 uv_MainTex;
			};

			sampler2D _MainTex;


			void surf(Input IN, inout SurfaceOutput o)
			{
				float4 mainTex = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = mainTex.rgb;
				o.Alpha = 1.0f;
			}

			// 라이트 함수
			float4 Lighting_lightFunc(SurfaceOutput s, float3 lightDir, float atten)
			{
				float3 bandedDiffuse;
				float nDotLight = dot(s.Normal, lightDir) * 0.5f + 0.5f;

				float bandNum = 3.0f;
				bandedDiffuse = ceil(nDotLight * bandNum) / bandNum;

				float4 outColor;
				outColor.rgb = (s.Albedo) * bandedDiffuse * _LightColor0.rgb * atten;
				outColor.a = s.Alpha;

				return outColor;
			}
			ENDCG
		}
}
