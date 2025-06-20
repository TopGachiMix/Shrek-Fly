using UnityEngine;
using UnityEngine.UI;


public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _lousePanel;
    [SerializeField] private GameObject _scores;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private GameObject _pauseManage;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverScoreText;
    [SerializeField] private Text _gameOverBestTextScore;

    
    [SerializeField] private int _score;
    [SerializeField] private int _bestScore;
    [SerializeField] private float _jumpForce;
    private bool _isClick = false;

    private Animator _anim;
    private Rigidbody2D _rigidBody2D;





    private void Start()
    {   
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _rigidBody2D.isKinematic = true;

        _scoreText.text = $"{_score}";
        _bestScore = PlayerPrefs.GetInt("BestScore");

        Time.timeScale = 1f;
        
    }

    private void Update()
    {   
        if (_score >= _bestScore)
        {
            _bestScore = _score;
        }

        _scoreText.text = $"{_score}";  
        _gameOverScoreText.text = $"{_score}";
        _gameOverBestTextScore.text = $"{_bestScore}";

        PlayerPrefs.SetInt("BestScore" , _bestScore);
        PlayerPrefs.Save();

        if (Input.GetMouseButtonDown(0) && _isClick == true  || Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody2D.velocity = Vector2.up * _jumpForce;
            _mainCanvas.SetActive(false);
            _gameCanvas.SetActive(true);
            _anim.SetTrigger("_isFly");
            _rigidBody2D.isKinematic = false;
            _spawn.SetActive(true);
            _pauseManage.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("+ 1 очко");
            _score++;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pipe")
        {
            Debug.Log("Game Over");
            _lousePanel.SetActive(true);
            _scores.SetActive(false);
            Time.timeScale = 0f;
            _pauseManage.SetActive(false);
            Destroy(gameObject);

        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
    }

    public void Onclick()
    {
        _isClick = true;
    }
}
