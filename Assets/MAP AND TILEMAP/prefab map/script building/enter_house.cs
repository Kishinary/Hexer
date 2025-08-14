using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class enter_house : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public KeyCode interactKey = KeyCode.E;
    public string sceneToLoad = "House 1";
    void OnTriggerStay2D(Collider2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(interactKey))
            {     
                
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
            }
        }

    }
}
