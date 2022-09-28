using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration waveConfig;
    private int _currentWave = 0;
    [SerializeField] private string[] _pathNames;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;

    private void Start()
    {
        _spawnPoints = new Transform[_pathNames.Length];
        for (int i=0;i<_pathNames.Length; i++)
        {
            var wayPointParent:GameObject = GameObject.Find(_pathNames[i]);
            var wayPointParent:Transform[] = wayPointParent.GetComponentsInChildren<Transform>();
            _spawnPoints[i] = wayPoints[0];
        }

        StartCoroutine(routine: SpawnEnemies(_currentWave));
    }

    private IEnumerable CreateWave ()
    {
        if (waveConfig._waves.Count <= waveID) yield break;
        var wave = waveConfig._waves[_currentWave];
        yield return StartCoroutine(routine: SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemy(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemy(wave.strongEnemyCount, _strongEnemyPrefab));
        _currentWave++;
        yield return new WaitForSeconds(10f);
        StartCoroutine(routine: CreateWave());
    }

    private IEnumerable SpawnEnemy(int amont, GameObject, GameObject prefab)
    {
        for (int i = 0; i < amont; i++)
        {
            var randomPathID = UnityEngine.Random.Range(0, _pathNames.Length);
            EventDispatcher.Dispatch(
                signal: new SpawnObject(prefab, Parent: null, _spawnpoints[randomSpawn].position, Quaternion.identity, OnSpawned: (gameObjectSpawned) =>
                {
                    int rs = randomSpawn;
                    string path = _pathNames[rs];
                    gameObjectSpawned.GetComponent<FollowPathMovement>().InitEnemy(path);
                })
                );
            yield return new WaitForSeconds(1f);
        }
    }
}