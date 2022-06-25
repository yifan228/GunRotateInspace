using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GunData",menuName = "CreateGunDataScriptableObject")]
[SerializeField]
public class GunData : ScriptableObject
{
    public int TypeID;
    public Sprite Sprite;
    public float Power;
    public float Weight;
    public float Inertia;
    public Vector2 Centroid;
    public Vector2 shootPoint;
    public GameObject GunPrefab;
    public  int[] CanEquipedBulletesID;
}
