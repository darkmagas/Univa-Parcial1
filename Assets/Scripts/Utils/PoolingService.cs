using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;

namespace Magas.Utilities
{
    public class PoolingService : IDisposable
    {
        private Dictionary<int, List<GameObject>> _pooledObjects = new Dictionary<int, List<GameObject>>();
        private Dictionary<int, GameObject> _parents = new Dictionary<int, GameObject>();
        private Dictionary<int, Dictionary<int,GameObject>> _activePooledObjects = new Dictionary<int, Dictionary<int,GameObject>>();
        private static PoolingService _instance;
        
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializationPoolingService()
        {
            _instance = new PoolingService();
            SceneManager.sceneLoaded += _instance.OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            _pooledObjects.Clear();
            _parents.Clear();
            _activePooledObjects.Clear();
        }

        public PoolingService()
        {
            EventDispatcher.Subscribe<SpawnObject>(OnSpawnObject);
            EventDispatcher.Subscribe<DespawnObject>(OnDeSpawnObject);
        }

        private void OnSpawnObject(ISignal signal)
        {
            if(signal is SpawnObject spawnObject)
            {
                if(!_pooledObjects.ContainsKey(spawnObject.Object.name.GetHashCode()))
                {
                    _pooledObjects.Add(spawnObject.Object.name.GetHashCode(), new List<GameObject>());
                    _parents.Add(spawnObject.Object.name.GetHashCode(),spawnObject.Parent ==null? new GameObject($"POOL :: {spawnObject.Object.name}"):spawnObject.Parent);
                    _activePooledObjects.Add(spawnObject.Object.name.GetHashCode(), new Dictionary<int, GameObject>());
                }

                var pooledObjects = _pooledObjects[spawnObject.Object.name.GetHashCode()];
                var parent = _parents[spawnObject.Object.name.GetHashCode()];
                var activePooledObjects = _activePooledObjects[spawnObject.Object.name.GetHashCode()];
                if(pooledObjects.Count > 0)
                {
                    var pooledObject = pooledObjects[0];
                    pooledObjects.RemoveAt(0);
                    activePooledObjects.Add(pooledObject.GetInstanceID(), pooledObject);
                    pooledObject.transform.position = spawnObject.Position;
                    pooledObject.transform.rotation = spawnObject.Rotation;
                    pooledObject.SetActive(true);
                    spawnObject.OnSpawned?.Invoke(pooledObject);
                }
                else
                {
                  var newPooledObject = Object.Instantiate(spawnObject.Object, spawnObject.Position, spawnObject.Rotation);
                  newPooledObject.name = spawnObject.Object.name;
                  newPooledObject.transform.SetParent(parent.transform);
                  activePooledObjects.Add(newPooledObject.GetInstanceID(), newPooledObject);
                  spawnObject.OnSpawned?.Invoke(newPooledObject);
                }
            }
        }
        
        private void OnDeSpawnObject(ISignal signal)
        {
            if(signal is DespawnObject deSpawnObject)
            {
                if(!_activePooledObjects.ContainsKey(deSpawnObject.Object.name.GetHashCode()))
                {
                    Debug.Log($"POOL WARNING :: Object {deSpawnObject.Object.name} is not member of any known pool, proceeding to destroy it as the default error handler");
                    Object.Destroy(deSpawnObject.Object);
                    return;
                }
                var activePooledObjects = _activePooledObjects[deSpawnObject.Object.name.GetHashCode()];
                if(activePooledObjects.ContainsKey(deSpawnObject.Object.GetInstanceID()))
                {
                    var pooledObject = activePooledObjects[deSpawnObject.Object.GetInstanceID()];
                    pooledObject.SetActive(false);
                    activePooledObjects.Remove(deSpawnObject.Object.GetInstanceID());
                    _pooledObjects[deSpawnObject.Object.name.GetHashCode()].Add(pooledObject);
                }
            }
        }

        public void Dispose()
        {
            _instance = null;
            EventDispatcher.Unsubscribe<SpawnObject>(OnSpawnObject);
            EventDispatcher.Unsubscribe<DespawnObject>(OnDeSpawnObject);
        }
    }
}
