using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewCenterTool : MonoBehaviour,IEndDragHandler
{
    public float ContentItemWidth = 200.0f;    //content �̭����ت��ؤo

    private GameObject ContentGameObject;
    private RectTransform ContentRectTransform;
    private RectTransform ScrollViewRectTransform;

    private float _fNewX;
    public System.Action OnDragEnd;
    void Start()
    {
        RectTransform rcContent = this.GetComponent<ScrollRect>().content;
        ContentGameObject = rcContent.gameObject;
        ContentRectTransform = ContentGameObject.GetComponent<RectTransform>();

        ScrollViewRectTransform = GetComponent<RectTransform>();

        //_rcScrollView.sizeDelta.x �O ScrollView ���e��

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        int index = GetIndex();
        _fNewX = -((index - 1) * ContentItemWidth);
        ContentRectTransform.localPosition = new Vector2(_fNewX,ContentRectTransform.localPosition.y);
        OnDragEnd?.Invoke();
    }
    public int GetIndex()
    {
        int index = (Mathf.RoundToInt(-ContentRectTransform.localPosition.x / (ContentItemWidth))+1);
        //Debug.Log(index);
        return index;
        //_rcContent.localPosition.y �O content ����m
        //_rcContent.sizeDelta.y �O content ������

        //float x = (ContentRectTransform.localPosition.x) - _fStart1;
        //if (x <= 0)
        //    return 0;

        //int maxIndex = (int)(ContentRectTransform.sizeDelta.x / ContentItemWidth) - 1;

        //int index = (int)(x / ContentItemWidth) + 1;

        //if (index >= maxIndex)
        //{
        //    index = maxIndex;
        //}
        //Debug.Log(index + "index");
        //return index;
    }
}
