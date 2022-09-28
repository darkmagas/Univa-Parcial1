using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private WaveConfiguration waveconfig;
    private int _currentWave = 0;
    [SerializeField] private string[] _pathNames;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        _spawnPoints = new Transform[_pathNames.Length];
        for (int i = 0; i < _pathNames.Length; i++)
        {
            var wayPointParent = GameObject.Find(_pathNames[i]);
            var wayPoints = wayPointParent.GetComponentsInChildren<Transform>();
            _spawnPoints[i] = wayPoints[0];
        }

        StartCoroutine(SpawnEnemies(_currentWave));

    }

    // Update is called once per frame
    private IEnumerator SpawnEnemies(int WaveID)
    {
        if (waveconfig._waves.Count <= WaveID) yield break;
        var wave = waveconfig._waves[WaveID];
        yield return StartCoroutine(SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.strongEnemyCount, _strongEnemyPrefab));

        yield return new WaitForSeconds(10f);
        _currentWave++;
        StartCoroutine(SpawnEnemies(_currentWave));
    }

    private IEnumerator SpawnEnemy(int enemyCount, GameObject prefab)
        { 
    for (int i = 0; i < enemyCount; i++)
    {
        var randomPathID = UnityEngine.Random.Range(0, _pathNames.Length);
            //Instantiate(prefab, _spawnPoints[randomPathID].position, Quaternion.identity );
            EventDispatcher.Dispatch(
                signal: new SpawnObject(prefab, Parent: null, _spawnPoints[randomPathID].position, Quaternion.identity, OnSpawned: null)
        );
    yield return new WaitForSeconds(.5f);
        } 
        
        
    }
}
