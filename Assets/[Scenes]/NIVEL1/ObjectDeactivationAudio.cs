using UnityEngine;

public class ObjectDeactivationAudio : MonoBehaviour
{
    public GameObject targetObject;
    public AudioSource audioSource;

    private bool isTargetActive;

    private void Start()
    {
        isTargetActive = IsObjectActive();
    }

    private void Update()
    {
        if (IsObjectActive() != isTargetActive)
        {
            isTargetActive = IsObjectActive();

            if (!isTargetActive)
            {
                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }

    private bool IsObjectActive()
    {
        if (targetObject == null)
        {
            return false;
        }

        if (targetObject.activeSelf)
        {
            return true;
        }

        // Check if the target object has been destroyed
        var referenceEquals = ReferenceEquals(targetObject, null);
        if (referenceEquals)
        {
            return false;
        }

        return false;
    }
}