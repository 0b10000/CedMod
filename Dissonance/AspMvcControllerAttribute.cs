﻿// Decompiled with JetBrains decompiler
// Type: Dissonance.AspMvcControllerAttribute
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using System;

namespace Dissonance
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
  internal sealed class AspMvcControllerAttribute : Attribute
  {
    public AspMvcControllerAttribute()
    {
    }

    public AspMvcControllerAttribute([NotNull] string anonymousProperty)
    {
      this.AnonymousProperty = anonymousProperty;
    }

    [CanBeNull]
    public string AnonymousProperty { get; private set; }
  }
}