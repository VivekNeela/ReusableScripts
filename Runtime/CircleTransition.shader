Shader "Unlit/CircleTransition"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius("Radius", Range(1.0, -0.1)) = 0  
        _EdgeWidth("Edge Width", Range(0.0, 0.1)) = 0  
    }
    SubShader
    {
        Tags 
        { 
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent" 
        }

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float4 _MainTex_ST;
            float _Radius;
            float _EdgeWidth;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float4 col = tex2D(_MainTex, i.uv);
                
                float2 center = float2(0.5, 0.5);

                // float edgeWidth = 0.1; // Width of the anti-aliased edge

                float distance = length(i.uv - center);
                
                float alpha = smoothstep(_Radius - _EdgeWidth, _Radius + _EdgeWidth, distance);

                clip(alpha);
                
                return float4(1, 1, 1, alpha);
                
                // if(distance < _Radius)   // noob way 
                // {
                //     return float4(0, 0, 0, alpha);
                // }
                // else
                // {
                //     // return float4(i.uv+center, 0, 1);
                //     return col;
                // }

            }
            ENDCG
        }
    }
}
