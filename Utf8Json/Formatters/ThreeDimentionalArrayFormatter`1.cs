﻿// Decompiled with JetBrains decompiler
// Type: Utf8Json.Formatters.ThreeDimentionalArrayFormatter`1
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
  public sealed class ThreeDimentionalArrayFormatter<T> : IJsonFormatter<T[,,]>, IJsonFormatter
  {
    public void Serialize(
      ref JsonWriter writer,
      T[,,] value,
      IJsonFormatterResolver formatterResolver)
    {
      if (value == null)
      {
        writer.WriteNull();
      }
      else
      {
        IJsonFormatter<T> formatterWithVerify = formatterResolver.GetFormatterWithVerify<T>();
        int length1 = value.GetLength(0);
        int length2 = value.GetLength(1);
        int length3 = value.GetLength(2);
        writer.WriteBeginArray();
        for (int index1 = 0; index1 < length1; ++index1)
        {
          if (index1 != 0)
            writer.WriteValueSeparator();
          writer.WriteBeginArray();
          for (int index2 = 0; index2 < length2; ++index2)
          {
            if (index2 != 0)
              writer.WriteValueSeparator();
            writer.WriteBeginArray();
            for (int index3 = 0; index3 < length3; ++index3)
            {
              if (index3 != 0)
                writer.WriteValueSeparator();
              formatterWithVerify.Serialize(ref writer, value[index1, index2, index3], formatterResolver);
            }
            writer.WriteEndArray();
          }
          writer.WriteEndArray();
        }
        writer.WriteEndArray();
      }
    }

    public T[,,] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
    {
      if (reader.ReadIsNull())
        return (T[,,]) null;
      ArrayBuffer<ArrayBuffer<ArrayBuffer<T>>> arrayBuffer1 = new ArrayBuffer<ArrayBuffer<ArrayBuffer<T>>>(4);
      IJsonFormatter<T> formatterWithVerify = formatterResolver.GetFormatterWithVerify<T>();
      int length1 = 0;
      int length2 = 0;
      int count1 = 0;
      reader.ReadIsBeginArrayWithVerify();
      while (!reader.ReadIsEndArrayWithSkipValueSeparator(ref count1))
      {
        ArrayBuffer<ArrayBuffer<T>> arrayBuffer2 = new ArrayBuffer<ArrayBuffer<T>>(length2 == 0 ? 4 : length2);
        int count2 = 0;
        reader.ReadIsBeginArrayWithVerify();
        while (!reader.ReadIsEndArrayWithSkipValueSeparator(ref count2))
        {
          ArrayBuffer<T> arrayBuffer3 = new ArrayBuffer<T>(length1 == 0 ? 4 : length1);
          int count3 = 0;
          reader.ReadIsBeginArrayWithVerify();
          while (!reader.ReadIsEndArrayWithSkipValueSeparator(ref count3))
            arrayBuffer3.Add(formatterWithVerify.Deserialize(ref reader, formatterResolver));
          length1 = arrayBuffer3.Size;
          arrayBuffer2.Add(arrayBuffer3);
        }
        length2 = arrayBuffer2.Size;
        arrayBuffer1.Add(arrayBuffer2);
      }
      T[,,] objArray = new T[arrayBuffer1.Size, length2, length1];
      for (int index1 = 0; index1 < arrayBuffer1.Size; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
        {
          for (int index3 = 0; index3 < length1; ++index3)
            objArray[index1, index2, index3] = arrayBuffer1.Buffer[index1].Buffer[index2].Buffer[index3];
        }
      }
      return objArray;
    }
  }
}