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
            // 캔버스의 크기에 따라 랜덤 위치를 생성합니다.
            RectTransform canvasRectTransform = transform.parent.GetComponent<RectTransform>();

            float x = Random.Range(canvasRectTransform.rect.min.x, canvasRectTransform.rect.max.x);
            float y = Random.Range(canvasRectTransform.rect.min.y, canvasRectTransform.rect.max.y);

            // 버튼의 위치를 랜덤 위치로 변경합니다.
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