using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Jeremy_Test : MonoBehaviour
{
   
    [Test]
    public void ceateItem()
    {
        // Use the Assert class to test conditions
        SetupScene();
        var go=InventoryObject.CreateInstance("test"); 
        var second= InventoryObject.CreateInstance("base");
        Assert.AreEqual(second, go);

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Maxinventory()
    {
        SetupScene();
        var go=InventoryObject.CreateInstance("testinventory");
        ItemObject.CreateInstance("item");
        SceneManager.LoadScene(1);
        
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null; ;
        
    }
    [UnityTest]
    public IEnumerator inventorysize()
    {
        SetupScene();
        var go = InventoryObject.CreateInstance("testinventory");



        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null; ;

    }

    void SetupScene()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Item"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
               
    }
}
