using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.PersonalityInsights.V3;
using IBM.Watson.PersonalityInsights.V3.Model;
public class ChildrenJsonConvert
{
    string trait_id;
    string name;
    string category;
    long percentile;
    bool significant;
}
public class PersonalityJsonConvert
{
    string trait_id;
    string name;
    string category;
    long percentile;
    bool significant;
    ChildrenJsonConvert[] children = new ChildrenJsonConvert[6];

}
public class Trait
{
    string name;
    long percentile;
    bool significant;
}
public class Humour
{
    Trait 
}
[RequireComponent(typeof(W_TwitterSetup))]
public class W_WatsonSetup : MonoBehaviour
{
    private PersonalityInsightsService service;
    private W_TwitterSetup twitter;
    void Start()
    {
        twitter = gameObject.GetComponent<W_TwitterSetup>();
    }
    // SetAuthenticator("YnTxEUYrUVRgguKRbtwobHp5f5qQBvLonY_OlDHjtdkC");
    IEnumerator SetAuthenticator(string APIkey)
    {
        LogSystem.InstallDefaultReactors();
        IamAuthenticator authenticator = new IamAuthenticator(apikey: APIkey);

        //  Wait for tokendata
        while (!authenticator.CanAuthenticate())
            yield return null;

        service = new PersonalityInsightsService("2019-10-11", authenticator); // 11 Oct
        service.SetServiceUrl("https://gateway-lon.watsonplatform.net/personality-insights/api");
        service.DisableSslVerification = true;
    }
    void GetPersonalityProfile()
    {
        service.Profile(OnProfile, content: twitter.GetTwitterContent());
    }
    private void OnProfile(DetailedResponse<Profile> response, IBMError error)
    {
        
    }
}
