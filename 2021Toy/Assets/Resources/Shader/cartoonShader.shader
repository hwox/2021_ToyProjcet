Shader "Unlit/cartoonShader"
{
	Properties
	{
		_OutlineColor("Outline color", Color) = (0,0,0,1)
		_OutlineWidth("Outline width", Range(0.1, 1.0)) = 0.1 // outline 사이즈
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

			//cull back
			Pass{
				//CGPROGRAM

				//ENDCG
			}
		}
}
