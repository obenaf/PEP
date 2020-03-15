using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Item : MonoBehaviour
{
    private Camera screenCamera;
    // Start is called before the first frame update
    void Start()
    {
        screenCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                if(hit.collider.GetComponent<Interactable_item>()!=null)
                {
                    hit.collider.GetComponent<Interactable_item>().Interact();
                }
            }
        }
    }
}
