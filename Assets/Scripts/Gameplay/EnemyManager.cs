using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration waveconfig;
    private int _currentWave = 0;
    [SerializeField] private string[] _pathNames;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _strongEnemyPrefab;
    [SerializeField] private GameObject _bossEnemyPrefab;

    private void Start()
    {
        _spawnPoints = new Transform[_pathNames.Length];
        for (int i = 0; i < _pathNames.Length; i++)
        {
            var wayPointParent = GameObject.Find(_pathNames[i]);
            var wayPoints = wayPointParent.GetComponentsInChildren<Transform>();  // GetComponentsInChildren = agarra los transforms de los hijos
            _spawnPoints[i] = wayPoints[0];
        }

        StartCoroutine(SpawnEnemies(_currentWave));
    }
    private IEnumerator SpawnEnemies(int WaveID)
    {
        if (waveconfig._waves.Count <= WaveID) yield break; //el waveID debe ser menor al numero de waves que tenemos, esto ayuda a que no nos pasemos
        var wave = waveconfig._waves[WaveID];
        yield return StartCoroutine(SpawnEnemy(wave.weakEnemyCount, _weakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.midEnemyCount, _midEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.strongEnemyCount, _strongEnemyPrefab));
        yield return StartCoroutine(SpawnEnemy(wave.bossEnemyCount, _bossEnemyPrefab));

        yield return new WaitForSeconds(10f);
        _currentWave++;
        StartCoroutine(SpawnEnemies(_currentWave));
    }
        //aqui se cambvia el orden de spawn de los enemigos
        private IEnumerator SpawnEnemy(int enemyCount, GameObject prefab)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var randonPathID = UnityEngine.Random.Range(0, _pathNames.Length);
            Instantiate(prefab, _spawnPoints[randonPathID].position, Quaternion.identity );
            yield return new WaitForSeconds(.5f);  // tiempo en que cada enemigo spawnea
        }
    }

}
