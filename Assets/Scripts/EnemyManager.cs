using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration waveConfig;
    private int _currentWave = 0;
    [SerializeField] private string[] _pathNames;
    [SerializeField] private Transform[] _spamPoints;

    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _StrongEnemyPrefab;

    private void Start()
    {
        _spamPoints = new Transform[_pathNames.Length];
        for (int i = 0; i < _pathNames.Length; i++)

        {
            var wayPointParent: GameObject = GameObject.Find(_pathName[i]);
            var wayPoints: Transform[] = wayPointParent.GetComponentsInChildren<Transform>();
            _spamPoints[i] = wayPoints[0];
        }

        StartCoroutine(routine: SpamEnemies(_currentWave));

        }

        private IEnumerator SpamEnemies(int waveID)

        {
            if(waveConfig _waves.Count <= waveID) yield break;
            var wave = waveConfig._waves[waveID];

           
      
        }



        private IEnumerator SpamEnemy(int enemyCount, GameObject prefab)

        {
            for (int i = 0; i < enemyCount; i++)

            {
            var randomPathID: UnityEngine.Random.Range(0, _pathNames.Length);

            }
        }

} }
