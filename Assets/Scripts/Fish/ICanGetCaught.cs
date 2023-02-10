using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public interface ICanGetCaught
    {
        Sprite SpriteObj { get; }
        Transform ObjTransform { get; }
        bool IsGetCaught { get; }
        void GetCaught();         
    }
}
