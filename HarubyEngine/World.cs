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

namespace HarubyEngine;

public class World
{
    readonly List<WorldObject> objects = new();
    public IReadOnlyList<WorldObject> Objects => objects;

    #region Objects
    public void AddObject(WorldObject obj)
    {
        if (obj.World == this)
        {
            return;
        }
        if (obj.World is not null)
        {
            throw new InvalidOperationException("Object is already added.");
        }
        objects.Add(obj);
        obj.World = this;
    }

    public void RemoveObject(WorldObject obj)
    {
        if (obj.World != this)
        {
            return;
        }
        if (!objects.Remove(obj))
        {
            // Will never hit.
            throw new InvalidOperationException("Failed to remove object from world's object list.");
        }
        obj.World = null;
    }

    public void RemoveAllObjects()
    {
        foreach (var obj in objects)
        {
            obj.World = null;
        }
        objects.Clear();
    }
    #endregion
}