Shader "Unlit/MyShader2"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;

        void vert(inout appdata_base v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);

            v.vertex.y += sin(_Time.w + v.vertex.x * 0.5) * v.texcoord.x;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
