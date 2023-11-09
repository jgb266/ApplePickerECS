using Unity.Entities;
using UnityEngine;

public class AppleAuthoring : MonoBehaviour
{
    public float speed;
    public float bottomEdge; 
    public float posX;
    public float posY;

    private class AppleBaker : Baker<AppleAuthoring>
    {
        public override void Bake(AppleAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            var propertiesComponent = new AppleProperties
            {
                Speed = authoring.speed,
                BottomEdge = authoring.bottomEdge,
                PosX = authoring.posX,
                PosY = authoring.posY
            };
            
            AddComponent(entity, propertiesComponent);
        }
    }
}

public struct AppleProperties : IComponentData
{
    public float Speed;
    public float BottomEdge;
    public float PosX;
    public float PosY;
}
