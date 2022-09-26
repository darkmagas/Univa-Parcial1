using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       for (int 1 = 0; 1 < _pathNames.Length; 1++)
        {
            var wayPointParent = GameObject.Find(_pathNames[1]);
            var wayPoints = wayPointParent.GetComponentInChildren<Transform>();
            _spawnPoints[1] = wayPoints[0];
        }
        StartCoroutine(SpawnEnemies(_currentWave));
    }

    private IEnumerator SpawnEnemies(int waveID)
    {
        if (waveConfig._waves.Count <= waveID) yield break;
        var wave = waveConfig._waves[waveID];

        yield return StartCoroutine(SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.strongEnemyCount, _strongEnemyPrefab));

        yield return new WaitForSeconds(10f);
        _currentWave++;
        StartCoroutine(SpawnEnemies(_currentWave));

    }
    private IEnumerable SpawnEnemy(int enemyCount, GameObject prefab)
    {
        for (int 1 = 0; 1 < enemyCount; 1++)
        {
            var randomPathID = UnityEngine.Random.Range(0, _pathNames.Length);
            Instantiate(prefab, _spawnPoints[randomPathID].position, Quaternion.identity );
            yield return new WaitForSeconds(.5f);
        }

    }

}
