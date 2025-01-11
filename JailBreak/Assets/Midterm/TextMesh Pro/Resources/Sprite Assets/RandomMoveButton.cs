using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMoveButton : MonoBehaviour, IPointerEnterHandler
{
    private int fake = 0;
    public void Start()
    {
        fake = 0;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (fake < 3)
        {
            // ĵ������ ũ�⿡ ���� ���� ��ġ�� �����մϴ�.
            RectTransform canvasRectTransform = transform.parent.GetComponent<RectTransform>();

            float x = Random.Range(canvasRectTransform.rect.min.x, canvasRectTransform.rect.max.x);
            float y = Random.Range(canvasRectTransform.rect.min.y, canvasRectTransform.rect.max.y);

            // ��ư�� ��ġ�� ���� ��ġ�� �����մϴ�.
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(x, y);
            fake++;
        }
    }
    public void LoadScene(string sceneName)
    {
        if (fake >= 3)
        {
            SceneManager.LoadScene("JailBreak");
        }        
    }
}