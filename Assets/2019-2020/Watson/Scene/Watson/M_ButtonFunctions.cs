using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_ButtonFunctions : MonoBehaviour
{
    // Start Menu
    public void StartBF()
    {
        // If no personality selected; go to creation
        // Scene Transition to Tutorial Screne
    }
    public void OptionsBF()
    {
        // Menu Transition to Options Menu
        GameObject.Find("Start").SetActive(false);
        GameObject.Find("Options").SetActive(true);
    }
    public void QuitBF()
    {
        // Exit Game
    }
    // Options Menu
    public void GameplayTF()
    {
        // Tab Transition to Gameplay Personality Menu
        GameObject.Find("Personality").SetActive(true);
    }
    public void SettingsTF()
    {
        // Tab Transition to Other Settings (typical game settings)
        GameObject.Find("Personality").SetActive(false);
    }
    public void BackBF()
    {
        // Menu Transition to Start Menu
        GameObject.Find("Options").SetActive(false);
        GameObject.Find("Start").SetActive(true);
    }
    // Gameplay Personality Menu
    public void NextBF()
    {
        // Cycle forward through personalities list
    }
    public void PrevBF()
    {
        // Cycle backwards through personalities list
    }
    public void SetSelfBF()
    {
        // select personality for play
    }
    public void NewPersonBF()
    {
        // Create new personality
    }
    public void SaveBF()
    {
        // Save All personalities
    }
    public void SaveAsBF()
    {
        // Save personalities under different folder
    }
    public void LoadBF()
    {
        // Load personalities
    }
    public void DeleteBF()
    {
        // Delete personality
    }
}
