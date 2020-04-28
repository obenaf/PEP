using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Object Enemy1;
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _radius;

    private float _timeSinceLastSpawn;
    private Random _random;

    public void Construct(Object enemyPrefab, float spawnRate, int radius)
    {
        Enemy1 = enemyPrefab;
        _spawnRate = spawnRate;
        _radius = radius;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_random == null)
        {
            _random = new Random();
        }

        if (_timeSinceLastSpawn >= _spawnRate)
        {
            // Prototype pattern that clones Enemy 1 instead of creating a new object every time
            GameObject enemy = Instantiate(Enemy1) as GameObject;
            //var enemy = PrefabUtility.InstantiatePrefab(Enemy1) as GameObject;

            var degrees = _random.Next(0, 361);

            var x = _radius * Mathf.Cos(degrees * Mathf.Deg2Rad);
            if (Mathf.Abs(x) < 0.01f)
            {
                x = 0;
            }

            var y = _radius * Mathf.Sin(degrees * Mathf.Deg2Rad);
            if (Mathf.Abs(x) < 0.01f)
            {
                y = 0;
            }

            enemy.transform.position = new Vector3(x, y, 0);

            _timeSinceLastSpawn = 0;

        }

        _timeSinceLastSpawn += Time.deltaTime;
    }
}
