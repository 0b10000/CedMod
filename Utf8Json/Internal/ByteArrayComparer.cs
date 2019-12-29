﻿// Decompiled with JetBrains decompiler
// Type: Utf8Json.Internal.ByteArrayComparer
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

namespace Utf8Json.Internal
{
  public static class ByteArrayComparer
  {
    public static bool Equals(byte[] xs, int xsOffset, int xsCount, byte[] ys)
    {
      if (xs == null || ys == null || xsCount != ys.Length)
        return false;
      for (int index = 0; index < ys.Length; ++index)
      {
        if ((int) xs[xsOffset++] != (int) ys[index])
          return false;
      }
      return true;
    }

    public static bool Equals(
      byte[] xs,
      int xsOffset,
      int xsCount,
      byte[] ys,
      int ysOffset,
      int ysCount)
    {
      if (xs == null || ys == null || xsCount != ysCount)
        return false;
      for (int index = 0; index < xsCount; ++index)
      {
        if ((int) xs[xsOffset++] != (int) ys[ysOffset++])
          return false;
      }
      return true;
    }
  }
}