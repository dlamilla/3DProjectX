using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Slider _loadBar;
    [SerializeField] private GameObject _loadPanel;

    public void SceneLoad(int sceneIndex)
    {
        _loadPanel.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            _loadBar.value = asyncOperation.progress / 0.9f;
            yield return null;
        }
    }
}
