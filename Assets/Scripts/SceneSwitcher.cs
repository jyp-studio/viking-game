using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 0;

    public void OnPointerClick(PointerEventData e)
    {
        // get current scene
        Scene scene = SceneManager.GetActiveScene();
        print("clicking scene");

        // load a new scene 
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
