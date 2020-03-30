using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class Nikolai_EnemyPatrolTest : MonoBehaviour
{
    private Level0Manager game;

    [Test]
    public void EnemyPatrolTest()
    {
        //GameObject gameGameObject =
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        //game = gameGameObject.GetComponent<Level0Manager>();


        Object.Destroy(game.gameObject);
    }


}


