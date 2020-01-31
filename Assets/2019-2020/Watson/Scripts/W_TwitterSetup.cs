using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;
using IBM.Watson.PersonalityInsights.V3.Model;

public class W_TwitterSetup : MonoBehaviour
{
    Content content;
    bool SearchComplete = false;
    // Constructor
    void Start()
    {
        SetOauth(
            "bW3qbrCBWEqQq98iUkOVgyjVY",
            "ZoLy9FyVocbVHqMsFfLCIFhVeYkma1lMapqV7EydwKsy40XXPA",
            "1198943099319439360-piJHmozb3fX2X7fEShxtOcE4zEgrtX",
            "o4Ii4Nj5MSB3KNQwF3GVwBSwjDf2aC49sdKN4420RH6dx");
    }
    // Twitter Developer Website Access
    public void SetOauth(string APIkey, string APIsecret, string AccessToken, string TokenSecret)
    {
        Twity.Oauth.consumerKey = APIkey;
        Twity.Oauth.consumerSecret = APIsecret;
        Twity.Oauth.accessToken = AccessToken;
        Twity.Oauth.accessTokenSecret = TokenSecret;
    }
    public void SearchUserTimeline(string ScreenName)
    {
        SearchComplete = false;
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["screen_name"] = ScreenName;
        parameters["count"] = "200";
        parameters["include_rts"] = "true";

        StartCoroutine(Twity.Client.Get("statuses/user_timeline", parameters, Callback));
    }
    private void Callback(bool success, string response)
    {
        StatusesUserTimelineResponse Response = JsonUtility.FromJson<StatusesUserTimelineResponse>(response);
        content = new Content()
        {
            ContentItems = new List<ContentItem>()
        };
        for (int r = 0; r < Response.items.Length; r++)
        {
            content.ContentItems.Add(
            new ContentItem()
            {
                Content = Response.items[r].text,
                Contenttype = ContentItem.ContenttypeValue.TEXT_PLAIN,
                Language = ContentItem.LanguageValue.EN,
            });
        }
        SearchComplete = true;
    }
    public bool GetSearchStatus()
    {
        return SearchComplete;
    }
    public Content GetTwitterContent()
    {
        if (GetSearchStatus())
        {
            return content;
        }
        else
        {
            Debug.Log("Search in progress or failed");
            return null;
        }  
    }

}
