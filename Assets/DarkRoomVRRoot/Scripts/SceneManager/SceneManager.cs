using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    // Name of the scene to load after delay
    public string sceneName;
    public GameObject table;



    private void Start()
    {
        var tablePosition = Camera.main.transform.position + Camera.main.transform.forward * 0.8f;
        tablePosition.y = 0.7f;
        table.transform.position = tablePosition;
    }


    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}