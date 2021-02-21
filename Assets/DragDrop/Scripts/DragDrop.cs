using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    public bool held = false;
    public float rotation = 90f;

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (held)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("e");
                rectTransform.Rotate(0, 0, 90);
                //StartCoroutine(RotateMe(new Vector3(0, 0, 1) * 90f, 1));
            }
            if (Input.GetKeyDown("q"))
            {
                rectTransform.Rotate(0, 0, -90);
                // StartCoroutine(RotateMe(new Vector3(0, 0, 1) * -90f, 1));
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        held = true;
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

    }

    public void OnDrag(PointerEventData eventData)
    {

        
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        held = false;
        Debug.Log("OnEndDrag");
        float x = Mathf.Round(rectTransform.anchoredPosition.x * 0.01f) * 100f;
        float y = Mathf.Round(rectTransform.anchoredPosition.y * 0.01f) * 100f;
        rectTransform.anchoredPosition = new Vector2(x, y);
    }

}
