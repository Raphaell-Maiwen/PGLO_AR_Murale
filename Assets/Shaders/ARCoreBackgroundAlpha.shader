﻿Shader "Unlit/ARCoreBackgroundAlpha"
{
    Properties
    {
        _dimFactor ("DimFactor", float) = 1
        _MainTex("Texture", 2D) = "white" {}
    }

    // For GLES3
    SubShader
    {
        Tags{ "RenderType"="Transparent" "Queue"="Transparent"}
        ZWrite Off
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
            
        Pass
        {
            GLSLPROGRAM

#pragma only_renderers gles3

#ifdef SHADER_API_GLES3
#extension GL_OES_EGL_image_external_essl3 : require
#endif

            uniform mat4 _UnityDisplayTransform;

#ifdef VERTEX
            varying vec2 textureCoord;

            void main()
            {
#ifdef SHADER_API_GLES3
                float flippedV = 1.0 - gl_MultiTexCoord0.y;
                textureCoord.x = _UnityDisplayTransform[0].x * gl_MultiTexCoord0.x + _UnityDisplayTransform[1].x * flippedV + _UnityDisplayTransform[2].x;
                textureCoord.y = _UnityDisplayTransform[0].y * gl_MultiTexCoord0.x + _UnityDisplayTransform[1].y * flippedV + _UnityDisplayTransform[2].y;
                gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
#endif
            }
#endif

#ifdef FRAGMENT
            varying vec2 textureCoord;
            uniform samplerExternalOES _MainTex;

            uniform float _dimFactor;


            void main()
            {
#ifdef SHADER_API_GLES3
vec4 rgba = vec4(texture(_MainTex, textureCoord).xyz, 1);        
    gl_FragColor =  rgba * vec4(1, 1, 1, _dimFactor);
#endif
            }

#endif
            ENDGLSL
        }
    }

    FallBack Off
}
