using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer musicMixer, environmentMixer;
    [SerializeField] Slider masterSlider, environmentSlider;

    [SerializeField] AudioSource musicAudio, environmentAudio;

    static AudioManager instance;

    //Dont destroy this object when switching between scenes
    //If there is another one of this object, delete the resulting object.
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (LevelManager.currentLevel == 0) StopAudio();
        //Check if there are keys named Background/Environment, if there is, set the slider value to the value in the key
        if (PlayerPrefs.HasKey("Background")) masterSlider.value = PlayerPrefs.GetFloat("Background");
        musicMixer.SetFloat("Background", masterSlider.value);

        if (PlayerPrefs.HasKey("Environment")) environmentSlider.value = PlayerPrefs.GetFloat("Environment");
        environmentMixer.SetFloat("Environment", environmentSlider.value);
    }

    //Set and save audio levels
    public void SetMasterVolume(float volume)
    {
        musicMixer.SetFloat("Background", volume);
        PlayerPrefs.SetFloat("Background", volume);
    }

    public void SetEnvironmentVolume(float volume)
    {
        environmentMixer.SetFloat("Environment", volume);
        PlayerPrefs.SetFloat("Environment", volume);
    }

    //Play the embedded clip, if there is an already playing clip, stop it, play the new one
    public void PlayAudio(AudioClip clip)
    {
        if (environmentAudio.isPlaying)
        {
            environmentAudio.Stop();
            environmentAudio.clip = clip;
            environmentAudio.PlayOneShot(clip);
        }
        else
        {
            environmentAudio.clip = clip;
            environmentAudio.PlayOneShot(clip);
        }
    }
    //If there is a clip playing, stop it
    public void StopAudio()
    {
        if (environmentAudio.isPlaying)
        {
            environmentAudio.Stop();
            environmentAudio.clip = null;
        }
    }
}
