﻿// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_FX_Hypno
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hypno")]
public class CameraFilterPack_FX_Hypno : MonoBehaviour
{
  private float TimeX = 1f;
  [Range(0.0f, 1f)]
  public float Speed = 1f;
  [Range(-2f, 2f)]
  public float Green = 1f;
  [Range(-2f, 2f)]
  public float Blue = 1f;
  public Shader SCShader;
  private Material SCMaterial;
  [Range(-2f, 2f)]
  public float Red;

  private Material material
  {
    get
    {
      if ((Object) this.SCMaterial == (Object) null)
      {
        this.SCMaterial = new Material(this.SCShader);
        this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
      }
      return this.SCMaterial;
    }
  }

  private void Start()
  {
    this.SCShader = Shader.Find("CameraFilterPack/FX_Hypno");
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.TimeX += Time.deltaTime;
      if ((double) this.TimeX > 100.0)
        this.TimeX = 0.0f;
      this.material.SetFloat("_TimeX", this.TimeX);
      this.material.SetFloat("_Value", this.Speed);
      this.material.SetFloat("_Value2", this.Red);
      this.material.SetFloat("_Value3", this.Green);
      this.material.SetFloat("_Value4", this.Blue);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void Update()
  {
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.SCMaterial)
      return;
    Object.DestroyImmediate((Object) this.SCMaterial);
  }
}