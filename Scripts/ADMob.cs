using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class ADMob : MonoBehaviour {

    BannerView banner;

	void Start ()
    {
        RequestBanner();
        GameManager.instance.OnBadAnswer += ShowBanner;
    }

    void RequestBanner()
    {
        string bannerId = "ca-app-pub-3390838608392295/3990179161";
        banner = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);
    }

    public void ShowBanner()
    {
        banner.Show();
    }
}
