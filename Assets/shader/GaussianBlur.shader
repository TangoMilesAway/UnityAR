// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/GaussianBlur"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _StencilComp("Stencil Comparison", Float) = 8
        _Stencil("Stencil ID", Float) = 0
        _StencilOp("Stencil Operation", Float) = 0
        _StencilWriteMask("Stencil Write Mask", Float) = 255
        _StencilReadMask("Stencil Read Mask", Float) = 255

        _ColorMask("Color Mask", Float) = 15

        _BlurSize("Blur Size", Float) = 2  //调整模糊强度
    }

        CGINCLUDE

#include "UnityCG.cginc"

        sampler2D _MainTex;
        uniform half4 _MainTex_TexelSize;
        uniform float _BlurSize;

        static const half weight[4] = { 0.0205, 0.0855, 0.232, 0.324 };
        static const half4 coordOffset = half4(1.0h, 1.0h, -1.0h, -1.0h);

        struct v2f_blurSGX
        {
            float4 pos:SV_POSITION;
            half2 uv:TEXCOORD0;
            half4 uvoff[3]:TEXCOORD1;
        };

        v2f_blurSGX vert_BlurHorizontal(appdata_img v)
        {
            v2f_blurSGX o;
            o.pos = UnityObjectToClipPos(v.vertex);
            o.uv = v.texcoord.xy;
            half2 offs = _MainTex_TexelSize.xy*half2(1, 0)*_BlurSize;
            o.uvoff[0] = v.texcoord.xyxy + offs.xyxy*coordOffset * 3;
            o.uvoff[1] = v.texcoord.xyxy + offs.xyxy*coordOffset * 2;
            o.uvoff[2] = v.texcoord.xyxy + offs.xyxy*coordOffset;

            return o;
        }

        v2f_blurSGX vert_BlurVertical(appdata_img v)
        {
            v2f_blurSGX o;
            o.pos = UnityObjectToClipPos(v.vertex);
            o.uv = v.texcoord.xy;

            half2 offs = _MainTex_TexelSize.xy*half2(0, 1)*_BlurSize;
            o.uvoff[0] = v.texcoord.xyxy + offs.xyxy*coordOffset * 3;
            o.uvoff[1] = v.texcoord.xyxy + offs.xyxy*coordOffset * 2;
            o.uvoff[2] = v.texcoord.xyxy + offs.xyxy*coordOffset;

            return o;
        }

        fixed4 frag_Blur(v2f_blurSGX i) :SV_Target
        {

            fixed4 c = tex2D(_MainTex,i.uv)*weight[3];
            for (int idx = 0; idx < 3; idx++)
            {
                c += tex2D(_MainTex,i.uvoff[idx].xy)*weight[idx];
                c += tex2D(_MainTex,i.uvoff[idx].zw)*weight[idx];
            }

            return c;
        }

            ENDCG

            SubShader
        {
            // No culling or depth
            Cull Off ZWrite Off
            Stencil
            {
                Ref[_Stencil]
                Comp[_StencilComp]
                Pass[_StencilOp]
                ReadMask[_StencilReadMask]
                WriteMask[_StencilWriteMask]
            }
            Fog{ Mode Off }
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask[_ColorMask]

                Pass
            {
                ZTest Always
                CGPROGRAM
                #pragma vertex vert_BlurHorizontal
                #pragma fragment frag_Blur


                ENDCG
            }

                Pass
            {
                ZTest Always
                CGPROGRAM
                #pragma vertex vert_BlurVertical
                #pragma fragment frag_Blur


                ENDCG
            }
        }
}