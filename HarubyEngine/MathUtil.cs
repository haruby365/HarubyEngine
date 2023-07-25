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

namespace HarubyEngine;

public static class MathUtil
{
    public static float SafeInverse(this float value)
    {
        return value is 0f ? 0f : 1f / value;
    }
    public static double SafeInverse(this double value)
    {
        return value is 0d ? 0d : 1d / value;
    }
    public static decimal SafeInverse(this decimal value)
    {
        return value is 0m ? 0m : 1m / value;
    }
    public static int SafeInverse(this int value)
    {
        return value is 0 ? 0 : 1 / value;
    }
    public static uint SafeInverse(this uint value)
    {
        return value is 0u ? 0u : 1u / value;
    }
    public static long SafeInverse(this long value)
    {
        return value is 0L ? 0L : 1L / value;
    }
    public static ulong SafeInverse(this ulong value)
    {
        return value is 0ul ? 0ul : 1ul / value;
    }

    public static Vector2 SafeInverse(this Vector2 value)
    {
        return new Vector2(value.X.SafeInverse(), value.Y.SafeInverse());
    }
    public static Vector3 SafeInverse(this Vector3 value)
    {
        return new Vector3(value.X.SafeInverse(), value.Y.SafeInverse(), value.Z.SafeInverse());
    }
    public static Vector4 SafeInverse(this Vector4 value)
    {
        return new Vector4(value.X.SafeInverse(), value.Y.SafeInverse(), value.Z.SafeInverse(), value.W.SafeInverse());
    }

    public static Matrix3x2 SafeInverse(this Matrix3x2 value)
    {
        if (Matrix3x2.Invert(value, out Matrix3x2 result))
        {
            return result;
        }
        return Matrix3x2.Identity;
    }
    public static Matrix4x4 SafeInverse(this Matrix4x4 value)
    {
        if (Matrix4x4.Invert(value, out Matrix4x4 result))
        {
            return result;
        }
        return Matrix4x4.Identity;
    }

    public static Matrix3x2 StrictInverse(this Matrix3x2 value)
    {
        if (Matrix3x2.Invert(value, out Matrix3x2 result))
        {
            return result;
        }
        throw new InvalidOperationException("Failed to invert Matrix3x2.");
    }
    public static Matrix4x4 StrictInverse(this Matrix4x4 value)
    {
        if (Matrix4x4.Invert(value, out Matrix4x4 result))
        {
            return result;
        }
        throw new InvalidOperationException("Failed to invert Matrix4x4.");
    }

    public static void Min(ref int left, int right)
    {
        left = Math.Min(left, right);
    }
    public static void Min(ref long left, long right)
    {
        left = Math.Min(left, right);
    }
    public static void Min(ref float left, float right)
    {
        left = Math.Min(left, right);
    }
    public static void Min(ref double left, double right)
    {
        left = Math.Min(left, right);
    }
    public static void Min(ref decimal left, decimal right)
    {
        left = Math.Min(left, right);
    }

    public static void Max(ref int left, int right)
    {
        left = Math.Max(left, right);
    }
    public static void Max(ref long left, long right)
    {
        left = Math.Max(left, right);
    }
    public static void Max(ref float left, float right)
    {
        left = Math.Max(left, right);
    }
    public static void Max(ref double left, double right)
    {
        left = Math.Max(left, right);
    }
    public static void Max(ref decimal left, decimal right)
    {
        left = Math.Max(left, right);
    }

    public static int Min(int v0, int v1, int v2)
    {
        return Math.Min(v0, Math.Min(v1, v2));
    }
    public static long Min(long v0, long v1, long v2)
    {
        return Math.Min(v0, Math.Min(v1, v2));
    }
    public static float Min(float v0, float v1, float v2)
    {
        return Math.Min(v0, Math.Min(v1, v2));
    }
    public static double Min(double v0, double v1, double v2)
    {
        return Math.Min(v0, Math.Min(v1, v2));
    }
    public static decimal Min(decimal v0, decimal v1, decimal v2)
    {
        return Math.Min(v0, Math.Min(v1, v2));
    }

    public static int Max(int v0, int v1, int v2)
    {
        return Math.Max(v0, Math.Max(v1, v2));
    }
    public static long Max(long v0, long v1, long v2)
    {
        return Math.Max(v0, Math.Max(v1, v2));
    }
    public static float Max(float v0, float v1, float v2)
    {
        return Math.Max(v0, Math.Max(v1, v2));
    }
    public static double Max(double v0, double v1, double v2)
    {
        return Math.Max(v0, Math.Max(v1, v2));
    }
    public static decimal Max(decimal v0, decimal v1, decimal v2)
    {
        return Math.Max(v0, Math.Max(v1, v2));
    }

