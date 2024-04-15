Shader "Unlit/MyShader"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)
        _Tex("Main Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct Vertex
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolants
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _Color;
            sampler2D _Tex;

            Interpolants vert(Vertex v)
            {
                Interpolants o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                // _Time ( time / 20, time, time * 2, time * 3 )
                o.vertex.x += sin(_Time.w + v.vertex.x * 10) * 0.1;
                o.vertex.y += sin(_Time.w + v.vertex.y * 10) * 0.1;
                return o;
            }

            fixed4 frag(Interpolants i) : SV_Target
            {
                fixed4 col = tex2D(_Tex, i.uv);
                return _Color;
            }
            ENDCG
        }
    }
}
