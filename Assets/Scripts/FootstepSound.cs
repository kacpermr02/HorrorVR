using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepSound; // Dźwięk kroków
    public float stepRate = 0.5f; // Czas między krokami (w sekundach)
    private float nextStepTime = 0f; // Czas, w którym można zagrać kolejny krok
    private AudioSource audioSource; // Źródło dźwięku

    private Vector3 lastPosition; // Ostatnia pozycja postaci

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        lastPosition = transform.position; // Zapisz początkową pozycję
    }

    void Update()
    {
        if (IsMoving() && Time.time >= nextStepTime)
        {
            PlayFootstepSound();
            nextStepTime = Time.time + stepRate; // Zaktualizuj czas na kolejny krok
        }

        lastPosition = transform.position; // Aktualizuj ostatnią pozycję
    }

    bool IsMoving()
    {
        // Sprawdź, czy postać się porusza poprzez zmianę pozycji transformacji
        return Vector3.Distance(transform.position, lastPosition) > 0.01f; // Możesz dostosować próg
    }

    void PlayFootstepSound()
    {
        if (footstepSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(footstepSound); // Odtwórz dźwięk kroków
        }
    }
}
