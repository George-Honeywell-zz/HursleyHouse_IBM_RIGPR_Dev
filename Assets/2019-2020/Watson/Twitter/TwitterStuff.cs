using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;
using IBM.Cloud.SDK;
using System.IO;

//public class TwitterSearch : MonoBehaviour
//{
//    void Start()
//    {
//        Twity.Oauth.consumerKey = "bW3qbrCBWEqQq98iUkOVgyjVY";
//        Twity.Oauth.consumerSecret = "ZoLy9FyVocbVHqMsFfLCIFhVeYkma1lMapqV7EydwKsy40XXPA";
//        Twity.Oauth.accessToken = "1198943099319439360-piJHmozb3fX2X7fEShxtOcE4zEgrtX";
//        Twity.Oauth.accessTokenSecret = "o4Ii4Nj5MSB3KNQwF3GVwBSwjDf2aC49sdKN4420RH6dx";


//        Dictionary<string, string> parameters = new Dictionary<string, string>();
//        parameters["q"] = "@Oprah";
//        parameters["count"] = 1.ToString(); ;
//        StartCoroutine(Twity.Client.Get("search/tweets", parameters, Callback));
//    }

//    void Callback(bool success, string response)
//    {
//        string newFP = "./Assets/2019-2020/Watson/" + "TwitterSearchOutput" + ".txt";
//        Debug.Log(response);
//        if (success)
//        {
//            Debug.Log(response);
//            StatusesUserTimelineResponse Response = JsonUtility.FromJson<StatusesUserTimelineResponse>(response);
//            //Response.items[0].text;
//            if (!Directory.Exists(newFP))
//                File.WriteAllText(newFP, response);
//            //Overwrite
//            if (Directory.Exists(newFP))
//            {
//                File.Delete(newFP);
//                File.WriteAllText(newFP, response);
//            }
//            Debug.Log(Response.statuses[0].text);
//        }
        
        
//    }

//}

public class TwitterStuff : MonoBehaviour
{
    void Start()
    {
        Twity.Oauth.consumerKey = "bW3qbrCBWEqQq98iUkOVgyjVY";
        Twity.Oauth.consumerSecret = "ZoLy9FyVocbVHqMsFfLCIFhVeYkma1lMapqV7EydwKsy40XXPA";
        Twity.Oauth.accessToken = "1198943099319439360-piJHmozb3fX2X7fEShxtOcE4zEgrtX";
        Twity.Oauth.accessTokenSecret = "o4Ii4Nj5MSB3KNQwF3GVwBSwjDf2aC49sdKN4420RH6dx";


        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["Name"] = "";
        parameters["screen_name"] = "Oprah";
        //parameters["include_rts"] = "false";

        StartCoroutine(Twity.Client.Get("statuses/user_timeline", parameters, Callback));
    }

    void Callback(bool success, string response)
    {
        string newFP = "./Assets/2019-2020/Watson/" + "TwitterAppOutput" + ".txt";
        Debug.Log(response);
        if (success)
        {
            Debug.Log(response);
            StatusesUserTimelineResponse Response = JsonUtility.FromJson<StatusesUserTimelineResponse>(response);
            //Debug.Log(Response);
            //Tweets TOWU = JsonUtility.FromJson<Tweets>(response);
            //Response.items[0].text;
            if (!Directory.Exists(newFP))
                File.WriteAllText(newFP, response);
            //Overwrite
            if (Directory.Exists(newFP))
            {
                File.Delete(newFP);
                File.WriteAllText(newFP, response);
            }
            //Debug.Log(TOWU.items[0].user.name);
            //Debug.Log(TOWU.items[0].text);
            for (int r = 0; r < Response.items.Length; r++)
            {
                if (Response.items[r].is_quote_status)
                {
                    Debug.Log(Response.items[r].retweeted_status.text);
                    Debug.Log(Response.items[r].retweeted_status.truncated);
                }
                else
                {
                    Debug.Log(Response.items[r].text);
                    Debug.Log(Response.items[r].truncated);
                }
            }
                

        }


    }

}
