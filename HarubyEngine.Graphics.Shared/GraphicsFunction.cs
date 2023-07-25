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

using System.Drawing;
using System.Numerics;

namespace HarubyEngine.Graphics;

public partial class RenderGraphics
{
    public ShaderProgram CreateShaderProgram(byte[] hlsl, string[] glsl, out string? vLog, out string? pLog)
    {
        ShaderProgram shader = default;
        vLog = pLog = null;
        int check = 1;
        CreateShaderProgram(ref check, hlsl, glsl, ref shader, ref vLog, ref pLog);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return shader;
    }

    public Texture2DBuffer CreateTexture2D(byte[] rgba32bpp, int width, out int height)
    {
        height = 0;
        Texture2DBuffer texture2D = default;
        if (rgba32bpp.Length > 0 && width > 0)
        {
            height = rgba32bpp.Length / width / 4;
            int check = 1;
            CreateTexture2D(ref check, rgba32bpp, width, height, ref texture2D);
            if (check is not 0)
            {
                throw new NotImplementedException();
            }
        }
        return texture2D;
    }
    public Texture2DBuffer CreateTexture2D(ushort[] rgba16bpp, int width, out int height)
    {
        height = 0;
        Texture2DBuffer texture2D = default;
        if (rgba16bpp.Length > 0 && width > 0)
        {
            height = rgba16bpp.Length / width;
            int check = 1;
            CreateTexture2D(ref check, rgba16bpp, width, height, ref texture2D);
            if (check is not 0)
            {
                throw new NotImplementedException();
            }
        }
        return texture2D;
    }

    public MeshInputLayout CreateMeshInputLayout(ShaderProgram shader)
    {
        MeshInputLayout layout = default;
        int check = 1;
        CreateMeshInputLayout(ref check, ref shader, ref layout);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return layout;
    }

    public ShaderIntVariable CreateShaderIntVariable(ShaderProgram shader, string name)
    {
        ShaderIntVariable variable = default;
        int check = 1;
        CreateShaderIntVariable(ref check, ref shader, name, ref variable);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }
    public ShaderFloatVariable CreateShaderFloatVariable(ShaderProgram shader, string name)
    {
        ShaderFloatVariable variable = default;
        int check = 1;
        CreateShaderFloatVariable(ref check, ref shader, name, ref variable);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }
    public ShaderFloat2Variable CreateShaderFloat2Variable(ShaderProgram shader, string name)
    {
        ShaderFloat2Variable variable = default;
        int check = 1;
        CreateShaderFloat2Variable(ref check, ref shader, name, ref variable);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }
    public ShaderFloat3Variable CreateShaderFloat3Variable(ShaderProgram shader, string name)
    {
        ShaderFloat3Variable variable = default;
        int check = 1;
        CreateShaderFloat3Variable(ref check, ref shader, name, ref variable);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }
    public ShaderFloat4Variable CreateShaderFloat4Variable(ShaderProgram shader, string name)
    {
        ShaderFloat4Variable variable = default;
        int check = 1;
        CreateShaderFloat4Variable(ref check, ref shader, name, ref variable);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }
    public ShaderMatrix3Variable CreateShaderMatrix3Variable(ShaderProgram shader, string name)
    {
        ShaderMatrix3Variable variable = default;
        int check = 1;
        CreateShaderMatrix3Variable(ref check, ref shader, name, ref variable);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }
    public ShaderTexture2DVariable CreateShaderTexture2DVariable(ShaderProgram shader, string name, int unit)
    {
        ShaderTexture2DVariable variable = default;
        int check = 1;
        CreateShaderTexture2DVariable(ref check, ref shader, name, ref variable, unit);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return variable;
    }

    public MeshVector3Buffer CreateBuffer(IReadOnlyList<Vector3> vertices, BufferMode mode)
    {
        MeshVector3Buffer buffer = default;
        int check = 1;
        CreateBuffer(ref check, vertices, mode, ref buffer);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return buffer;
    }
    public MeshVector4Buffer CreateBuffer(IReadOnlyList<Vector4> vertices, BufferMode mode)
    {
        MeshVector4Buffer buffer = default;
        int check = 1;
        CreateBuffer(ref check, vertices, mode, ref buffer);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return buffer;
    }
    public MeshIndex16Buffer CreateBuffer(IReadOnlyList<ushort> indices, BufferMode mode)
    {
        MeshIndex16Buffer buffer = default;
        int check = 1;
        CreateBuffer(ref check, indices, mode, ref buffer);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return buffer;
    }
    public MeshIndex32Buffer CreateBuffer(IReadOnlyList<uint> indices, BufferMode mode)
    {
        MeshIndex32Buffer buffer = default;
        int check = 1;
        CreateBuffer(ref check, indices, mode, ref buffer);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return buffer;
    }

