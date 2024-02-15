using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Droppable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Image image;
    private RectTransform rect;
    private Image droppedImage; // ��ӵ� �̹����� ������ ����
    private Transform originalPosition; // �巡�׵� �̹����� ���� �θ� ������ ����

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Transform draggedObject = eventData.pointerDrag.transform;
            Image draggedImage = draggedObject.GetComponent<Image>();

            if (droppedImage == null) // ó�� �̹��� ���
            {
                // ���ο� �̹��� �߰�
                droppedImage = draggedImage;
                originalPosition = draggedObject.parent; // �巡�׵� �̹����� ���� �θ� ����
                draggedObject.SetParent(transform); // �θ� ����
                draggedObject.GetComponent<RectTransform>().position = rect.position; // ��ġ ����
            }
            else if (draggedObject != droppedImage.transform) // �ٸ� �̹��� ���
            {
                // ���� �̹��� �ڸ��� �ǵ�����
                droppedImage.GetComponent<Draggable>().Reset();
                //droppedImage.transform.SetParent(originalPosition);
                //droppedImage.transform.GetComponent<RectTransform>().position = originalPosition.GetComponent<RectTransform>().position;

                // ���ο� �̹��� �߰�
                droppedImage = draggedImage;
                originalPosition = draggedObject.parent; // �巡�׵� �̹����� ���� �θ� ����
                draggedObject.SetParent(transform); // �θ� ����
                draggedObject.GetComponent<RectTransform>().position = rect.position; // ��ġ ����
            }
        }
    }
}
