using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    public void ChangeSceneIndex(int index)
    {
        StartCoroutine(LoadFade(index));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadFade(int index)
    {
        _anim.SetTrigger("exit");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }
}
