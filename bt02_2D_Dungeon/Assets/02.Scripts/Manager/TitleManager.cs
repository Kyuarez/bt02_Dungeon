using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneTransitionManager.LoadScene(SceneType.WorldMap);
    }

    public void OnClickEndButton()
    {
        Application.Quit();
    }
}
