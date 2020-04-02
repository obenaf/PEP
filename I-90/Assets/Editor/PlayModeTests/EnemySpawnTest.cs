using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemySpawnTest
    {
        [SerializeField] private Object Enemy1;
        int count = 0;
        [UnityTest]
        public IEnumerator _Instantiates_GameObject_From_Prefab()
        {

            var enemyPrefab = Resources.Load("Prefabs/Enemy1");
            var enemySpawner = new GameObject().AddComponent<EnemySpawner>();
            enemySpawner.Construct(enemyPrefab, 0, 1);

            yield return null;

            var spawnedEnemy = GameObject.FindWithTag("Enemy");
            Assert.IsNotNull(spawnedEnemy);
            //var prefabOfTheSpawnedEnemy = PrefabUtility.GetPrefabParent(spawnedEnemy);

            //Assert.AreEqual(enemyPrefab, prefabOfTheSpawnedEnemy);
        }

    }
}
