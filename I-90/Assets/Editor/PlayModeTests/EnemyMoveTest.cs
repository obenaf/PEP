﻿/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace Tests
{
    public class EnemyMoveTest
    {
        int count = 0;
        [UnityTest]
        public IEnumerator _enemyMoveTest()
        {
            var enemyPrefab = Resources.Load("Prefabs/Enemy1");
            var enemySpawner = new GameObject().AddComponent<EnemySpawner>();

            enemySpawner.Construct(enemyPrefab, 0, 1);

            yield return null;

            var spawnedEnemy = GameObject.FindWithTag("Enemy");
            var enemyMover = spawnedEnemy.GetComponent<SoldierMovement>();
            var myRigidbody = spawnedEnemy.GetComponent<Rigidbody2D>();
            float myPositionX = myRigidbody.position.x;
            //float currentPosX = enemyMover.getPositionX();
            //float currentPosY = enemyMover.getPositionY();
            //var prefabOfTheSpawnedEnemy = PrefabUtility.GetPrefabParent(spawnedEnemy);
            var velocity = new Vector2(1, 1);
            yield return null;
            myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
            //enemyMover.moveEnemy(1.0f, 1.0f);
            yield return null;
            //float newPosX = enemyMover.getPositionX();
            float newPosX = myRigidbody.position.x;
            //float newPosY = enemyMover.getPositionY();
            Assert.AreNotEqual(myPositionX, newPosX);
        }

    }
}*/