    public static float Lerp(float p1, float p2, float alpha)
    {
        return p1 + (p2 - p1) * alpha;
    }
    public static double Lerp(double p1, double p2, double alpha)
    {
        return p1 + (p2 - p1) * alpha;
    }
    public static decimal Lerp(decimal p1, decimal p2, decimal alpha)
    {
        return p1 + (p2 - p1) * alpha;
    }

    public static int SafeDivide(this int left, int right)
    {
        return right is 0 ? 0 : left / right;
    }
    public static uint SafeDivide(this uint left, uint right)
    {
        return right is 0u ? 0u : left / right;
    }
    public static long SafeDivide(this long left, long right)
    {
        return right is 0L ? 0L : left / right;
    }
    public static ulong SafeDivide(this ulong left, ulong right)
    {
        return right is 0ul ? 0ul : left / right;
    }
    public static float SafeDivide(this float left, float right)
    {
        return right is 0f ? 0f : left / right;
    }
    public static double SafeDivide(this double left, double right)
    {
        return right is 0d ? 0d : left / right;
    }
    public static decimal SafeDivide(this decimal left, decimal right)
    {
        return right is 0m ? 0m : left / right;
    }

    public static float ToRadians(this float d)
    {
        return d / 180f * MathF.PI;
    }
    public static float ToDegrees(this float r)
    {
        return r * 180f / MathF.PI;
    }

    public static double ToRadians(this double d)
    {
        return d / 180d * Math.PI;
    }
    public static double ToDegrees(this double r)
    {
        return r * 180d / Math.PI;
    }

    public static bool IsNearlyEqual(this float left, float right, float tolerance = 0.0001f)
    {
        return Math.Abs(left - right) <= Math.Abs(tolerance);
    }
    public static bool IsNearlyEqual(this double left, double right, double tolerance = 0.0001d)
    {
        return Math.Abs(left - right) <= Math.Abs(tolerance);
    }
    public static bool IsNearlyEqual(this decimal left, decimal right, decimal tolerance = 0.0001m)
    {
        return Math.Abs(left - right) <= Math.Abs(tolerance);
    }

    public static bool IsNearlyEqual(this Vector2 left, Vector2 right, float tolerance = 0.0001f)
    {
        return left.X.IsNearlyEqual(right.X, tolerance) &&
            left.Y.IsNearlyEqual(right.Y, tolerance);
    }
    public static bool IsNearlyEqual(this Vector3 left, Vector3 right, float tolerance = 0.0001f)
    {
        return left.X.IsNearlyEqual(right.X, tolerance) &&
            left.Y.IsNearlyEqual(right.Y, tolerance) &&
            left.Z.IsNearlyEqual(right.Z, tolerance);
    }
    public static bool IsNearlyEqual(this Vector4 left, Vector4 right, float tolerance = 0.0001f)
    {
        return left.X.IsNearlyEqual(right.X, tolerance) &&
            left.Y.IsNearlyEqual(right.Y, tolerance) &&
            left.Z.IsNearlyEqual(right.Z, tolerance) &&
            left.W.IsNearlyEqual(right.W, tolerance);
    }

    public static bool IsNearlyZero(this float left, float tolerance = 0.0001f)
    {
        return IsNearlyEqual(left, 0f, tolerance);
    }
    public static bool IsNearlyZero(this double left, double tolerance = 0.0001d)
    {
        return IsNearlyEqual(left, 0.0, tolerance);
    }
    public static bool IsNearlyZero(this decimal left, decimal tolerance = 0.0001m)
    {
        return IsNearlyEqual(left, 0m, tolerance);
    }

    public static bool IsNearlyZero(this Vector2 left, float tolerance = 0.0001f)
    {
        return left.X.IsNearlyZero(tolerance) &&
            left.Y.IsNearlyZero(tolerance);
    }
    public static bool IsNearlyZero(this Vector3 left, float tolerance = 0.0001f)
    {
        return left.X.IsNearlyZero(tolerance) &&
            left.Y.IsNearlyZero(tolerance) &&
            left.Z.IsNearlyZero(tolerance);
    }
    public static bool IsNearlyZero(this Vector4 left, float tolerance = 0.0001f)
    {
        return left.X.IsNearlyZero(tolerance) &&
            left.Y.IsNearlyZero(tolerance) &&
            left.Z.IsNearlyZero(tolerance) &&
            left.W.IsNearlyZero(tolerance);
    }
}
