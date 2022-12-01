using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ReklamRewardedVideo2 : MonoBehaviour
{
    GameObject gold;
    private int altin = 0;
    private RewardBasedVideoAd reklamObjesi;
    public Button a;

    void Start()
    {
      //  InvokeRepeating("ac", 10f, 45f);
        
        gold = GameObject.FindGameObjectWithTag("MainCamera");
        MobileAds.Initialize(reklamDurumu => { });

        reklamObjesi = RewardBasedVideoAd.Instance;
        reklamObjesi.OnAdClosed -= YeniReklamAl;
        reklamObjesi.OnAdClosed += YeniReklamAl; // Kullanıcı reklamı kapattıktan sonra çağrılır

        YeniReklamAl(null, null);
    }
    void Update()
    {
       
    }
    // Ekranda test amaçlı "Reklamı Göster" butonu göstermeye yarar, bu fonksiyonu silerseniz buton yok olur
   /* void OnGUI()
    {
        GUI.Label(new Rect(0, Screen.height / 2, 500, 150), altin + " altının var!");

        // Butonu sadece reklam tamamen yüklenmişse (IsLoaded() true ise) tıklanabilir yap
        GUI.enabled = reklamObjesi.IsLoaded();

        if (GUI.Button(new Rect(Screen.width / 2 - 150, 0, 300, 300), "Reklamı Göster"))
        {
            reklamObjesi.OnAdRewarded -= OyuncuyuOdullendir;
            reklamObjesi.OnAdRewarded += OyuncuyuOdullendir; // Kullanıcı reklamı tamamen izledikten sonra çağrılır

            reklamObjesi.Show();
        }

        GUI.enabled = true;
    }*/

    public void YeniReklamAl(object sender, EventArgs args)
    {
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi, "ca-app-pub-8383639135117164/5930107664");
      //  a.enabled = reklamObjesi.IsLoaded();
    }

   /* private void OyuncuyuOdullendir(object sender, Reward odul)
    {
        reklamObjesi.OnAdRewarded -= OyuncuyuOdullendir;

        Debug.Log("Ödül türü: " + odul.Type);
        altin += (int)odul.Amount;
    }*/
    public void asd()
    {

       /* reklamObjesi.OnAdRewarded -= OyuncuyuOdullendir;
        reklamObjesi.OnAdRewarded += OyuncuyuOdullendir; // Kullanıcı reklamı tamamen izledikten sonra çağrılır*/

        reklamObjesi.Show();
        gold.GetComponent<coin>().add_gold();
        a.enabled=false; 
        Invoke("ac", 15f);
    }
   public void ac()
    { a.enabled=true; }
    
}