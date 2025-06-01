using UnityEngine;
using UnityEngine.UI;

public class VoiceSetting : MonoBehaviour
{
    public Sprite soundOnIcon;    // Ses açýk ikonu
    public Sprite soundOffIcon;   // Ses kapalý ikonu
    public Image iconImage;       // Butonun görsel kýsmý

    private bool isMuted = false;

    void Start()
    {
        // Önceki ayarý hatýrla
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        UpdateSoundState();
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        UpdateSoundState();
    }

    private void UpdateSoundState()
    {
        AudioListener.volume = isMuted ? 0 : 1;
        iconImage.sprite = isMuted ? soundOffIcon : soundOnIcon;
    }
}
