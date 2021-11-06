using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _coinCountText, _deathCountText, _restartText;
    private GameObject _gameCompletePanel;

    private int _allCollectibleCount = 0;

    private void Start()
    {
        _coinCountText = transform.Find("Coin_Count_text").GetComponent<Text>();
        if (_coinCountText == null)
            Debug.LogError("Coin Count text was not initialised in UI Manager");

        _deathCountText = transform.Find("Death_Count_text").GetComponent<Text>();
        if (_deathCountText == null)
            Debug.LogError("Death Count text was not initialised in UI Manager");

        _restartText = transform.Find("Restart_Instructions_text").GetComponent<Text>();
        if (_restartText == null)
            Debug.LogError("Restart Instructions text was not initialised in UI Manager");

        _gameCompletePanel = transform.Find("Game_Complete_panel").gameObject;
        if (_gameCompletePanel == null)
            Debug.LogError("Game complete panel was not initialised in UI Manager");

        _allCollectibleCount = GameObject.FindObjectsOfType<CoinCollectible>().Length;
        UpdateCoinCount(0);
    }

    public void UpdateCoinCount(int coinCount)
    {
        _coinCountText.text = "Coins collected: " + coinCount + "/" + _allCollectibleCount;
    }

    public void UpdateDeathCount(int deathCount)
    {
        _deathCountText.text = "Deaths: " + deathCount;
    }

    public void GameCompleteUIUpdate(int coinsCollected, int deaths)
    {
        bool failed = false;
        _coinCountText.fontStyle = FontStyle.Bold;
        if (coinsCollected < _allCollectibleCount)
        {
            failed = true;
            _coinCountText.color = Color.magenta;
            _coinCountText.text += " (Collect all coins!)";
        }

        _deathCountText.fontStyle = FontStyle.Bold;
        if (deaths > 3)
        {
            failed = true;
            _deathCountText.color = Color.magenta;
            _deathCountText.text += " (Deaths are more than 3)";
        }

        if(!failed)
        {
            //Enable game complete text
            _gameCompletePanel.SetActive(true);
        }

        _restartText.gameObject.SetActive(true);
    }
}
