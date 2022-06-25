using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGun : MonoBehaviour
{
    [SerializeField] GunData data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag is "PlayerGun")
        {
            Debug.Log("add gun data to repos");
            PlayerGunDataManager.instance.AddGunsToGunsRepository(data);
        }
    }
}
