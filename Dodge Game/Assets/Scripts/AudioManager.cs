using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	#region Singleton
	public static AudioManager Instance { get; private set; }

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		// If there is an instance, and it's not me, delete myself.

		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}
	#endregion

	private List<AudioPack> activeAudioPacks = new List<AudioPack>();
	private HashSet<AudioSource> audioSources = new HashSet<AudioSource>();

	private void Start()
	{
		audioSources = GetComponents<AudioSource>().ToHashSet();
	}

	public void PlayAudio(AudioPack audioPack)
	{
		// if AudioPack isn't on cooldown
		if (!activeAudioPacks.Contains(audioPack))
		{
			// get and play random clip from Audiopack
			activeAudioPacks.Add(audioPack);
			StartCoroutine(AudioCooldown(audioPack));
			AudioClip clip = audioPack.clips[Random.Range(0, audioPack.clips.Length)];
			GetSourceAndPlayAudio(clip, audioPack.volume);
		}
	}

	private void GetSourceAndPlayAudio(AudioClip clip, float volume)
	{
		// iterate through AudioSources
		foreach (AudioSource audioSource in audioSources)
		{
			// play sound and exit method if inactive AudioSource is found
			if (!audioSource.isPlaying)
			{
				audioSource.volume = volume;
				audioSource.PlayOneShot(clip);
				return;
			}
		}
		// if no AudioSources are inactive, add a new one and play the sound
		AudioSource addedSource = gameObject.AddComponent<AudioSource>();
		audioSources.Add(addedSource);
		addedSource.volume = volume;
		addedSource.PlayOneShot(clip);
	}

	private IEnumerator AudioCooldown(AudioPack audioPack)
	{
		yield return new WaitForSeconds(audioPack.cooldownTime);
		activeAudioPacks.Remove(audioPack);
	}


}
