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
    public ColorParameter fogColor = new ColorParameter(Color.white);
    //[SerializeField]
    //public RenderTexture _VFXTexture;
    Material m_Material;
    public bool IsActive() => m_Material != null && Resolution != new Vector2(0, 0);
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
        m_Material.SetColor("fogColor", fogColor.value);
        m_Material.SetFloat("_outlineSize", outlineSize.value); 
        m_Material.SetFloat("_outlineStrength", outlineStrength.value);
       // m_Material.SetTexture("_VFXTexture", GameObject.Find("vfxCam").gameObject.GetComponent<Camera>().targetTexture);
        HDUtils.DrawFullScreen(cmd, m_Material, destination, shaderPassId: 0);

    }

    public override void Cleanup()
    {
        CoreUtils.Destroy(m_Material);
    }
}
