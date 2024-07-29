using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pong.Game
{
    public partial struct BallSystem : ISystem
    {
        public void OnCreate(ref SystemState state) { }

        public void OnDestroy(ref SystemState state) { }

        public void OnUpdate(ref SystemState state)
        {
            foreach (var (data, trans) in SystemAPI.Query<RefRW<BallData>, RefRW<LocalTransform>>())
            {
                var (absX, absY) = (math.abs(trans.ValueRO.Position.x), math.abs(trans.ValueRO.Position.y));
                if (absX >= 20)
                    data.ValueRW.Direction.x *= -1;

                if (absY >= 20)
                    data.ValueRW.Direction.y *= -1;

                trans.ValueRW.Position += data.ValueRO.GetDstCal() * SystemAPI.Time.DeltaTime;
            }
        }
    }
}