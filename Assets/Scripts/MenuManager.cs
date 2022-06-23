using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject dropdownObj;
    private Dropdown dropdown;
    private void Start()
    {
        dropdown = dropdownObj.GetComponent<Dropdown>();
    }
    public void RatioSetter()
    {
        if(dropdown.value == 0)
        {
            Debug.Log("index 0 selected");
            Screen.SetResolution(1080, 1920, true);
        }
        else if (dropdown.value == 1)
        {
            Debug.Log("index 1 selected");
            Screen.SetResolution(1920, 1080, true);
        }
        else if (dropdown.value == 2)
        {
            Screen.SetResolution(1200, 1600, true);
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
