using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image Heart1;
    [SerializeField] private Image Heart2;
    [SerializeField] private Image Heart3;

    [SerializeField] private Image HalfHeart1;
    [SerializeField] private Image HalfHeart2;
    [SerializeField] private Image HalfHeart3;

    [SerializeField] private Image LostHeart1;
    [SerializeField] private Image LostHeart2;
    [SerializeField] private Image LostHeart3;

    private void Start()
    {
        LostHeart1.enabled = false;
        LostHeart2.enabled = false;
        LostHeart3.enabled = false;
        HalfHeart1.enabled = false;
        HalfHeart2.enabled = false;
        HalfHeart3.enabled = false;
    }

    //public void LoseHeart1()
    //{
    //    LostHeart1.enabled = true;
    //    HalfHeart1.enabled = false;
    //}

    //public void LoseHeart2()
    //{
    //    LostHeart2.enabled = true;
    //    HalfHeart2.enabled = false;
    //}
    //public void LoseHeart3()
    //{
    //    LostHeart3.enabled = true;
    //    HalfHeart3.enabled = false;
    //}

    //public void SetHalfHeart1()
    //{
    //    Heart1.enabled = false;
    //    HalfHeart1.enabled = true;
    //}

    //public void SetHalfHeart2()
    //{
    //    Heart2.enabled = false;
    //    HalfHeart2.enabled = true;
    //}

    //public void SetHalfHeart3()
    //{
    //    Heart3.enabled = false;
    //    HalfHeart3.enabled = true;
    //}

    private void Update()
    {
        switch(GameManager.Instance.playerStats.currentHealth)
        {
            case 0:
                Heart1.enabled = false;
                Heart2.enabled = false;
                Heart3.enabled = false;
                HalfHeart1.enabled = false;
                HalfHeart2.enabled = false;
                HalfHeart3.enabled = false;
                LostHeart1 .enabled = true;
                LostHeart2 .enabled = true;
                LostHeart3 .enabled = true;
                break;
            case 1:
                Heart1.enabled = false;
                Heart2.enabled = false;
                Heart3.enabled = false;
                HalfHeart1.enabled = true;
                HalfHeart2.enabled = false;
                HalfHeart3.enabled = false;
                LostHeart1.enabled = false;
                LostHeart2.enabled = true;
                LostHeart3.enabled = true;

                break;
            case 2:
                Heart1.enabled = true;
                Heart2.enabled = false;
                Heart3.enabled = false;
                HalfHeart1.enabled = false;
                HalfHeart2.enabled = false;
                HalfHeart3.enabled = false;
                LostHeart1.enabled = false;
                LostHeart2.enabled = true;
                LostHeart3.enabled = true;
                break;
            case 3:
                Heart1.enabled = true;
                Heart2.enabled = false;
                Heart3.enabled = false;
                HalfHeart1.enabled = false;
                HalfHeart2.enabled = true;
                HalfHeart3.enabled = false;
                LostHeart1.enabled = false;
                LostHeart2.enabled = false;
                LostHeart3.enabled = true;
           
                break; 
            case 4:
                Heart1.enabled = true;
                Heart2.enabled = true;
                Heart3.enabled = false;
                HalfHeart1.enabled = false;
                HalfHeart2.enabled = false;
                HalfHeart3.enabled = false;
                LostHeart1.enabled = false;
                LostHeart2.enabled = false;
                LostHeart3.enabled = true;
            
                break;
            case 5:
                Heart1.enabled = true;
                Heart2.enabled = true;
                Heart3.enabled = false;
                HalfHeart1.enabled = false;
                HalfHeart2.enabled = false;
                HalfHeart3.enabled = true;
                LostHeart1.enabled = false;
                LostHeart2.enabled = false;
                LostHeart3.enabled = false;
            
                break;
            case 6:
                Heart1.enabled = true;
                Heart2.enabled = true;
                Heart3.enabled = true;
                HalfHeart1.enabled = false;
                HalfHeart2.enabled = false;
                HalfHeart3.enabled = false;
                LostHeart1.enabled = false;
                LostHeart2.enabled = false;
                LostHeart3.enabled = false;
                break;
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            default:
                break;

        }
    }

}
