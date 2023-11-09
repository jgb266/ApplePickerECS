using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct AppleMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<AppleProperties>>())
        {
            var pos = transform.ValueRO.Position;
            var speed = properties.ValueRO.Speed;

            pos.y -= speed * SystemAPI.Time.DeltaTime;

            if (pos.y < properties.ValueRO.BottomEdge)
            {
                pos.x = AppleTreeAuthoring.posX;
                pos.y = AppleTreeAuthoring.posY;
            }

            if((pos.y - BasketAuthoring.posY <= 1 && pos.y - BasketAuthoring.posY >= -1) && (pos.x - BasketAuthoring.posX <= 3 && pos.x - BasketAuthoring.posX >= -3))
            {
                pos.x = AppleTreeAuthoring.posX;
                pos.y = AppleTreeAuthoring.posY;

                //AND INCREMENT SCORE
            }

            properties.ValueRW.PosX = pos.x;
            properties.ValueRW.PosY = pos.y;

            transform.ValueRW.Position = pos;

      
        }
    }
}