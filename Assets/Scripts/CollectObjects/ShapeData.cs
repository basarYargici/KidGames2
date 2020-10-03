using UnityEngine;

namespace CollectObjects
{
    public class ShapeData
    {
        public int id { get; }
        public Sprite shapeSprite { get; }

        public ShapeData(int id, Sprite sprite)
        {
            this.id = id;
            shapeSprite = sprite;
        }
    }
}