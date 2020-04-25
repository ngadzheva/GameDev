Shader "Hidden/Pixelize"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _PixelWidth("Pixel Width", Float) = 5.0
    _PixelHeight("Pixel Height", Float) = 5.0
    _ScreenWidth("Screen Width", float) = 320.0
	  _ScreenHeight("Screen Height", float) = 240.0
  }

  SubShader
  {
    Cull Off ZWrite Off ZTest Always

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

      v2f vert (appdata v)
      {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = v.uv;
        return o;
      }

      sampler2D _MainTex;
      float _PixelWidth;
      float _PixelHeight;
      float _ScreenWidth;
      float _ScreenHeight;

      fixed4 frag (v2f i) : SV_Target
      {
        float onePixelSizeX = _ScreenWidth / _PixelWidth;
        float onePixelSizeY = _ScreenHeight / _PixelHeight;

        float2 uv = i.uv;

        uv.x = (int)(onePixelSizeX * uv.x) / onePixelSizeX;
        uv.y = (int)(onePixelSizeY * uv.y) / onePixelSizeY;

        fixed4 col = tex2D(_MainTex, uv);
        return col;
      }
      ENDCG
    }
  }
}
