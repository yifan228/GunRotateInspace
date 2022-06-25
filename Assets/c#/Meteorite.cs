using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//public class Meteorite : MonoBehaviour
//{
//    Button FlashBtn;
//    [SerializeField] Rigidbody2D rb2D;
//    [SerializeField] float speed;
//    [SerializeField] Vector3 rotate;
//    [SerializeField] ParticleSystem flashFlame;
//    public List<Clip> Clips =new List<Clip>() ;
//    ABullete bullete;
    
//    private void Awake()
//    {
//        FlashBtn = GameObject.Find("ConstFlashBtn").GetComponent<Button>();
//        FlashBtn.onClick.AddListener(OnFlashBtnClicked);        
//    }
//    private void OnFlashBtnClicked()
//    {
//        Vector2 vector2 = transform.up;
//        rb2D.velocity += vector2*speed;
//        flashFlame.Play();
//    }
//    private void FixedUpdate()
//    {
//        transform.Rotate(rotate,Space.Self);
//    }
//}
//public class Clip
//{
//    List<ABullete> bulletesInClip = new List<ABullete>();
//    public int BulleteAmount
//    {
//        get { return bulletesInClip.Count; }
//    }
//}
