﻿// Decompiled with JetBrains decompiler
// Type: ExampleWheelController
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ExampleWheelController : MonoBehaviour
{
  public float acceleration;
  private Rigidbody m_Rigidbody;
  public Renderer motionVectorRenderer;

  private void Start()
  {
    this.m_Rigidbody = this.GetComponent<Rigidbody>();
    this.m_Rigidbody.maxAngularVelocity = 100f;
  }

  private void Update()
  {
    if (Input.GetKey(KeyCode.UpArrow))
      this.m_Rigidbody.AddRelativeTorque(new Vector3(-1f * this.acceleration, 0.0f, 0.0f), ForceMode.Acceleration);
    else if (Input.GetKey(KeyCode.DownArrow))
      this.m_Rigidbody.AddRelativeTorque(new Vector3(1f * this.acceleration, 0.0f, 0.0f), ForceMode.Acceleration);
    float num = (float) (-(double) this.m_Rigidbody.angularVelocity.x / 100.0);
    if (!(bool) (Object) this.motionVectorRenderer)
      return;
    this.motionVectorRenderer.material.SetFloat(ExampleWheelController.Uniforms._MotionAmount, Mathf.Clamp(num, -0.25f, 0.25f));
  }

  private static class Uniforms
  {
    internal static readonly int _MotionAmount = Shader.PropertyToID(nameof (_MotionAmount));
  }
}