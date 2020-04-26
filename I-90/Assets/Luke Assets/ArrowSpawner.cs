using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = System.Random;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private Object ArrowTest;
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _radius;

    private float _timeSinceLastSpawn;
    private Random _random;

    public void Construct(Object arrowPrefab)
    {
        ArrowTest = arrowPrefab;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

            var arrow = PrefabUtility.InstantiatePrefab(ArrowTest) as GameObject;

            arrow.transform.position = new Vector3(0, 0, 0);

    }
}
