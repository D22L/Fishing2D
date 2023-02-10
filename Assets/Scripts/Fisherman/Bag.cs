using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing2D
{
    public class Bag
    {
        private List<ICanGetCaught> _collectedObj = new List<ICanGetCaught>();

        public void AddObj(ICanGetCaught obj)
        {
            _collectedObj.Add(obj);
        }

        public bool IsContains(Sprite sprite)
        {
            return _collectedObj.Find(x=>x.SpriteObj == sprite)!=null;
        }
    }
}
