using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Twity.Helpers;
using UnityEngine;
using UnityEngine.Networking;
using System.Security.Cryptography;

public class Oauth
{

    #region Tokens
    public static string consumerKey { get; set; }
    public static string consumerSecret { get; set; }
    public static string accessToken { get; set; }
    public static string accessTokenSecret { get; set; }

    public static string bearerToken { get; set; }

    public static string requestToken { get; set; }
    public static string requestTokenSecret { get; set; }
    public static string authorizeURL { get; set; }
    #endregion

    #region Public Method
    public static string GenerateHeaderWithAccessToken(SortedDictionary<string, string> parameters, string requestMethod, string requestURL)
    {
        string signature = GenerateSignature(parameters, requestMethod, requestURL);

        StringBuilder requestParamsString = new StringBuilder();
        foreach (KeyValuePair<string, string> param in parameters)
        {
            requestParamsString.Append(String.Format("{0}=\"{1}\",", Helper.UrlEncode(param.Key), Helper.UrlEncode(param.Value)));
        }

        string authHeader = "OAuth realm=\"Twitter API\",";
        string requestSignature = String.Format("oauth_signature=\"{0}\"", Helper.UrlEncode(signature));
        authHeader += requestParamsString.ToString() + requestSignature;
        return authHeader;
    }
    #endregion

    #region HelperMethods
    private static string GenerateSignature(SortedDictionary<string, string> parameters, string requestMethod, string requestURL)
    {
        string oauth_token = "";
        string oauth_token_secret = "";
        if (!string.IsNullOrEmpty(accessToken))
        {
            oauth_token = accessToken;
            oauth_token_secret = accessTokenSecret;
        }
        else if (!string.IsNullOrEmpty(requestToken))
        {
            oauth_token = requestToken;
            oauth_token_secret = requestTokenSecret;
        }

        AddDefaultOauthParams(parameters, consumerKey);
        parameters.Add("oauth_token", oauth_token);

        StringBuilder paramString = new StringBuilder();
        foreach (KeyValuePair<string, string> param in parameters)
        {
            paramString.Append(Helper.UrlEncode(param.Key) + "=" + Helper.UrlEncode(param.Value) + "&");
        }
        paramString.Length -= 1; // Remove "&" at the last of string


        string requestHeader = Helper.UrlEncode(requestMethod) + "&" + Helper.UrlEncode(requestURL);
        string signatureData = requestHeader + "&" + Helper.UrlEncode(paramString.ToString());

        string signatureKey = Helper.UrlEncode(consumerSecret) + "&" + Helper.UrlEncode(oauth_token_secret);
        HMACSHA1 hmacsha1 = new HMACSHA1(Encoding.ASCII.GetBytes(signatureKey));
        byte[] signatureBytes = hmacsha1.ComputeHash(Encoding.ASCII.GetBytes(signatureData));
        return Convert.ToBase64String(signatureBytes);
    }

    private static void AddDefaultOauthParams(SortedDictionary<string, string> parameters, string consumerKey)
    {
        parameters.Add("oauth_consumer_key", consumerKey);
        parameters.Add("oauth_signature_method", "HMAC-SHA1");
        parameters.Add("oauth_timestamp", GenerateTimeStamp());
        parameters.Add("oauth_nonce", GenerateNonce());
        parameters.Add("oauth_version", "1.0");
    }

    private static string GenerateTimeStamp()
    {
        DateTimeOffset baseDt = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        return ((DateTimeOffset.Now - baseDt).Ticks / 10000000).ToString();
    }

    private static string GenerateNonce()
    {
        return Guid.NewGuid().ToString("N");
    }

    #endregion

}

public class Handling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public delegate void TwitterCallback(bool success, string response);

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
