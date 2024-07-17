using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System.Linq;

public class SpawnerAuth : MonoBehaviour
{
    [field: SerializeField]
    public GameObject Prefab { get; private set; }
    [field: SerializeField]
    public virtual ESpawnableTag Tag { get; private set; }
    public enum Space
    {
        World,
        Child
    }
    [SerializeField]
    public Space SpaceMode { get; private set; }

    protected class Baker : Baker<SpawnerAuth>
    {
        public override void Bake(SpawnerAuth auth)
        {
            var e = GetEntity(TransformUsageFlags.None);
            AddComponent(e, new Spawner
            {
                Tag = auth.Tag,
                Prefab = GetEntity(auth.Prefab, TransformUsageFlags.Dynamic)
            });
        }
    }
}

public struct Spawner : IComponentData
{
    public ESpawnableTag Tag;
    public Entity Prefab;
}

public struct SpawnMsg : IComponentData
{
    public ESpawnableTag Tag;
}

public partial struct SpawnerHandler : IComponentData
{
    public Entity Entity;
    public DynamicBuffer<Spawner> Spawners;

    public Spawner GetSpawner(ESpawnableTag tag) =>
        Spawners.First(x => x.Tag == tag);
}

public enum ESpawnableTag : int
{
    Ball,
    Racket
}