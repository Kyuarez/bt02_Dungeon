using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoSingleton<SceneTransitionManager>
{
    public static void LoadScene(SceneType sceneType)
    {
        SceneManager.LoadScene(sceneType.ToString());
    }

    public static void LoadSceneAsync(SceneType sceneType)
    {
        SceneManager.LoadSceneAsync(sceneType.ToString());
    }
}
