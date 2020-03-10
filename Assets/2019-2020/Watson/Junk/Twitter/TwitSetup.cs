using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Twity.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace Twity
{
    //public delegate void TwitterCallback(bool success, string response);
    public class TwitSetup : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Twity.Oauth.consumerKey = "bW3qbrCBWEqQq98iUkOVgyjVY";
            Twity.Oauth.consumerSecret = "ZoLy9FyVocbVHqMsFfLCIFhVeYkma1lMapqV7EydwKsy40XXPA";
            Twity.Oauth.accessToken = "1198943099319439360-piJHmozb3fX2X7fEShxtOcE4zEgrtX";
            Twity.Oauth.accessTokenSecret = "o4Ii4Nj5MSB3KNQwF3GVwBSwjDf2aC49sdKN4420RH6dx";
        }

        public static IEnumerator Get(string APIPath, Dictionary<string, string> APIParams, TwitterCallback callback)
        {
            string REQUEST_URL = "https://api.twitter.com/1.1/" + APIPath + ".json";
            SortedDictionary<string, string> parameters = Helper.ConvertToSortedDictionary(APIParams);

            string requestURL = REQUEST_URL + "?" + Helper.GenerateRequestparams(parameters);
            UnityWebRequest request = UnityWebRequest.Get(requestURL);
            request.SetRequestHeader("ContentType", "application/x-www-form-urlencoded");

            yield return SendRequest(request, parameters, "GET", REQUEST_URL, callback);
        }
        private static IEnumerator SendRequest(UnityWebRequest request, SortedDictionary<string, string> parameters, string method, string requestURL, TwitterCallback callback)
        {
            if (!string.IsNullOrEmpty(Oauth.accessToken))
            {
                request.SetRequestHeader("Authorization", Oauth.GenerateHeaderWithAccessToken(parameters, method, requestURL));
            }
            else if (!string.IsNullOrEmpty(Oauth.bearerToken))
            {
                request.SetRequestHeader("Authorization", "Bearer " + Oauth.bearerToken);
            }

#if UNITY_2017_1
                    yield return request.Send();
#endif
#if UNITY_2017_2_OR_NEWER
            yield return request.SendWebRequest();
#endif

            if (request.isNetworkError)
            {
                callback(false, JsonHelper.ArrayToObject(request.error));
            }
            else
            {
                if (request.responseCode == 200 || request.responseCode == 201)
                {
                    callback(true, JsonHelper.ArrayToObject(request.downloadHandler.text));
                }
                else
                {
                    callback(false, JsonHelper.ArrayToObject(request.downloadHandler.text));
                }
            }
        }

    }
}
