using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace LukeTests
{
    public class ArrowSpawnTests
    {
        
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator Luke_ArrowSpawn()
        {
            SetupScene();
            if (MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ArrowTest")))
            {
                yield return 0;
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [UnityTest]
        public IEnumerator Spawn1000Arrows(){
            
            for (int i = 0; i < 1000; i++){
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ArrowTest"));
                yield return new WaitForSeconds(.01f);
            }
            Assert.Pass();
            
            
        }
        void SetupScene()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Grid"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
        }
        [TearDown]
        public void AfterEveryTest()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Missle"))
            {
                Object.DestroyImmediate(gameObject);
            }
            foreach (var gameObject in Object.FindObjectsOfType<ArrowSpawner>())
            {
                Object.DestroyImmediate(gameObject);
            }
        }
    }    
}