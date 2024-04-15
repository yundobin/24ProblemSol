Shader "Custom/CartoonShader"
{
    Properties
    {
        _SurfaceColor("Surface Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float3 worldNormal : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            half4 _SurfaceColor;

            half4 frag(v2f i) : SV_Target
            {
                half shadow = step(0.2, dot(normalize(i.worldNormal), float3(1, 1, 1)));

                half cartoonShadow = ceil(dot(normalize(i.worldNormal), float3(1, 1, 1)) * 5) / 5.0;

                half4 finalColor = _SurfaceColor * (1 - shadow) + (_SurfaceColor * cartoonShadow) * shadow;
                
                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
