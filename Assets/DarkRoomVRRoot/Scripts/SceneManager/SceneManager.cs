using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    // Name of the scene to load after delay
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to load the scene after a delay
        StartCoroutine(LoadSceneWithDelay("DarkRoomScene", 10f));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}