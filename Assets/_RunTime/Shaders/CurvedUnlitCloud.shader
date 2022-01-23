﻿Shader "Unlit/CurvedUnlitCloud"
{ 
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BrightnessMultiplier("Brightness Multiplier", float) = 1
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(.002, 0.03)) = .002
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue" = "Geometry-1"}
		ZWrite Off
		LOD 100

		UsePass "Unlit/CurvedOutlineCloud/OUTLINE"
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work 
			#pragma multi_compile_fog
				
			#include "CurvedCode.cginc"

			ENDCG
		}
	}
}
