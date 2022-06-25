using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunDataManager : MonoBehaviour
{
    public static PlayerGunDataManager instance;
    List<GunData> gunsRepository = new List<GunData>();

    [Header("scroll bars")]
    [SerializeField] ScrollRect GunScrollRect;
    [SerializeField] RectTransform GunScrollContent;
    [SerializeField] GameObject GunScrollContentObject;
    [SerializeField] ScrollViewCenterTool GunBarCenterTool;
    Dictionary<GunData,GameObject> ConcreteGunScrollContent = new Dictionary<GunData, GameObject>();
    private Vector2 currentGunScrollPosition = Vector2.zero;

    List<BulleteData> bulletesRepository = new List<BulleteData>();

    [SerializeField] ScrollRect BulleteScrollRect;
    [SerializeField] RectTransform BulleteScrollContent;
    [SerializeField] GameObject BulleteScrollContentObject;
    [SerializeField] ScrollViewCenterTool BulleteBarCenterTool;
    Dictionary<BulleteData, GameObject> ConcreteBulleteScrollContent = new Dictionary<BulleteData, GameObject>();
    private Vector2 currentBulleteScrollPosition = Vector2.zero;

    [SerializeField] AGun playerCurrentGun;
    [SerializeField] ABullete playerCurrentBulleteDisplayer;
    private float FirstScrollImaneLength = 100f;
    private float LastScrollImaneLength = 100f;
    private GunData currentGunData = null;
    private BulleteData currentBulleteData = null;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        GunScrollRect.onValueChanged.AddListener(OnGunScrollChange);
        BulleteScrollRect.onValueChanged.AddListener(OnBulleteScrollChange);
        GunBarCenterTool.OnDragEnd = ChangeGun;
    }
    public void AddGunsToGunsRepository(GunData gun)
    {
        if (!gunsRepository.Contains(gun))
        {
            gunsRepository.Add(gun);
            GameObject go = Instantiate(GunScrollContentObject);
            go.transform.SetParent(GunScrollContent);
            go.transform.SetSiblingIndex(gunsRepository.Count);
            go.GetComponent<Image>().sprite = gun.Sprite;
            ConcreteGunScrollContent.Add(gun,go);
            SetContentWidthWithRepositoryCount<GunData>(GunScrollContent,gunsRepository);
            //GunScrollRect.numberOfSteps = gunsRepository.Count;
        }
    }
    
    public void RemoveGunInRepository(GunData gun)
    {
        if (gunsRepository.Contains(gun))
        {
            gunsRepository.Remove(gun);
            ConcreteGunScrollContent.TryGetValue(gun, out GameObject go);
            Destroy(go);
            SetContentWidthWithRepositoryCount<GunData>(GunScrollContent, gunsRepository);
            //GunScrollRect.numberOfSteps = gunsRepository.Count;
        }
    }
    private void SetContentWidthWithRepositoryCount<T>(RectTransform rectTransform,List<T> repository)
    {
        rectTransform.sizeDelta = new Vector2(repository.Count * 100 +FirstScrollImaneLength+LastScrollImaneLength , 150);
    }
    public void OnGunScrollChange(Vector2 vector2)
    {
        if (gunsRepository.Count == 0) return;
        if (Mathf.Abs(currentGunScrollPosition.x - vector2.x) <= 0.1)
        { 
            return; 
        }
        else { currentGunScrollPosition = vector2; }
        int repositiryIndex = GunBarCenterTool.GetIndex() - 1;
        if (repositiryIndex >= gunsRepository.Count)
        {
            repositiryIndex = gunsRepository.Count-1;
        }else if (repositiryIndex < 0)
        {
            repositiryIndex = 0;
        }
        ChangePlayerGunStatus(gunsRepository[repositiryIndex]);
    }
    public void ChangePlayerGunStatus(GunData data)
    {
        if(currentGunData == data)
        {
            return;
        }
        currentGunData = data;
        //這邊如果種類多的話可能要重購
        bool IsCurrentGunCanEquipedThisBullete = CanCurrentGunEquipedThisBullete(data,currentBulleteData);
        if (!IsCurrentGunCanEquipedThisBullete)
        {
            ShowCurrentBulleteCannotBeEquipedImage();
        }
        Debug.Log(data.Weight);
    }
    private void ChangeGun()
    {
        playerCurrentGun.UpdateStatus(currentGunData);
    }
    private bool CanCurrentGunEquipedThisBullete(GunData gunData,BulleteData bulleteData)
    {
        if(Array.Exists<int>(gunData.CanEquipedBulletesID,element => element == bulleteData.TypeID))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ShowCurrentBulleteCannotBeEquipedImage()
    {

    }
    //
    public void AddBulletesToBulletesRepository(BulleteData bullete)
    {
        if (!bulletesRepository.Contains(bullete))
        {
            bulletesRepository.Add(bullete);
            GameObject go = Instantiate(BulleteScrollContentObject);
            go.transform.SetParent(BulleteScrollContent);
            go.transform.SetSiblingIndex(bulletesRepository.Count);
            go.GetComponent<Image>().sprite = bullete.Sprite;
            ConcreteBulleteScrollContent.Add(bullete, go);
            SetContentWidthWithRepositoryCount<BulleteData>(BulleteScrollContent, bulletesRepository);
        }
    }

    public void RemoveBulleteInRepository(BulleteData bullete)
    {
        if (bulletesRepository.Contains(bullete))
        {
            bulletesRepository.Remove(bullete);
            ConcreteBulleteScrollContent.TryGetValue(bullete, out GameObject go);
            Destroy(go);
            SetContentWidthWithRepositoryCount<BulleteData>(BulleteScrollContent, bulletesRepository);
        }
    }

    public void OnBulleteScrollChange(Vector2 vector2)
    {
        if (bulletesRepository.Count == 0) return;
        if (Mathf.Abs(currentBulleteScrollPosition.x - vector2.x) <= 0.1)
        {
            return;
        }
        else { currentBulleteScrollPosition = vector2; }
        int repositiryIndex = BulleteBarCenterTool.GetIndex() - 1;
        if (repositiryIndex >= bulletesRepository.Count)
        {
            repositiryIndex = bulletesRepository.Count - 1;
        }
        else if (repositiryIndex < 0)
        {
            repositiryIndex = 0;
        }
        ChangePlayerBulleteStatus(bulletesRepository[repositiryIndex]);
    }
    public void ChangePlayerBulleteStatus(BulleteData data)
    {
        if (currentBulleteData == data)
        {
            return;
        }
        currentBulleteData = data;
        //這邊如果種類多的話可能要重購
        playerCurrentBulleteDisplayer.UpdateStatus(data);//目前測試用
        if (CanCurrentGunEquipedThisBullete(currentGunData, data))
        {
            playerCurrentGun.UpdateBulleteStatus(data);
        }
        else
        {
            ShowCurrentBulleteCannotBeEquipedImage();
        }
        
    }
}
