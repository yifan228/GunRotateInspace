using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private Button shootBtn;
    public AGun currentGun;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
    private void OnEnable()
    {
        shootBtn.onClick.AddListener(currentGun.Shoot) ;
    }
}
