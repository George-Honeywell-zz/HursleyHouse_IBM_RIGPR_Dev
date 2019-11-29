using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;
using IBM.Cloud.SDK;
using System.IO;

public class TwitterSearch : MonoBehaviour
{
    void Start()
    {
        Twity.Oauth.consumerKey = "bW3qbrCBWEqQq98iUkOVgyjVY";
        Twity.Oauth.consumerSecret = "ZoLy9FyVocbVHqMsFfLCIFhVeYkma1lMapqV7EydwKsy40XXPA";
        Twity.Oauth.accessToken = "1198943099319439360-piJHmozb3fX2X7fEShxtOcE4zEgrtX";
        Twity.Oauth.accessTokenSecret = "o4Ii4Nj5MSB3KNQwF3GVwBSwjDf2aC49sdKN4420RH6dx";


        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["q"] = "@Oprah";
        parameters["count"] = 1.ToString(); ;
        StartCoroutine(Twity.Client.Get("search/tweets", parameters, Callback));
    }

    void Callback(bool success, string response)
    {
        string newFP = "./Assets/2019-2020/Watson/" + "TwitterSearchOutput" + ".txt";
        Debug.Log(response);
        if (success)
        {
            Debug.Log(response);
            SearchTweetsResponse Response = JsonUtility.FromJson<SearchTweetsResponse>(response);
            //Response.items[0].text;
            if (!Directory.Exists(newFP))
                File.WriteAllText(newFP, response);
            //Overwrite
            if (Directory.Exists(newFP))
            {
                File.Delete(newFP);
                File.WriteAllText(newFP, response);
            }
            Debug.Log(Response.statuses[0].text);
        }
        
        
    }

}

public class TwitterStuff : MonoBehaviour
{
    void Start()
    {
        Twity.Oauth.consumerKey = "bW3qbrCBWEqQq98iUkOVgyjVY";
        Twity.Oauth.consumerSecret = "ZoLy9FyVocbVHqMsFfLCIFhVeYkma1lMapqV7EydwKsy40XXPA";
        Twity.Oauth.accessToken = "1198943099319439360-piJHmozb3fX2X7fEShxtOcE4zEgrtX";
        Twity.Oauth.accessTokenSecret = "o4Ii4Nj5MSB3KNQwF3GVwBSwjDf2aC49sdKN4420RH6dx";


        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["q"] = "Oprah";
        parameters["count"] = 5.ToString();
        StartCoroutine(Twity.Client.Get("search/tweets", parameters, Callback));
    }

    void Callback(bool success, string response)
    {
        string newFP = "./Assets/2019-2020/Watson/" + "TwitterAppOutput" + ".txt";
        Debug.Log(response);
        if (success)
        {
            Debug.Log(response);
            SearchTweetsResponse Response = JsonUtility.FromJson<SearchTweetsResponse>(response);
            Tweets TOWU = JsonUtility.FromJson<Tweets>(response);
            //Response.items[0].text;
            if (!Directory.Exists(newFP))
                File.WriteAllText(newFP, response);
            //Overwrite
            if (Directory.Exists(newFP))
            {
                File.Delete(newFP);
                File.WriteAllText(newFP, response);
            }
            Debug.Log(TOWU.items[0].user.name);
            Debug.Log(TOWU.items[0].text);
            for (int r = 0; r < Response.statuses.Length; r++)
            {
                Debug.Log(Response.statuses[r].user.name);
                Debug.Log(Response.statuses[r].text);
            }
                

        }


    }

}
