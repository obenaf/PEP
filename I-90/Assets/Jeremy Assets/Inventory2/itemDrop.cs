using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDrop : MonoBehaviour
{

    private Transform Epos; // enemy position
    private void Start()
    {
  
        Epos = GetComponent<Transform>();
    }
    [SerializeField]
   public GameObject[] itemList;

    public void PlaceItem()
    {
        
        int value;
       value= UnityEngine.Random.Range(0, itemList.Length);
        Instantiate(itemList[value],Epos);
        

    }
}
