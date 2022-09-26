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
        for (int i = 0; i < _pathNames.Length; i++)
        {
            var wayPointParent = GameObject.Find(_pathNames[i]);
            var wayPoint = wayPointParent.GetComponentsInChildren<Transform>();
            _spawnPoints[i] = wayPoint[0];
        }

        StartCoroutine(SpawnEnemies(_currentWave));
    }

    private IEnumerator SpawnEnemies(int waveID)
    {
        if (waveConfig._waves.Count <= waveID) yield break;
        var wave = waveConfig._waves[waveID];

        yield return StartCoroutine(SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.midEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.strongEnemyCount, _weakEnemyPrefab));

        yield return new WaitForSeconds(10f);
        _currentWave++;
        StartCoroutine(SpawnEnemies(_currentWave));
    }

    private IEnumerator SpawnEnemy(int enemyCount, GameObject prefab)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var randomPathID = UnityEngine.Random.Range(0, _pathNames.Length);
            Instantiate(prefab,_spawnPoints[randomPathID].position,Quaternion.identity);
            yield return new WaitForSeconds(.5f);
        }
    }
}
