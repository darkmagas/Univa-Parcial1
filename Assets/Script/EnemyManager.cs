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
    [SerializeField] private GameObject strongEnemyPrefab;

    private void Start()
    { _spawnPoints = new Transform[_pathNames.Length];
        {
            var wayPointParent = GameObject.Find(_pathNames[i]);
            var wayPoints = wayPointParent.GetComponentsInChildren<Transform>();
            _spawnPoints[i] = wayPoints[0];
        }
        StartCoroutine(routine: SpawnEnemies(_currentWave));
    }

    private IEnumerator SpawnEnemies(int waveID)
    {
        if (waveConfig._Waves.Count <= waveID) yield break;
        var wave = waveConfig._Waves[waveID];

        yield return StartCoroutine(routine: SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemy(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(routine: SpawnEnemy(wave.strongEnemyCount, _StrongEnemyPrefab));

        yield return new WaitForSeconds(10f);
    }

    private IEnumerator SpawnEnemy(int enemyCount, GameObject prefab)
    {
        for (int i = 0; i < enemyCount; i++) 
        {
            var randomPathID:int = UnityEngine.Random.Range(0, _pathNames.Length);
            Instantiate(prefab,_spawnPoints[randomPathID].position,Quaternion.identity);
            EventDispatcher.Dispatch(signal: new SpawnObject(prefab, null, _spawnPoints[randomSpawn].position, Quaternion.identity, null));
            yield return new WaitForSeconds(.5f);
        }
    }
}
