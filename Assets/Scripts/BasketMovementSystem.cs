using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct BasketMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (transform, properties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<BasketProperties>>())
        {
            var pos = transform.ValueRO.Position;

            var mousePos = Input.mousePosition;

            pos.x = Camera.main.ScreenToWorldPoint(mousePos).x;

            BasketAuthoring.posX = pos.x;
            BasketAuthoring.posY = pos.y;

            transform.ValueRW.Position = pos;
        }
    }
}