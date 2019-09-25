Shader "shader/3DPrinter/3DPrinter" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_ConstructY("ConstructY", Float) = 1.0
		_ConstructGap("ConstructGap", Float) = 0.5
		_ConstructColor("ConstructColor",Color) = (1,0,0,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Cull Off
		CGPROGRAM
		#pragma surface surf Unlit
		#include "UnityPBSLighting.cginc"
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _ConstructY;
		fixed4 _ConstructColor;
		int building;
		float _ConstructGap;
		

		inline half4 LightingUnlit(SurfaceOutputStandard s, half3 lightDir, UnityGI gi)
		{
			if (building)
			{
				return _ConstructColor; // Unlit
			}
			if (dot(s.Normal, lightDir) < 0)
				return _ConstructColor;

			return LightingStandard(s, lightDir, gi); // Unity5 PBR
		}

		inline void LightingUnlit_GI(SurfaceOutputStandard s, UnityGIInput data, inout UnityGI gi)
		{
			LightingStandard_GI(s, data, gi);
		}
		

		void surf (Input IN, inout SurfaceOutputStandard o) {
			//点的世界坐标高度在裁剪高度下，正常渲染
			if (IN.worldPos.y < _ConstructY)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Alpha = c.a;
				building = 0;
			}
			else
			{
				//点的世界坐标高度在裁剪高度下，正常渲染
				float s = +sin((IN.worldPos.x * IN.worldPos.z) * 240 + _Time[3] + o.Normal) / 120;
				o.Albedo = _ConstructColor.rgb;
				o.Alpha = _ConstructColor.a;
				building = 1;
				//扫光之上的像素，擦除掉
				if (IN.worldPos.y > _ConstructY + _ConstructGap + s)
				{
					discard;
				}
			}
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
