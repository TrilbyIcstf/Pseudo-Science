using System.Collections;
using UnityEngine;

public class Git_Gud : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GitGud());
    }

    private IEnumerator GitGud()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        yield return new WaitForSeconds(12.0f);

#if UNITY_EDITOR
        // Exits Play Mode inside the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Closes the actual built application
            Application.Quit();
#endif
    }
}
