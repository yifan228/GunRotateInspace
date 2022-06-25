using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class AShoot 
{
    public virtual void Shoot(Rigidbody2D gun,GunData gunData,Rigidbody2D bullte,BulleteData bulleteData)
    {
        ShowEffect();
        //bullte.transform.up = gun.transform.up;
        bullte.velocity = 0.05f*gunData.Power * gun.transform.up;
        gun.velocity = bullte.velocity*bulleteData.Weight / gunData.Weight;
        gun.angularVelocity = -Vector3.Distance(gunData.shootPoint, gunData.Centroid);//目前6/24先都逆時針
    }

    protected virtual void ShowEffect()
    {
        throw new NotImplementedException();
    }

    protected virtual void CalculatePhysics()
    {
        throw new NotImplementedException();
    }
}
