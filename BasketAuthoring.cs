using Unity.Entities;
using UnityEngine;

public class BasketAuthoring : MonoBehaviour
{

    static public float posX;
    static public float posY;
    public float lives;

    private class BasketBaker : Baker<BasketAuthoring>
    {
        public override void Bake(BasketAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new BasketProperties
            {
                Lives = authoring.lives
            };
            
            AddComponent(entity, propertiesComponent);
        }
    }
}

public struct BasketProperties : IComponentData
{
    public float Lives;
}
