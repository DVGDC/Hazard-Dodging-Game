using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Pack", menuName = "AudioPack")]
public class AudioPack : ScriptableObject
{
	public AudioClip[] clips;
	public float volume;
	public float cooldownTime;

	public void Play()
	{
		AudioManager.Instance.PlayAudio(this);
	}
}