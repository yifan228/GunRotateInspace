using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulleteData", menuName = "CreateBulleteDataScriptableObject")]
public class BulleteData : ScriptableObject
{
    public int TypeID;
    public Sprite Sprite;
    public float Power;
    public float Weight;
    public float Inertia;
    public Vector2 Centroid;
    public float Consumption ;
    public GameObject BulletePrefab;
}

