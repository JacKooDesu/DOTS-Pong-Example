using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Pong.Game
{
    public class BallAuth : MonoBehaviour
    {
        class Baker : Baker<BallAuth>
        {
            public override void Bake(BallAuth auth)
            {
                var e = GetEntity(auth, TransformUsageFlags.Dynamic);
                AddComponent(e, new BallData
                {
                    Direction = new(1, 1),
                    Speed = 5f
                });
            }
        }
    }

}
