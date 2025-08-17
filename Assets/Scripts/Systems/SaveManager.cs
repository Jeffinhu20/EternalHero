using UnityEngine;
using System;

public class SaveManager : MonoBehaviour
{
    const string LAST_PLAY_KEY = "last_play";

    void OnApplicationPause(bool paused)
    {
        if (paused) PlayerPrefs.SetString(LAST_PLAY_KEY, DateTime.UtcNow.ToString("o"));
        else GrantOfflineRewards();
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetString(LAST_PLAY_KEY, DateTime.UtcNow.ToString("o"));
    }

    void GrantOfflineRewards()
    {
        if (!PlayerPrefs.HasKey(LAST_PLAY_KEY)) return;
        DateTime last = DateTime.Parse(PlayerPrefs.GetString(LAST_PLAY_KEY), null, System.Globalization.DateTimeStyles.RoundtripKind);
        double hours = (DateTime.UtcNow - last).TotalHours;
        double capped = Math.Min(hours, 8);
        long gold = (long)(capped * 120);
        Currency.GiveGold(gold);
        Debug.Log($"Offline rewards: {gold} gold for {capped:F1}h");
    }
}
