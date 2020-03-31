using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class EnemySpawnTests
    {
        //public object NSubstitute { get; private set; }

        [UnityTest]
        public IEnumerator _Instantiates_GameObject_From_Prefab()
        {

            var enemyPrefab = Resources.Load("Prefabs/Enemy1");
            var enemySpawner = new GameObject().AddComponent<EnemySpawner>();
            enemySpawner.Construct(enemyPrefab, 0, 1);

            yield return null;

            var spawnedEnemy = GameObject.FindWithTag("Enemy");
            var prefabOfTheSpawnedEnemy = PrefabUtility.GetPrefabParent(spawnedEnemy);

            Assert.AreEqual(enemyPrefab, prefabOfTheSpawnedEnemy);
        }
        /*
        [UnityTest]
        public IEnumerator _Instantiates_GameObject_At_Random_position()
        {
            var enemyPrefab = Resources.Load("Prefabs/Enemy1");
            var enemySpawner = new GameObject().AddComponent<EnemySpawner>();
            enemySpawner.Construct(enemyPrefab, 0, 1);
            var random = NSubstitute.Substitute.For<System.Random>();
            random.Next(Arg.Any<int>(), Arg.Any<int>()).Returns(270);
            enemySpawner.Random = random;

            yield return null;

            var spawnedEnemy = GameObject.FindWithTag("Enemy");
            var expectedPosition = new Vector3(0, -1, 0);

            Assert.AreEqual(expectedPosition, spawnedEnemy.transform.position);

        }*/


        [TearDown]
        public void AfterEveryTest()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Object.DestroyImmediate(gameObject);
            }
            foreach (var gameObject in Object.FindObjectsOfType<EnemySpawner>())
            {
                Object.DestroyImmediate(gameObject);
            }
        }

    }
}
