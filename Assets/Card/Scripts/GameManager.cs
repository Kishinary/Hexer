using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int playerHealth = 5;
    private int playerXP;
    private int difficulty = 1;
    public static GameManager Instance { get; private set; }
    public OptionsManager OptionsManager { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public DeckManager DeckManager { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManager()
    {
        OptionsManager = GetComponentInChildren<OptionsManager>();
        AudioManager = GetComponentInChildren<AudioManager>();
        DeckManager = GetComponentInChildren<DeckManager>();
        if (OptionsManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/OptionsManager");
            if (prefab == null)
            {
                Debug.Log($"Error: OptionsManager prefab not found in Resources/Prefabs.");
            }
            else
            {
                Instantiate(prefab,transform.position, Quaternion.identity,transform);
                OptionsManager = GetComponentInChildren<OptionsManager>();

            }
        }
        if (AudioManager == null)
        {
            GameObject prefab1 = Resources.Load<GameObject>("Prefabs/AudioManager");
            if (prefab1 == null)
            {
                Debug.Log($"Error: OptionsManager prefab not found in Resources/Prefabs.");
            }
            else
            {
                Instantiate(prefab1, transform.position, Quaternion.identity, transform);
                AudioManager = GetComponentInChildren<AudioManager>();

            }
        }
        if (DeckManager == null)
        {
            GameObject prefab2 = Resources.Load<GameObject>("Prefabs/DeckManager");
            if (prefab2 == null)
            {
                Debug.Log($"Error: OptionsManager prefab not found in Resources/Prefabs.");
            }
            else
            {
                Instantiate(prefab2, transform.position, Quaternion.identity, transform);
                DeckManager = GetComponentInChildren<DeckManager>();

            }
        }
    }



    public int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }
    public int PlayerXP
    {
        get { return playerXP; }
        set { playerXP = value; }
    }
    public int Difficulty
    {
        get { return difficulty; }
        set { difficulty = value; }
    }
}
