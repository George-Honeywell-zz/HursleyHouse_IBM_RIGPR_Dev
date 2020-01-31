using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.PersonalityInsights.V3;
using IBM.Watson.PersonalityInsights.V3.Model;

[Serializable]
public class Trait
{
    public string name;
    public long percentile;
    public bool significant;
}
[Serializable]
public class Humour
{
    public string name;
    public long percentile;
    public bool significant;
    public Trait[] children = new Trait[6];
}
[Serializable]
public class Personality
{
    public Humour[] personality = new Humour[5];
}

[RequireComponent(typeof(W_TwitterSetup))]
public class W_WatsonSetup : MonoBehaviour
{
    private PersonalityInsightsService service;
    private W_TwitterSetup twitter;
    private Personality profile;
    bool AnalysisComplete = false;

    void Start()
    {
        twitter = gameObject.GetComponent<W_TwitterSetup>();
        Runnable.Run(SetAuthenticator("YnTxEUYrUVRgguKRbtwobHp5f5qQBvLonY_OlDHjtdkC"));
    }
    IEnumerator SetAuthenticator(string APIkey)
    {
        LogSystem.InstallDefaultReactors();
        IamAuthenticator authenticator = new IamAuthenticator(apikey: APIkey);

        //  Wait for tokendata
        while (!authenticator.CanAuthenticate())
            yield return null;

        service = new PersonalityInsightsService("2019-10-11", authenticator);
        service.SetServiceUrl("https://gateway-lon.watsonplatform.net/personality-insights/api");
        service.DisableSslVerification = true;
    }
    public void GetPersonalityProfile()
    {
        service.Profile(OnProfile, content: twitter.GetTwitterContent());
    }
    private void OnProfile(DetailedResponse<Profile> response, IBMError error)
    {
        profile = JsonUtility.FromJson<Personality>(response.Response);
    }
    bool GetAnalysisStatus()
    {
        return AnalysisComplete;
    }
    public Personality GetWatsonProfile()
    {
        if (GetAnalysisStatus())
        {
            return profile;
        }
        else
        {
            Debug.Log("Analysis in progress or failed");
            return null;
        }
    }
}
