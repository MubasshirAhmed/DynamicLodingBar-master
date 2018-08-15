using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelScript : MonoBehaviour
{
    public GameObject LoadingUIBG;
    public Slider slider;
    public Text loadingText;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsysnchronously(sceneIndex));
    }

    IEnumerator LoadAsysnchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingUIBG.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            loadingText.text = (progress * 100).ToString();
            yield return null;
        }
    }

}
