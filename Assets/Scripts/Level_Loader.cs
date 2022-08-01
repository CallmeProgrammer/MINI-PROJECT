using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Loader: MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Loading_Screen;
    public Slider slider;
    void Start()
    {
        Loading_Screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void load_level(int sceneIndex)
    {

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        Loading_Screen.SetActive(true);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = Mathf.Clamp01(operation.progress / .2f);

            slider.value = progress;

            yield return null;
        }
    }
}
