Shader "Custom/ShaderWall" {
    Properties{

        _SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
        [PowerSlider(5.0)] _Shininess("Shininess", Range(0.01, 1)) = 0.078125
        _Parallax("Height", Range(0.005, 0.08)) = 0.02
        _MainTex("Base (RGB) Gloss (A)", 2D) = "white" {}
        _BumpMap("Normalmap", 2D) = "bump" {}
        _ParallaxMap("Heightmap (A)", 2D) = "black" {}
        _MainTex2("Base (RGB) Gloss (A)", 2D) = "white" {}
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 600

        CGPROGRAM
        #pragma surface surf BlinnPhong
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MainTex2;
        sampler2D _BumpMap;
        sampler2D _ParallaxMap;
        fixed4 _Color;
        half _Shininess;
        float _Parallax;

        struct Input {
            float2 uv_MainTex;
            float2 uv_MainTex2;
            float2 uv_BumpMap;
            float3 viewDir;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            half h = tex2D(_ParallaxMap, IN.uv_BumpMap * 5).w;
            float2 offset = ParallaxOffset(h, _Parallax, IN.viewDir);
            IN.uv_MainTex += offset;
            IN.uv_BumpMap += offset;

            fixed4 tex = tex2D(_MainTex, IN.uv_MainTex * 5);
            fixed4 tex2 = tex2D(_MainTex2, IN.uv_MainTex2);
            o.Albedo = lerp(tex.rgb,tex2.rgb, 1.0);
            o.Gloss = tex.a;
            o.Alpha = tex.a;
            o.Specular = _Shininess;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap * 5));
        }
        ENDCG
    }

        FallBack "Legacy Shaders/Bumped Specular"
}