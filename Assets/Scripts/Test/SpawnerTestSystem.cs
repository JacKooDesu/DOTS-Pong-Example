using Unity.Entities;
using UnityEngine;

public partial struct SpawnerTestSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }

    public void OnDestroy(ref SystemState state) { }

    public void OnUpdate(ref SystemState state)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var e = state.EntityManager.CreateEntity(typeof(SpawnMsg));
            var msgRW = SystemAPI.GetComponentRW<SpawnMsg>(e);
            msgRW.ValueRW.Tag = ESpawnableTag.Ball;
        }
    }
}