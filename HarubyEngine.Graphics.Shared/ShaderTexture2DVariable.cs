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

namespace HarubyEngine.Graphics;

public partial struct ShaderTexture2DVariable
{
    public bool IsValid
    {
        get
        {
            int check = 1;
            bool v = false;
            GetIsValid(ref check, ref v);
            if (check is not 0)
            {
                throw new NotImplementedException();
            }
            return v;
        }
    }
    public void Set(Texture2DBuffer texture, AddressingMode uMode, AddressingMode vMode, FilterMode filter)
    {
        Set(in texture, uMode, vMode, filter);
    }
    public void Set(in Texture2DBuffer texture, AddressingMode uMode, AddressingMode vMode, FilterMode filter)
    {
        int check = 1;
        Set(ref check, in texture, uMode, vMode, filter);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }
    public void Destroy()
    {
        int check = 1;
        Destroy(ref check);
        if (check is not 0)
        {
            throw new NotImplementedException();
        }
    }

    partial void GetIsValid(ref int setMeZero, ref bool valid);
    partial void Set(ref int setMeZero, in Texture2DBuffer texture, AddressingMode uMode, AddressingMode vMode, FilterMode filter);
    partial void Destroy(ref int setMeZero);
}
