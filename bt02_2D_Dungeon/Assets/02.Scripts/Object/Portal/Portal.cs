using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject door;
    [SerializeField] private bool isOpen = false;

    private void Awake()
    {
        //TODO : 맵 정보를 통해서 isOpen 받기
        SetPortal(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(true == collision.gameObject.CompareTag("Player"))
        {
            if(false == isOpen)
            {
                //TODO : 열쇠 있으면 열쇠 체크해서 오픈하기
                isOpen = true;
                SetPortal(isOpen);
            }
            else
            {
                SceneTransitionManager.LoadScene(sceneType);
            }
        }
    }

    private void SetPortal(bool isOpen)
    {
        this.isOpen = isOpen;
        door.SetActive(!isOpen);
        portal.SetActive(isOpen);
    }
}
