using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using d4160.Core;

public class NowPlaying : MonoBehaviour {

    public TextComponentWrapper nowPlayingText;
    public UnityEngine.UI.Slider musicLength;


    void Update () {
      
        if (HajiyevMusicManager.instance.CurrentTrackNumber() >= 0) {
            string timeText = SecondsToMS(HajiyevMusicManager.instance.TimeInSeconds());
            string lengthText = SecondsToMS(HajiyevMusicManager.instance.LengthInSeconds());

            nowPlayingText.Text = 
                $"{(HajiyevMusicManager.instance.CurrentTrackNumber() + 1)}. {HajiyevMusicManager.instance.NowPlaying().name} ({timeText}/{lengthText})";

            musicLength.value = HajiyevMusicManager.instance.TimeInSeconds();
            musicLength.maxValue = HajiyevMusicManager.instance.LengthInSeconds();
            
           
        }
        else {
            nowPlayingText.Text = "-----------------";
        }
	}

    string SecondsToMS(float seconds) 
    {
        var min = (int) seconds / 60;
        var sec = (int) seconds % 60;

        if (min < 10 && sec < 10)
        {
            return $"0{min}:0{sec}";
        }

        if (min < 10)
        {
            return $"0{min}:{sec}";
        }

        return sec < 10 ? $"{min}:0{sec}" : $"{min}:{sec}";
    }
}
