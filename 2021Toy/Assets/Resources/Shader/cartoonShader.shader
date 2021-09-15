Shader "Unlit/cartoonShader"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5, 0.5, 0.5, 1)
		_OutlineColor("Outline color", Color) = (0,0,0,1)
		_OutlineWidth("Outline width", Range(1.0,5.0)) = 1.01 // outline 사이즈
	}

		CGINCLUDE
		#include "UnityCG.cginc"

		struct appdata 
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f 
		{
			float4 pos : POSITION;
			float3 normal : NORMAL;
		};

		float _OutlineWidth;
		float4 _OutlineColor;

		v2f vert(appdata v)
		{
			v.vertex.xyz *= _OutlineWidth;

			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex); // 이걸 다시월드 스페이스로 바꿔줌
			return o;
		}

		ENDCG

		SubShader
		{
			Pass{
			// 렌더링 아웃라인

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

				half4 frag(v2f i) : COLOR
				{
				return _OutlineColor;
				}

			ENDCG
			}
			Pass{

			}
		}
}
