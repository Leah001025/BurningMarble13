using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Droppable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Image image;
    private RectTransform rect;
    public Image droppedImage; // ��ӵ� �̹����� ������ ����
    private Transform originalPosition; // �巡�׵� �̹����� ���� �θ� ������ ����
    public int EquippedIndex;

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
            int ID = draggedObject.GetComponent<Draggable>().ID;
            MarbleInfo temp = SlotManager.Instance.Inventory.Find(obj => obj.MarbleData.MarbleID == ID);
            temp.IsEquipped = true;

            if (droppedImage.sprite == null) // ó�� �̹��� ���
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
                droppedImage.GetComponent<Draggable>().ResetOrigin();

                int UnID = droppedImage.GetComponent<Draggable>().ID;
                MarbleInfo Untemp = SlotManager.Instance.Inventory.Find(obj => obj.MarbleData.MarbleID == UnID);
                Untemp.IsEquipped = false;

                // ���ο� �̹��� �߰�
                droppedImage = draggedImage;
                originalPosition = draggedObject.parent; // �巡�׵� �̹����� ���� �θ� ����
                draggedObject.SetParent(transform); // �θ� ����
                draggedObject.GetComponent<RectTransform>().position = rect.position; // ��ġ ����
            }
        }
    }
}
