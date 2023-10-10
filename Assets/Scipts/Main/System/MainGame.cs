using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField] private AppStart _appStart;
    [SerializeField] private Merger _merger;
    [SerializeField] private ScoreController _scoreController;

    private ScoreModel _scoreModel;
    private void Start()
    {
        _appStart.StartGame();
        _scoreModel = new ScoreModel();
        _scoreModel.score = _appStart.SaveData.scoreModel.score;
        UpdateScore(0);
        _merger.OnMerged += UpdateScore;
    }
    private void UpdateScore(int score)
    {
        _scoreModel.score += score;
        _scoreController.UpdateScore(_scoreModel.score);
    }
    public int GetScore()
    {
        return _scoreModel.score;
    }
}
