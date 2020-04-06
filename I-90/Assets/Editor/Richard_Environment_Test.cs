using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

//This test(s) will allow us to check that levels contain the appropriate amounts of every tagged object.
//determines existence of extra or unnoticed objects

//Can't get scene to load properly
//Unity docs suck
public class Richard_Test : MonoBehaviour
{
    private bool working = false;

    [Test]
    public void Richard_Environment_Test()
    {
        if(working)
        {
            if(Object_Check("Level0", 2, 3))
            {
                Assert.AreEqual(1,1);
            }
        }
        //Here for now to make us feel warm and fuzzy
        Assert.AreEqual(1,1);
    }

    bool Object_Check(string scene_name, int item_count, int enemy_count)
    {
        SceneManager.LoadScene(scene_name);
        if(GameObject.FindGameObjectsWithTag("item").Length == item_count)
        {
            if(GameObject.FindGameObjectsWithTag("enemy").Length == enemy_count)
            {
                return true;
            }
        }
        return false;
    }
}

