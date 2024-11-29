using UnityEngine;
using UnityEngine.UI;

public class SoundToggleController : MonoBehaviour
{
    [SerializeField] private GameObject soundOnButton; // Reference to the SoundOn button
    [SerializeField] private GameObject soundOffButton; // Reference to the SoundOff button
    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource

    private void Start()
    {
        // Set initial state
        soundOnButton.SetActive(!audioSource.mute); // Show SoundOn if not muted
        soundOffButton.SetActive(audioSource.mute);  // Show SoundOff if muted
    }

    public void ToggleSoundOn()
    {
        audioSource.mute = true; // Mute the sound immediately
        soundOnButton.SetActive(false); // Hide SoundOn button
        soundOffButton.SetActive(true); // Show SoundOff button
    }

    public void ToggleSoundOff()
    {
        audioSource.mute = false; // Unmute the sound
        soundOnButton.SetActive(true); // Show SoundOn button
        soundOffButton.SetActive(false); // Hide SoundOff button
    }
}
