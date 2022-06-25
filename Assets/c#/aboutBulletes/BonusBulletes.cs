using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBulletes : MonoBehaviour
{
    [SerializeField] BulleteData data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "PlayerGun")
        {
            Debug.Log("add bullet data to repos");
            PlayerGunDataManager.instance.AddBulletesToBulletesRepository(data);
        }
    }
}
