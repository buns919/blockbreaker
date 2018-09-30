using UnityEngine;

public class GameStatus : MonoBehaviour {

    [SerializeField] bool isAutoPlayEnabled = false;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

	// Use this for initialization
	void Start () {
		if (isAutoPlayEnabled) {
            gameSpeed = gameSpeed * 5;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}

    /**
     * You can next canvas underneath this game obj to persist it between levels
     */
    void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool IsAutoPlayEnabled() {
        return isAutoPlayEnabled;
    }
}
