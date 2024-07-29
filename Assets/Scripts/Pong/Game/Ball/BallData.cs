using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

namespace Pong.Game
{
    public struct BallData : IComponentData
    {
        public float2 Direction;
        public float Speed;

        public float3 GetDstCal()
        {
            var f2 = Direction * Speed;
            return new(f2.x, f2.y, 0);
        }
    }
}