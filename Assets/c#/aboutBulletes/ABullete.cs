using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABullete : MonoBehaviour
{
    public float Weight;
    public SpriteRenderer spriterenderer;
    
    public void UpdateStatus(BulleteData data)
    {
        spriterenderer.sprite = data.Sprite;
    }
}
