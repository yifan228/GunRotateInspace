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
        //sprite = data.Sprite;//�o�̥i��ݭn��ŪSO���覡���o�n��ܪ�sprite�A���L�ثe�ΤU�������l�ͦ��j�K�A�ҥH�����γo�q
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
            new AShootFactory().CreateShoot().Shoot(currentRigidbody2D,currentGunData,bulleteRigidBody2D,equipedBullete);//�ثe���o�ˡA�H��n�s�W���ܥi��i�H�}�u�t�Ҧ��A�M��Ū��M�w�n���Ӥu�t��@�g�����ʧ@
        }
    }

}
