using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject door;
    [SerializeField] private bool isOpen = false;

    private void Awake()
    {
        //TODO : �� ������ ���ؼ� isOpen �ޱ�
        SetPortal(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(true == collision.gameObject.CompareTag("Player"))
        {
            if(false == isOpen)
            {
                //TODO : ���� ������ ���� üũ�ؼ� �����ϱ�
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
