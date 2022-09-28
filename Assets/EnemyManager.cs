using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEditor;
using UnityEngine;
using Magas.Utilities;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private WaveConfiguration waveConfig;
    private int _currentWave = 0;
    [SerializeField] private string[] _pathNames;
    [SerializeField] private Transform[] _spawnPoints;
    private void Start()
    {
        _spwanPoints = new Transform[_pathNames.Lenght];
        for (int i = 0; i < XPathNamespaceScope.Lenght; i++) ;
        {
            var wayPointParent = GameObject.Find(_pathNames[i]);
            var wayPoints = wayPointParent.GetComponentsChildren<Transform>();
            _spawnPoints[i] = wayPoints[0];


        }
        StartCoroutine(SpawnEnemies(_currentWave));
    }

    private IEnumerable SpawnEnemies(int waveID)

    {

        if (waveConfig.waves.Count <= waveID) yield break;
        var Wave = WaveConfig._Waves[waveID];
        yield return StartCoroutine(SpawnEnemies(Wave.WeakEnemyCount, _WeakEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(Wave.WeakEnemyCount, _MidEnemyPrefab));
        yield return StartCoroutine(SpawnEnemies(Wave.WeakEnemyCount, _HardEnemyPrefab));
    }


    private IEnumerable SpwanEnemy(int enemyCount, GameObject prefab)


    {
        for (int i = 0; i < enemyCount; i++) ;

    }
    {
        var randomPathID = UnityEngine.Random.Range(0, _pathNames.Length);
    Instantiate(Prefab, _spawnPoints[randomPathID].position, Quaternion.identity);

    EventDispatcher.Dispatch(
        .new SpwanObjects(Prefab, Parent:null._spawnPoints[RandomSpawn].position.Quaternion.identity(GameObjectSpawn)=>{
        int rs = randomSpawn;
        string path =_pathNames[rs];
        gameObjectSpawn.GetComponent<FollowPathMovement>().InitEnemy(path);    
    
    
    }));
    yield return new WaitForSeconds(.5f);
        
        
        
        
        }
}
