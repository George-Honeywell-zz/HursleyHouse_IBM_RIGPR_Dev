using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.PersonalityInsights.V3;
using IBM.Watson.PersonalityInsights.V3.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

public class TRANSFER
{
    public string name;
    public string pre_percentile;
    public double percentile;
    public string pre_significant;
    public bool significant;

    public int tracker;
    public TRANSFER()
    {
        name = "";
        pre_percentile = "";
        percentile = 0.0f;
        pre_significant = "";
        significant = false;

        tracker = 0;
    }


}

public class FACET
{
    public string name;
    public double percentile;
    public bool significant;
    public FACET()
    {
        name = "";
        percentile = 0.0f;
        significant = false;
    }
    public FACET(TRANSFER transfer)
    {
        name = transfer.name;
        percentile = transfer.percentile;
        significant = transfer.significant;
    }
}

public class BIGFIVE
{
    public FACET[] children = new FACET[7];
    public int tracker;
    public BIGFIVE()
    {
        for (int f = 0; f < 7; f++)
            children[f] = new FACET();
        tracker = 0;
    }
    ~BIGFIVE()
    {
        children = null;
    }
}

public class PP //Personality Profile
{
    public BIGFIVE[] bigfive = new BIGFIVE[5];
    public TRANSFER transfer;
    public int tracker;
    public string output;
    public string word_count;
    public string processed_language;
    public PP()
    {
        for (int f = 0; f < 5; f++)
            bigfive[f] = new BIGFIVE();
        transfer = new TRANSFER();
        tracker = 0;
        output = "";
        word_count = "";
        processed_language = "";
    }
    ~PP()
    {
        bigfive = null;
    }

}

public class W_SetupAnalyser : MonoBehaviour
{
    Content content;
    private PersonalityInsightsService service;
    public PP pp; //Relevant Profile
    public bool WatsonAnalysisDone = false;

    private void Start()
    {
        Runnable.Run(ActivateService());
    }

    private IEnumerator ActivateService()
    {
        content = new Content()
        {
            ContentItems = new List<ContentItem>()
        };
        LogSystem.InstallDefaultReactors();

        IamAuthenticator authenticator = new IamAuthenticator(apikey: "YnTxEUYrUVRgguKRbtwobHp5f5qQBvLonY_OlDHjtdkC");

        //  Wait for tokendata
        while (!authenticator.CanAuthenticate())
            yield return null;

        service = new PersonalityInsightsService("2019-10-11", authenticator); // 11 Oct
        service.SetServiceUrl("https://gateway-lon.watsonplatform.net/personality-insights/api");
        service.DisableSslVerification = true;

    }

    public async Task ReadJson(string fileLocation)
    {
        char[] buffer;
        using (var reader = new StreamReader(fileLocation))
        {
            buffer = new char[(int)reader.BaseStream.Length];
            await reader.ReadAsync(buffer, 0, (int)reader.BaseStream.Length);
        }
        content.ContentItems.Add(
            new ContentItem()
            {
                Content = new string(buffer),
                Contenttype = ContentItem.ContenttypeValue.TEXT_PLAIN,
                Language = ContentItem.LanguageValue.EN,
            });
        Debug.Log("DONE");
    }

    public void WatsonAnalysis()
    {
        service.Profile(OnProfile, content: content);
    }

    private void OnProfile(DetailedResponse<Profile> response, IBMError error)
    {
        char[] rc = response.Response.ToCharArray(); //response char
        char[] convert = new char[1];
        string output = "";
        bool ri = false; //relavent info
        pp = new PP();
        pp.transfer.tracker = 5;
        for (int f = 0; f < rc.Length; f++)
        {
            if (rc[f] == ':')
                ri = true;
            if (rc[f] == '[')
                ri = false;
            if (rc[f] == ']')
                ri = false;
            if (rc[f] == ',')
            {
                ri = false;
                if (pp.transfer.tracker == 4)
                {
                    pp.transfer.tracker = 0;
                    pp.transfer.percentile = double.Parse(pp.transfer.pre_percentile);
                    if (pp.transfer.pre_significant == "true")
                        pp.transfer.significant = true;
                    if (pp.transfer.pre_significant == "false")
                        pp.transfer.significant = false;
                    pp.bigfive[pp.tracker].children[pp.bigfive[pp.tracker].tracker] = new FACET(pp.transfer);
                    pp.transfer = new TRANSFER();
                    if (pp.bigfive[pp.tracker].tracker == 6)
                        pp.tracker++;
                    else pp.bigfive[pp.tracker].tracker++;
                    if (pp.tracker == 5)
                        f = rc.Length;
                }
                else if (pp.transfer.tracker == 6)
                {
                    pp.transfer.tracker = 0;
                }
                else pp.transfer.tracker++;
            }

            if (ri == true)
            {
                if (rc[f] != '"' && rc[f] != '{' && rc[f] != '}' && rc[f] != ':')
                {
                    convert[0] = rc[f];
                    if (pp.transfer.tracker == 5)
                    {
                        output = new string(convert);
                        pp.word_count += output;
                    }
                    if (pp.transfer.tracker == 6)
                    {
                        output = new string(convert);
                        pp.processed_language += output;
                    }

                    if (pp.transfer.tracker == 0)
                    {

                    }
                    if (pp.transfer.tracker == 1)
                    {
                        output = new string(convert);
                        pp.transfer.name += output;
                    }
                    if (pp.transfer.tracker == 2)
                    {

                    }
                    if (pp.transfer.tracker == 3)
                    {
                        output = new string(convert);
                        pp.transfer.pre_percentile += output;
                    }
                    if (pp.transfer.tracker == 4)
                    {
                        output = new string(convert);
                        pp.transfer.pre_significant += output;
                    }
                }
            }
        }
        WatsonAnalysisDone = true;
    }
}

    

