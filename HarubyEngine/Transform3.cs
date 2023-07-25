// Copyright (c) 2023 Jong-il Hong
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Numerics;
using System.Runtime.InteropServices;

namespace HarubyEngine;

[StructLayout(LayoutKind.Sequential, Pack = sizeof(float))]
public record struct Transform3
{
    public static Transform3 Identity => new()
    {
        Rotation = Quaternion.Identity,
        Scale3D = Vector3.One,
        Location = Vector3.Zero,
    };

    public static Matrix4x4 CreateMatrix(Transform3 t)
    {
        return CreateMatrix(in t);
    }
    public static Matrix4x4 CreateMatrix(in Transform3 t)
    {
        return Matrix4x4.Multiply(Matrix4x4.Multiply(Matrix4x4.CreateScale(t.Scale3D), Matrix4x4.CreateFromQuaternion(t.Rotation)), Matrix4x4.CreateTranslation(t.Location));
    }

    public static Matrix4x4 CreateMatrixNormal(Transform3 t)
    {
        return CreateMatrixNormal(in t);
    }
    public static Matrix4x4 CreateMatrixNormal(in Transform3 t)
    {
        return Matrix4x4.Multiply(Matrix4x4.CreateScale(t.Scale3D), Matrix4x4.CreateFromQuaternion(t.Rotation));
    }

    public static Transform3 Multiply(Transform3 a, Transform3 b)
    {
        return Multiply(in a, in b);
    }
    public static Transform3 Multiply(in Transform3 a, in Transform3 b)
    {
        return new Transform3()
        {
            Rotation = b.Rotation * a.Rotation,
            Scale3D = a.Scale3D * b.Scale3D,
            Location = Vector3.Transform(b.Scale3D * a.Location, b.Rotation) + b.Location
        };
    }

    public static Transform3 MultiplyAll(params Transform3[] ts)
    {
        if (ts.Length is 0)
        {
            return Identity;
        }

        Transform3 m = ts[0];
        for (int i = 1; i < ts.Length; i++)
        {
            m = Multiply(m, ts[i]);
        }
        return m;
    }

    public static Transform3 Invert(Transform3 t)
    {
        return Invert(in t);
    }
    public static Transform3 Invert(in Transform3 t)
    {
        Quaternion invRotation = Quaternion.Inverse(t.Rotation);
        Vector3 invScale3D = t.Scale3D.SafeInverse();
        Vector3 invTranslation = Vector3.Transform(invScale3D * Vector3.Negate(t.Location), invRotation);
        return new Transform3
        {
            Rotation = invRotation,
            Scale3D = invScale3D,
            Location = invTranslation
        };
    }

    public static Transform3 CreateRelativeTransform(Transform3 t, Transform3 parent)
    {
        return CreateRelativeTransform(in t, in parent);
    }
    public static Transform3 CreateRelativeTransform(in Transform3 t, in Transform3 parent)
    {
        Vector3 invScale3D = parent.Scale3D.SafeInverse();
        Quaternion invRotation = Quaternion.Inverse(parent.Rotation);
        return new Transform3
        {
            Scale3D = t.Scale3D * invScale3D,
            Location = Vector3.Transform(t.Location - parent.Location, invRotation) * invScale3D,
            Rotation = invRotation * t.Rotation
        };
    }

    public static Vector3 Transform(Transform3 t, Vector3 v)
    {
        return Transform(in t, v);
    }
    public static Vector3 Transform(in Transform3 t, Vector3 v)
    {
        return Vector3.Transform(v, CreateMatrix(in t));
    }

    public static Vector3 InverseTransform(Transform3 t, Vector3 v)
    {
        return InverseTransform(in t, v);
    }
    public static Vector3 InverseTransform(in Transform3 t, Vector3 v)
    {
        return Vector3.Transform(v, CreateMatrix(in t).SafeInverse());
    }

    public static Vector3 TransformNormal(Transform3 t, Vector3 v)
    {
        return TransformNormal(in t, v);
    }
    public static Vector3 TransformNormal(in Transform3 t, Vector3 v)
    {
        return Vector3.TransformNormal(v, CreateMatrixNormal(in t));
    }

    public static Vector3 InverseTransformNormal(Transform3 t, Vector3 v)
    {
        return InverseTransformNormal(in t, v);
    }
    public static Vector3 InverseTransformNormal(in Transform3 t, Vector3 v)
    {
        return Vector3.TransformNormal(v, CreateMatrixNormal(in t).SafeInverse());
    }

    public static Vector4 Transform(Transform3 t, Vector4 v)
    {
        return Transform(in t, v);
    }
    public static Vector4 Transform(in Transform3 t, Vector4 v)
    {
        return Vector4.Transform(v, CreateMatrix(in t));
    }

    public static Vector4 InverseTransform(Transform3 t, Vector4 v)
    {
        return InverseTransform(in t, v);
    }
    public static Vector4 InverseTransform(in Transform3 t, Vector4 v)
    {
        return Vector4.Transform(v, CreateMatrix(in t).SafeInverse());
    }

    public Vector3 Location;
    public Quaternion Rotation;
    public Vector3 Scale3D;

    public Transform3(Quaternion rotation, Vector3 scale)
        : this(Vector3.Zero, rotation, scale)
    {
    }
    public Transform3(Vector3 translation, Quaternion rotation)
        : this(translation, rotation, Vector3.One)
    {
    }
    public Transform3(Vector3 translation, Quaternion rotation, Vector3 scale3D)
    {
        Location = translation; Rotation = rotation; Scale3D = scale3D;
    }
}
