using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    [SerializeField] private Animator image;
    public void OpenSceneName(string name)
    {
        StartCoroutine(OpenSceneCoroutine(name));
    }

    IEnumerator OpenSceneCoroutine(string name)
    {
        image.SetTrigger("Switch");

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene(name);
    }
}
