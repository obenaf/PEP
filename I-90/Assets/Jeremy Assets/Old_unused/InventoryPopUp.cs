/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopUp : MonoBehaviour
{

    public enum MenuStates {mainScreen, pauseScreen, inventory };
    public MenuStates currentstate;

public GameObject mainScreen;
public GameObject inventory;
public GameObject PauseScreen;


    // Start is called before the first frame update
    void Awake()
    {
        currentstate = MenuStates.mainScreen; 
    }

    // Update is called once per frame
    void Update()
    {

        switch(currentstate)
    {
            case MenuStates.mainScreen:
                //selects active game
                mainScreen.SetActive(true);
                inventory.SetActive(false);
               PauseScreen.SetActive(false);

                break;

            case MenuStates.pauseScreen:
                //loads pause screen
                mainScreen.SetActive(false);
                inventory.SetActive(false);
                PauseScreen.SetActive(true);
                break;
            case MenuStates.inventory:
                //loads inventory screen
                mainScreen.SetActive(false);
                inventory.SetActive(true);
                PauseScreen.SetActive(false);
                break;
    }
    }
    public void inventoryButton()
    { currentstate = MenuStates.inventory; }
    public void exitInventoryButton()
    { currentstate = MenuStates.mainScreen; }
}
*/
