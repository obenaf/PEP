using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace NikolaiTests
{
    public class EnemySpawnTests
    {
        
        // Tests for whether the game can spawn one enemy
        [UnityTest]
        public IEnumerator _1SpawnEnemy()
        {

            SetupScene();
            if (MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyTest")))
            {
                yield return new WaitForSeconds(1);
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        // Spawn an enemy at a specific location and check that it spawned there
        [UnityTest]
        public IEnumerator _1SpawnEnemyAtLocation()
        {

            SetupScene();
            var enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyTest"));
            var pos = new Vector3(0.5f, 0.5f, 0);
            enemy.transform.position = pos;
            //if ()
            //{
            yield return new WaitForSeconds(1);
            Assert.AreEqual(pos, enemy.transform.position);
            //}
        }

        // Spawn an enemy at a specific location that is blocked by a rock collider and check it didn't spawn there
        [UnityTest]
        public IEnumerator _1SpawnEnemyAtForbiddenArea()
        {

            SetupScene();
            var enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyTest"));
            var pos = new Vector3(1, 1, 0);
            enemy.transform.position = pos;
            //if ()
            //{
            yield return new WaitForSeconds(1);
            Assert.AreNotEqual(pos, enemy.transform.position);
            //}
        }

        // Tests for whether the game can spawn 100 enemies and measure frame rate
        // Fail if below 60 fps
        [UnityTest]
        public IEnumerator _2SpawnOneHundredEnemies()
        {
            SetupScene();
            var T = 1 / Time.deltaTime;
            for (int i = 0; i < 100; i++)
            {
                T = 1 / Time.deltaTime;
                for (int j = 0; j < 100; j++)
                {
                    MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyTest"));
                    Debug.Log(T);
                    yield return new WaitForSeconds(0.01f);
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                yield return new WaitForSeconds(1);
                if (T < 60)
                {
                    Debug.Log((i + 1) * 100);
                    if (i < 10) Assert.Fail();
                    yield break;
                }
                else
                {
                    Assert.Pass();
                }
            }
            //yield return new WaitForSeconds(3);
            //Assert.Pass();
        }



        // Tests for whether the game can spawn endless enemies (100 million) and not crash
        /*[UnityTest]
        public IEnumerator _3SpawnOneThousandEnemies()
        {
            SetupScene();

            //SetupScene();
            var T = 1 / Time.deltaTime;
            for (int i = 0; i < 100; i++)
            {
                T = 1 / Time.deltaTime;
                for (int j = 0; j < 1000; j++)
                {

                    MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyTest"));
                    yield return new WaitForSeconds(0.1f);
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                yield return new WaitForSeconds(1);
                if (T < 15)
                {
                    Debug.Log((i + 1) * 100);
                    if (i < 10) Assert.Fail();
                    yield break;
                }
                else
                {
                    Assert.Pass();
                }
            }
        }*/

        void SetupScene()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Grid"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }

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
            //Object.DestroyImmediate("Grid");
            //Object.DestroyImmediate("Main Camera");
        }
    }
}