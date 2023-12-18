Shader "Hidden/Shader/postProcess_Pixellize"
{
    Properties
    {
        // This property is necessary to make the CommandBuffer.Blit bind the source texture to _MainTex
        _MainTex("Main Texture", 2DArray) = "grey" {}
    }

    HLSLINCLUDE

    #pragma target 4.5
    #pragma only_renderers d3d11 playstation xboxone xboxseries vulkan metal switch
    


    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/PostProcessing/Shaders/FXAA.hlsl"
    #include "Packages/com.unity.render-pipelines.high-definition/Runtime/PostProcessing/Shaders/RTUpscale.hlsl"

    struct Attributes
    {
        uint vertexID : SV_VertexID;
        UNITY_VERTEX_INPUT_INSTANCE_ID
    };

    struct Varyings
    {
        float4 positionCS : SV_POSITION;
        float2 texcoord   : TEXCOORD0;
        UNITY_VERTEX_OUTPUT_STEREO
    };

    Varyings Vert(Attributes input)
    {
        Varyings output;
        UNITY_SETUP_INSTANCE_ID(input);
        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
        output.positionCS = GetFullScreenTriangleVertexPosition(input.vertexID);
        output.texcoord = GetFullScreenTriangleTexCoord(input.vertexID);
        return output;
    }

    // List of properties to control your post process effect
    float2 _Resolution;
    float _outlineSize;
    float _outlineStrength;
    float4 fogColor;
    Texture2D _VFXTexture;
    TEXTURE2D_X(_MainTex);



    float4 CustomPostProcess(Varyings input) : SV_Target
    {
        UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

        // Note that if HDUtils.DrawFullScreen is not used to render the post process, you don't need to call ClampAndScaleUVForBilinearPostProcessTexture.


        float2 coord = input.texcoord.xy;
        
        float2 s = 1/_Resolution;
        coord = coord - coord % (s)+s;
        
        float lumix =  abs( SAMPLE_TEXTURE2D_X(_CameraDepthTexture, s_linear_clamp_sampler, ClampAndScaleUVForBilinearPostProcessTexture(coord + float2(s.x,0)*_outlineSize )).x-SAMPLE_TEXTURE2D_X(_CameraDepthTexture, s_linear_clamp_sampler, ClampAndScaleUVForBilinearPostProcessTexture(coord - float2(s.x,0)*_outlineSize )).x);
        float lumiy = abs( SAMPLE_TEXTURE2D_X(_CameraDepthTexture, s_linear_clamp_sampler, ClampAndScaleUVForBilinearPostProcessTexture(coord + float2(0,s.y)*_outlineSize )).x-SAMPLE_TEXTURE2D_X(_CameraDepthTexture, s_linear_clamp_sampler, ClampAndScaleUVForBilinearPostProcessTexture(coord - float2(0,s.y)*_outlineSize )).x); 


        float3 color =  SAMPLE_TEXTURE2D_X(_MainTex, s_linear_clamp_sampler, ClampAndScaleUVForBilinearPostProcessTexture(coord  )) * pow(1-length(float2( lumix,lumiy)),_outlineStrength);
        float a = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, s_linear_clamp_sampler, ClampAndScaleUVForBilinearPostProcessTexture(coord  )).x;
        a*=1000;
        a=min(max(a,0.8),1);
        if(a!=0){
            color = lerp(color,fogColor.xyz,1-a);
        }
        
        
        //color = float3(a,a,a);
        //float3 vfx = SAMPLE_TEXTURE2D_X(_VFXTexture,s_linear_clamp_sampler,ClampAndScaleUVForBilinearPostProcessTexture(input.texcoord.xy));
        
        //color+=vfx;
        //color+=vfx;
        return float4(color, 1);
    }

    ENDHLSL

    SubShader
    {
        Tags{ "RenderPipeline" = "HDRenderPipeline" }
        Pass
        {
            Name "postProcess_Pixellize"

            ZWrite Off
            ZTest Always
            Blend Off
            Cull Off

            HLSLPROGRAM
                #pragma fragment CustomPostProcess
                #pragma vertex Vert
            ENDHLSL
        }
    }
    Fallback Off
}
