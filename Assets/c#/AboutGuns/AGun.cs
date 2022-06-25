using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGun : MonoBehaviour
{
    //[SerializeField] SpriteRenderer spriteRenderer;
    
    //protected Sprite sprite { get { return spriteRenderer.sprite; } set { spriteRenderer.sprite = value; } }
    protected GameObject concreteGun;
    protected int typeID;
    protected float weight;
    protected float inertia;
    protected Vector2 centroid;
    protected float power;
    public System.Action OnCollided;
    private BulleteData equipedBullete;
    private float ingrediantAmount;
    protected GunData currentGunData;
    private Rigidbody2D currentRigidbody2D;
    public void UpdateStatus(GunData data)
    {
        currentGunData = data;
        typeID = data.TypeID;
        //sprite = data.Sprite;//這裡可能需要用讀SO的方式取得要顯示的sprite，不過目前用下面的式子生成槍枝，所以先不用這段
        concreteGun = Instantiate(data.GunPrefab);
        //currentRigidbody2D = concreteGun.GetComponentInChildren<Rigidbody2D>();
        concreteGun.transform.SetParent(transform, true);
        power = data.Power;
        inertia = data.Inertia;
        centroid = data.Centroid;
        weight = data.Weight;
    }
    public void UpdateBulleteStatus(BulleteData data)
    {
        equipedBullete = data;
    }
    public void Shoot()
    {
        float amount = ingrediantAmount;
        if (amount >= equipedBullete.Consumption)
        {
            ingrediantAmount -= equipedBullete.Consumption;
            GameObject concreteBullete = Instantiate(equipedBullete.BulletePrefab,currentGunData.shootPoint,Quaternion.FromToRotation(Vector3.up,transform.up));
            Rigidbody2D bulleteRigidBody2D = concreteBullete.GetComponent<Rigidbody2D>();
            new AShootFactory().CreateShoot().Shoot(currentRigidbody2D,currentGunData,bulleteRigidBody2D,equipedBullete);//目前先這樣，以後要新增的話可能可以開工廠模式，然後讀表決定要哪個工廠實作射擊的動作
        }
    }

}
