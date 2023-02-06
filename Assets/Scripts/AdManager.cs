using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameID;
    [SerializeField] string iOSGameID;
    [SerializeField] bool testMode = true;
    string adID = null;

    void Awake()
    {
        CheckPlatform();
    }

    // Start is called before the first frame update
    void CheckPlatform()
    {
        string gameID = null;
#if UNITY_IOS || UNITY_EDITOR
        {
            gameID = iOSGameID;
            adID = "Rewarded_iOS";
        }
    

#elif UNITY_ANDROID || UNITY_EDITOR
        {
            gameID = androidGameID;
            adID = "Rewarded_Android";
        }
        
#endif
    Advertisement.Initialize(gameID, testMode, false, this);
     }

    IEnumerator WaitForAd()
    { 
        while (!Advertisement.isInitialized) 
        {
            yield return null;
        }

        LoadAd();
    }

    void LoadAd()
    { 
        Advertisement.AddListener(this);
        Advertisement.Load(adID);
    }

    public void WatchAd()
    {
        Advertisement.Show(adID);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnServerInitialized(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //Reward the player
            Debug.Log("Unity Ads reward completed!");
        }

        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Player has skipped the ad!");
        }

        else if (showResult!= ShowResult.Failed) 
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }

        Advertisement.Load(placementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
