using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using Magas.Utilities;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration waveConfig;
    [SerializeField] private List<string> _pathNames = new();
    private List<Transform> _spawnpoints = new();

    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    [SerializeField] private GameObject _NukeEnemyPrefab;
    [SerializeField] private GameObject _VarEnemyPrefab;
    [SerializeField] private float _timeToNextWave = 5f;
    private int _currentWave = 0;
    private void Start()
    {
        for (int i = 0; i < _pathNames.Count; i++)
        {
            var waypointParent = GameObject.Find(_pathNames[i]);
            if (waypointParent != null)
            {
                var firstChild = waypointParent.transform.GetChild(0);
                if (firstChild != null)
                {
                    _spawnpoints.Add(firstChild);
                }
            }
        }

        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        if (waveConfig._waves.Count <= _currentWave) yield break;
        var wave = waveConfig._waves[_currentWave];
        yield return StartCoroutine(SpawnEnemies(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.strongEnemyCount, _strongEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.NukeEnemyCount, _NukeEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(wave.VarEnemyCount, _VarEnemyPrefab));
        _currentWave++;

        while (GameManager.Instance.EnemyCount > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(_timeToNextWave);
        StartCoroutine(SpawnEnemies());

    }
    private IEnumerator SpawnEnemies(int amount, GameObject prefab)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomSpawn = Random.Range(0, _pathNames.Count);
            //Instantiate(prefab,_spawnpoints[randomSpawn].position,Quaternion.identity);
            EventDispatcher.Dispatch(
                new SpawnObject(prefab,
                    null, _spawnpoints[randomSpawn].position,
                    Quaternion.identity,
                    (gameObjectSpawn) =>
                    {
                        int rs = randomSpawn;
                        string pathName = _pathNames[rs];
                        gameObjectSpawn.GetComponent<FollowPathMovement>().InitEnemy(pathName);
                    }));
            yield return new WaitForSeconds(1);
        }
    }
}
