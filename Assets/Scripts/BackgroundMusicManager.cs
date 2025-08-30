using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
  // The single, static instance of this class
  public static BackgroundMusicManager Instance { get; private set; }

  private AudioSource audioSource;

  /// <summary>
  /// Called when the script instance is being loaded.
  /// </summary>
  void Awake()
  {
      // --- Singleton Pattern Implementation ---

      // Check if an instance of this class already exists
      if (Instance == null)
      {
          // If not, set the instance to this object
          Instance = this;

          // Mark this GameObject to not be destroyed when loading new scenes
          DontDestroyOnLoad(gameObject);

          // Get the AudioSource component attached to this GameObject
          audioSource = GetComponent<AudioSource>();
      }
      else
      {
          // If an instance already exists, destroy this new one to avoid duplicates
          Destroy(gameObject);
      }
  }

  // --- Public Methods to Control Music ---

  /// <summary>
  /// Plays the currently assigned audio clip.
  /// </summary>
  public void PlayMusic()
  {
      if (!audioSource.isPlaying)
      {
          audioSource.Play();
      }
  }

  /// <summary>
  /// Pauses the currently playing audio clip.
  /// </summary>
  public void PauseMusic()
  {
      audioSource.Pause();
  }

  /// <summary>
  /// Stops the currently playing audio clip.
  /// </summary>
  public void StopMusic()
  {
      audioSource.Stop();
  }

  /// <summary>
  /// Sets the volume of the background music.
  /// </summary>
  /// <param name="volume">A value between 0.0 and 1.0.</param>
  public void SetVolume(float volume)
  {
      // Clamp the volume value to ensure it's within the valid range [0, 1]
      audioSource.volume = Mathf.Clamp01(volume);
  }
}