    public RenderBuffer CreateOffscreenRenderBuffer(int width, int height, RenderBufferFeature feature)
    {
        RenderBuffer buffer = default;
        int check = 1;
        CreateOffscreenRenderBuffer(ref check, width, height, ref buffer, feature);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return buffer;
    }
    public RenderBuffer GetScreenRenderBuffer()
    {
        RenderBuffer buffer = default;
        int check = 1;
        GetScreenRenderBuffer(ref check, ref buffer);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
        return buffer;
    }

    public void SetRenderStates(RenderStatesDescription description)
    {
        SetRenderStates(in description);
    }
    public void SetRenderStates(in RenderStatesDescription description)
    {
        int check = 1;
        SetRenderStates(ref check, in description);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }

    public void ClearColor(float r, float g, float b, float a)
    {
        int check = 1;
        ClearColor(ref check, r, g, b, a);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }
    public void ClearDepth()
    {
        int check = 1;
        ClearDepth(ref check);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }
    public void ClearStencil(StencilValue value)
    {
        ClearStencil((int)value);
    }
    public void ClearStencil(int value)
    {
        int check = 1;
        ClearStencil(ref check, value);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }

    public void Draw16IndexedTriangles(int indexCount, int indexOffset)
    {
        int check = 1;
        Draw16IndexedTriangles(ref check, indexCount, indexOffset);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }
    public void Draw32IndexedTriangles(int indexCount, int indexOffset)
    {
        int check = 1;
        Draw32IndexedTriangles(ref check, indexCount, indexOffset);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }

    public void WriteMatrix(Matrix3x2 m, float[] dest)
    {
        WriteMatrix(in m, dest);
    }
    public void WriteMatrix(in Matrix3x2 m, float[] dest)
    {
        int check = 1;
        WriteMatrix(ref check, in m, dest);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }
    public void WriteMatrix(Matrix4x4 m, float[] dest)
    {
        WriteMatrix(in m, dest);
    }
    public void WriteMatrix(in Matrix4x4 m, float[] dest)
    {
        int check = 1;
        WriteMatrix(ref check, in m, dest);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }

    public void SetScissor(Rectangle rectangle)
    {
        SetScissor(in rectangle);
    }
    public void SetScissor(in Rectangle rectangle)
    {
        int check = 1;
        SetScissor(ref check, in rectangle);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }


    partial void CreateShaderProgram(ref int setMeZero, byte[] hlsl, string[] glsl, ref ShaderProgram shader, ref string? vertexLog, ref string? pixelLog);

    partial void CreateTexture2D(ref int setMeZero, byte[] rgba32bpp, int width, int height, ref Texture2DBuffer texture2D);
    partial void CreateTexture2D(ref int setMeZero, ushort[] rgba16bpp, int width, int height, ref Texture2DBuffer texture2D);

    partial void CreateMeshInputLayout(ref int setMeZero, ref ShaderProgram shader, ref MeshInputLayout layout);

    partial void CreateShaderIntVariable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderIntVariable variable);
    partial void CreateShaderFloatVariable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderFloatVariable variable);
    partial void CreateShaderFloat2Variable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderFloat2Variable variable);
    partial void CreateShaderFloat3Variable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderFloat3Variable variable);
    partial void CreateShaderFloat4Variable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderFloat4Variable variable);
    partial void CreateShaderMatrix3Variable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderMatrix3Variable variable);
    partial void CreateShaderTexture2DVariable(ref int setMeZero, ref ShaderProgram shader, string name, ref ShaderTexture2DVariable variable, int unit);

    partial void CreateBuffer(ref int setMeZero, IReadOnlyList<Vector3> vertices, BufferMode mode, ref MeshVector3Buffer buffer);
    partial void CreateBuffer(ref int setMeZero, IReadOnlyList<Vector4> vertices, BufferMode mode, ref MeshVector4Buffer buffer);
    partial void CreateBuffer(ref int setMeZero, IReadOnlyList<ushort> indices, BufferMode mode, ref MeshIndex16Buffer buffer);
    partial void CreateBuffer(ref int setMeZero, IReadOnlyList<uint> indices, BufferMode mode, ref MeshIndex32Buffer buffer);

    partial void CreateOffscreenRenderBuffer(ref int setMeZero, int width, int height, ref RenderBuffer buffer, RenderBufferFeature feature);
    partial void GetScreenRenderBuffer(ref int setMeZero, ref RenderBuffer buffer);

    partial void SetRenderStates(ref int setMeZero, in RenderStatesDescription description);

    partial void ClearColor(ref int setMeZero, float r, float g, float b, float a);
    partial void ClearDepth(ref int setMeZero);
    partial void ClearStencil(ref int setMeZero, int value);

    partial void Draw16IndexedTriangles(ref int setMeZero, int indexCount, int indexOffset);
    partial void Draw32IndexedTriangles(ref int setMeZero, int indexCount, int indexOffset);

    partial void WriteMatrix(ref int setMeZero, in Matrix3x2 m, float[] dest);
    partial void WriteMatrix(ref int setMeZero, in Matrix4x4 m, float[] dest);

    partial void SetScissor(ref int setMeZero, in Rectangle rectangle);
}
