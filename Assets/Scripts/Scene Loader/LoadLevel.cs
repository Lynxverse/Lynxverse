using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] float transitionTime = 1f;
    [SerializeField] GameObject transitionCanvas;

    public void LoadSceneByName(string name) => SceneManager.LoadScene(name);
    public void AsyncLoadSceneByName(string name) => StartCoroutine(LoadAsyncWithTransition(name));
    public void Quit() => Application.Quit();

    IEnumerator LoadAsyncWithTransition(string name)
    {
        transitionCanvas.GetComponent<Animator>().SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(name);
    }
}
