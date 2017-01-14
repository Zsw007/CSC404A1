using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score Instance { get; private set; }

    public int Value = 0;

    private Text _scoreText;

	void Awake ()
	{
	    Instance = this;
	}

    void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        _scoreText.text = "Score: " + Value;
    }
}
