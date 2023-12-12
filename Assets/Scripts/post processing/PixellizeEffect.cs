using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System;

[Serializable, VolumeComponentMenu("Post-processing/Custom/PixellizeEffect")]
public sealed class PixellizeEffect : CustomPostProcessVolumeComponent, IPostProcessComponent
{

    public Vector2Parameter Resolution = new Vector2Parameter(new Vector2(320, 180));
    public FloatParameter outlineSize = new FloatParameter(1f); 
    public FloatParameter outlineStrength = new FloatParameter(1f);
    Material m_Material;

    public bool IsActive() => m_Material != null;

    // Do not forget to add this post process in the Custom Post Process Orders list (Project Settings > Graphics > HDRP Global Settings).
    public override CustomPostProcessInjectionPoint injectionPoint => CustomPostProcessInjectionPoint.BeforePostProcess;

    const string kShaderName = "Hidden/Shader/postProcess_Pixellize";

    public override void Setup()
    {
        if (Shader.Find(kShaderName) != null)
            m_Material = new Material(Shader.Find(kShaderName));
        else
            Debug.LogError($"Unable to find shader '{kShaderName}'. Post Process Volume PixellizeEffect is unable to load.");
    }

    public override void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination)
    {
        if (m_Material == null)
            return;


        m_Material.SetVector("_Resolution",Resolution.value);
        m_Material.SetTexture("_MainTex", source);
        m_Material.SetFloat("_outlineSize", outlineSize.value); 
            m_Material.SetFloat("_outlineStrength", outlineStrength.value);
        HDUtils.DrawFullScreen(cmd, m_Material, destination, shaderPassId: 0);
    }

    public override void Cleanup()
    {
        CoreUtils.Destroy(m_Material);
    }
}
