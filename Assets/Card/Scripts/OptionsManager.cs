using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    private AudioManager audioManager;


    public bool isMuted = false;
    void Start()
    {
        audioManager = GameManager.Instance.AudioManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
