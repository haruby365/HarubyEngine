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

using System.Diagnostics;
using System.Numerics;

namespace HarubyEngine;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class WorldObject
{
    public string DisplayName { get; set; } = string.Empty;

    public World? World { get; internal set; }

    public WorldObject? Parent { get; private set; }

    readonly List<Component> components = new();
    public IReadOnlyList<Component> Components => components;

    Transform3 localTransform = Transform3.Identity;
    public Transform3 LocalTransform => localTransform;

    Transform3 worldTransform = Transform3.Identity;
    public Transform3 WorldTransform => worldTransform;

    public Matrix4x4 WorldMatrix { get; private set; } = Matrix4x4.Identity;

    #region Update Transform
    void UpdateLocalTransform()
    {
        localTransform = Parent is not null ?
            Transform3.CreateRelativeTransform(in worldTransform, in Parent.worldTransform) : worldTransform;
        UpdateWorldMatrix();
    }
    public void UpdateWorldTransform()
    {
        worldTransform = Parent is not null ?
            Transform3.Multiply(in localTransform, in Parent.worldTransform) : localTransform;
        UpdateWorldMatrix();
    }
    void UpdateWorldMatrix()
    {
        WorldMatrix = Transform3.CreateMatrix(in worldTransform);
    }
    #endregion

    #region Set Transform
    public void SetWorldTransform(Transform3 value)
    {
        if (worldTransform == value)
        {
            return;
        }
        worldTransform = value;
        UpdateLocalTransform();
    }
    public void SetWorldLocation(Vector3 value)
    {
        if (worldTransform.Location == value)
        {
            return;
        }
        worldTransform.Location = value;
        UpdateLocalTransform();
    }
    public void SetWorldRotation(Quaternion value)
    {
        if (worldTransform.Rotation == value)
        {
            return;
        }
        worldTransform.Rotation = value;
        UpdateLocalTransform();
    }
    public void SetWorldScale3D(Vector3 value)
    {
        if (localTransform.Scale3D == value)
        {
            return;
        }
        worldTransform.Scale3D = value;
        UpdateLocalTransform();
    }

    public void SetLocalTransform(Transform3 value)
    {
        if (localTransform == value)
        {
            return;
        }
        localTransform = value;
        UpdateWorldTransform();
    }
    public void SetLocalLocation(Vector3 value)
    {
        if (localTransform.Location == value)
        {
            return;
        }
        localTransform.Location = value;
        UpdateWorldTransform();
    }
    public void SetLocalRotation(Quaternion value)
    {
        if (localTransform.Rotation == value)
        {
            return;
        }
        localTransform.Rotation = value;
        UpdateWorldTransform();
    }
    public void SetLocalScale3D(Vector3 value)
    {
        if (localTransform.Scale3D == value)
        {
            return;
        }
        localTransform.Scale3D = value;
        UpdateWorldTransform();
    }
    #endregion

    #region Components
    public void AddComponent(Component component)
    {
        if (component.Actor == this)
        {
            return;
        }
        if (component.Actor is not null)
        {
            throw new InvalidOperationException("Component is already added.");
        }
        components.Add(component);
        component.Actor = this;
    }

    public void RemoveComponent(Component component)
    {
        if (component.Actor != this)
        {
            return;
        }
        if (!components.Remove(component))
        {
            // Will never hit.
            throw new InvalidOperationException("Failed to remove component from actor's component list.");
        }
        component.Actor = null;
    }

    public void RemoveAllComponents()
    {
        foreach (var component in components)
        {
            component.Actor = null;
        }
        components.Clear();
    }
    #endregion

    private string DebuggerDisplay => $"Name={DisplayName}, Type={GetType().Name}";
}
