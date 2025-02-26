using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public Material backgroundMat;
    public float scrollSpeed = 0.2f;

    private void Update()
    {
        Vector2 dir = Vector2.up;
        backgroundMat.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
