using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial struct SpawnerHandleSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }

    public void OnDestroy(ref SystemState state) { }

    public void OnUpdate(ref SystemState state)
    {
        // var cmds = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
        //     .CreateCommandBuffer(state.WorldUnmanaged);
        var cmds = state.World.GetExistingSystemManaged<EndSimulationEntityCommandBufferSystem>()
            .CreateCommandBuffer();

        foreach (var (msg, e) in SystemAPI.Query<RefRO<SpawnMsg>>().WithEntityAccess())
        {
            if (!GetSpawner(ref state, msg.ValueRO.Tag, out var spawner))
                return;

            cmds.Instantiate(spawner.Prefab);
            cmds.DestroyEntity(e);
        }
    }

    bool GetSpawner(ref SystemState state, ESpawnableTag tag, out Spawner result)
    {
        result = default;
        foreach (RefRO<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO.Tag == tag)
            {
                result = spawner.ValueRO;
                return true;
            }
        }

        return false;
    }
}
