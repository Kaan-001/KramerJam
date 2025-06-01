using UnityEngine;
using UnityEngine.UI;

public class VoiceSetting : MonoBehaviour
{
    public Sprite soundOnIcon;    // Ses a��k ikonu
    public Sprite soundOffIcon;   // Ses kapal� ikonu
    public Image iconImage;       // Butonun g�rsel k�sm�

    private bool isMuted = false;

    void Start()
    {
        // �nceki ayar� hat�rla
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
