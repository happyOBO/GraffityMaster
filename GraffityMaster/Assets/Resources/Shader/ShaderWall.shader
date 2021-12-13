Shader "Custom/ShaderWall" {
    Properties{

        _SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
        [PowerSlider(5.0)] _Shininess("Shininess", Range(0.01, 1)) = 0.078125
        _Parallax("Height", Range(0.005, 0.08)) = 0.02
        _MainTex("Base (RGB) Gloss (A)", 2D) = "white" {}
        _BumpMap("Normalmap", 2D) = "bump" {}
        _MaskTex("Mask Texture", 2D) = "black" {}
        _DrawTex("Draw Texture", 2D) = "white" {}
        _ColorTex("Color Texture", 2D) = "black" {}
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 600

        CGPROGRAM
        #pragma surface surf BlinnPhong
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _ParallaxMap;
        sampler2D _MaskTex;
        sampler2D _DrawTex;
        sampler2D _ColorTex;
        half _Shininess;
        float _Parallax;


        struct Input {
            float2 uv_MainTex;
            float2 uv_MaskTex;
            float2 uv_DrawTex;
            float2 uv_ColorTex;
            float2 uv_BumpMap;
            float3 viewDir;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            half h = tex2D(_ParallaxMap, IN.uv_BumpMap * 5).w;
            float2 offset = ParallaxOffset(h, _Parallax, IN.viewDir);
            IN.uv_MainTex += offset;
            IN.uv_BumpMap += offset;

            fixed4 mainTex = tex2D(_MainTex, IN.uv_MainTex * 5);
            fixed4 maskTex = tex2D(_MaskTex, IN.uv_MaskTex);
            fixed4 drawTex = tex2D(_DrawTex, IN.uv_DrawTex);
            fixed4 colorTex = tex2D(_ColorTex, IN.uv_ColorTex);
            
            o.Albedo = lerp(mainTex.rgb, colorTex.rgb, colorTex.r);
            o.Albedo = lerp(o.Albedo, colorTex.rgb, colorTex.g);
            o.Albedo = lerp(o.Albedo, colorTex.rgb, colorTex.b);
            o.Albedo = lerp(o.Albedo, drawTex.rgb, maskTex.a);
            o.Gloss = mainTex.a;
            o.Alpha = mainTex.a;
            o.Specular = _Shininess;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap * 5));
        }
        ENDCG
    }

        FallBack "Legacy Shaders/Bumped Specular"
}