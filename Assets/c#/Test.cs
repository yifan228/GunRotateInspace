using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [ContextMenu("set child index to 1")]  
    public void test()
    {
        Debug.Log("set child index");
        transform.SetSiblingIndex(1);
    }
}
