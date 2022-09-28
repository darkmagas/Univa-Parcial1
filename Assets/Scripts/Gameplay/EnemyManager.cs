using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration waveConfig;
    private int _currentwave = 0;
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
            var wayPointsParent = GameObject.Find(_pathNames[i]);
            var wayPoints = wayPointsParent.GetComponentsInChildren<Transform>();
            _spawnPoints[i] = wayPoints[0];


        }

        StartCoroutine(SpawnEnemies(_currentwave));
    }

    private IEnumerator SpawnEnemies(int waveID)
    {
        if (waveConfig._waves.Count <= waveID) yield break;
        var wave = waveConfig._waves[waveID];

        yield return StartCoroutine(SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.strongEnemyCount, _strongEnemyPrefab));

        yield return new WaitForSeconds(10f);
        _currentwave++;
        StartCoroutine(SpawnEnemies(_currentwave));

    }


    private IEnumerator SpawnEnemy(int enemyCount, GameObject prefab)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var randomPathID = UnityEngine.Random.Range(0, _pathNames.Length);
            EventDispatcher.Dispatch(new SpawnObject(prefab, null, _spawnPoints[randomPathID].position, Quaternion.identity, (gameObjectSpawned) =>
                {
                    int rs = randomPathID;
                    string path = _pathNames[rs];
                    gameObjectSpawned.GetComponent<FollowPathMovement>().InitEnemy(path);
                })
            );
            
            yield return new WaitForSeconds(.5f);
        }
    }

}