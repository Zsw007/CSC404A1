using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    public static Lives Instance { get; private set; }

    public int Value = 3;

    private Text _livesText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _livesText = GameObject.Find("LivesText").GetComponent<Text>();
    }

    void Update()
    {
        _livesText.text = "Lives: " + Value;
    }
}
