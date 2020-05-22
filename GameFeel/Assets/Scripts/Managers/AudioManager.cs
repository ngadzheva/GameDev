using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioSource punchSound = null;
    [SerializeField] private AudioSource punchedSound = null;
    [SerializeField] private AudioSource deathSound = null;

    private static AudioManager instance;

    private void Start() {
      instance = this;
    }

    public static void PlayPunchSound() {
      instance.punchSound.Play();
    }

    public static void PlayPunchedSound() {
      instance.punchedSound.Play();
    }

    public static void PlayDeathSound() {
      instance.deathSound.Play();
    }
}
