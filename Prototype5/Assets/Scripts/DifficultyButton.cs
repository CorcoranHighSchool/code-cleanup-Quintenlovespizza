using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    [SerializeField] private int difficulty;
    private const string setdifficulty = setdifficulty 
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
