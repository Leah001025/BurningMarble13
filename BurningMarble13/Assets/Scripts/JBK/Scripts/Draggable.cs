using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas; //UI �� �ҼӵǾ� �ִ� �ֻ���� Canvas
    public Transform previousParent; // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ�
    private RectTransform rect; // UI ��ġ ��� ����

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;
        GetComponent<Image>().raycastTarget = false;
        transform.SetParent(canvas); // �θ� ������Ʈ�� canvas��
        transform.SetAsLastSibling(); // ���� �տ� ���̵���
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        if (transform.parent == canvas)
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.SetParent(previousParent);
        rect.position = previousParent.GetComponent<RectTransform>().position;
    }

}