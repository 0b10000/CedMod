﻿// Decompiled with JetBrains decompiler
// Type: Utf8Json.JsonDeserializeFunc`1
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

namespace Utf8Json
{
  public delegate T JsonDeserializeFunc<T>(ref JsonReader reader, IJsonFormatterResolver resolver);
}