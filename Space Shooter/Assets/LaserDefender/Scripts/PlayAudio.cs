using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    Transform cameraTransform;

    [SerializeField] AudioClip deathSFX;
    [SerializeField][Range(0, 1)] float deathSoundVolume = 0.7f;

    [SerializeField] AudioClip shootSFX;
    [SerializeField][Range(0, 1)] float shootingSoundVolume = 0.25f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;    
    }

    public void PlayShootingSound()
    {
        AudioSource.PlayClipAtPoint(shootSFX, cameraTransform.position, shootingSoundVolume);
    }

    public void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSFX, cameraTransform.position, deathSoundVolume);
    }
}