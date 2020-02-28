using System.Collections;
using UnityEngine;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.PersonalityInsights.V3;
using IBM.Watson.PersonalityInsights.V3.Model;

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
    void OnProfile(DetailedResponse<Profile> response, IBMError error)
    {
        Debug.Log(response.Response);
        profile = JsonUtility.FromJson<Personality>(response.Response);
        for (int q = 0; q < 5; q++)
            Debug.Log(profile.personality[q].name + " " + profile.personality[q].percentile);
        AnalysisComplete = true;
    }
    public bool GetAnalysisStatus()
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
