/*Shader "Outlined Diffuse" 
{ 
	Properties 
	{ 
		//      _Color ("Main Color", Color) = (.5,.5,.5,1) 
		_OutlineColor ("Outline Color", Color) = (0,1,0,1) 
			_Outline ("Outline width", Range (0.002, 0.03)) = 0.01 
				//      _MainTex ("Base (RGBA)", 2D) = "white" { } 
				//Not needed 
				//_ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" { Texgen CubeNormal } 
	} 
	
	SubShader 
	{ 
		Tags {"Queue"="Transparent" "RenderType"="Transparent"} 
		
		//Minor switch 
		//UsePass "Toon/Basic/BASE" 
		
		//      CGPROGRAM
		//        #pragma surface surf Lambert
		// 
		//        sampler2D _MainTex;
		//        float4 _Color;
		// 
		//        struct Input {
		//            float2 uv_MainTex;
		//        };
		// 
		//        void surf (Input IN, inout SurfaceOutput o) {
		//            half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		//            o.Albedo = c.rgb;
		//            o.Alpha = c.a;
		//        }
		//        ENDCG
		
		Pass 
		{ 
			Name "OUTLINE" 
			Tags { "LightMode" = "Always" } 
			
			Blend SrcAlpha OneMinusSrcAlpha
				
				CGPROGRAM 
					// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct appdata members vertex,normal)
					#pragma exclude_renderers d3d11 xbox360
					#pragma exclude_renderers gles
					#pragma exclude_renderers xbox360
					#pragma vertex vert 
					
			struct appdata { 
				float4 vertex; 
				float3 normal; 
			}; 
			
			struct v2f { 
				float4 pos : POSITION; 
				float4 color : COLOR; 
				float fog : FOGC; 
			}; 
			uniform float _Outline; 
			uniform float4 _OutlineColor; 
			
			v2f vert(appdata v) { 
				v2f o; 
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex); 
				float3 norm = mul ((float3x3)UNITY_MATRIX_MV, v.normal); 
				norm.x *= UNITY_MATRIX_P[0][0]; 
				norm.y *= UNITY_MATRIX_P[1][1]; 
				o.pos.xy += norm.xy * o.pos.z * _Outline; 
				
				o.fog = o.pos.z; 
				o.color = _OutlineColor; 
				return o; 
			} 
			
			ENDCG 
				
				Cull Front
					ZWrite On
					ColorMask RGBA
					Blend SrcAlpha OneMinusSrcAlpha
					//? -Note: I don't remember why I put a "?" here 
SetTexture [_MainTex] { combine primary } 
		} 
	} 
	
	Fallback "Diffuse" 
}
*/