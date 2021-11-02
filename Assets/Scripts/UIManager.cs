using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _coinCountText;

    private int _collectibleCount = 0;

    private void Start()
    {
        _coinCountText = transform.Find("Coin_Count_text").GetComponent<Text>();
        if (_coinCountText == null)
            Debug.LogError("Coin Count text is not initialised in UI Manager");

        _collectibleCount = GameObject.FindObjectsOfType<CoinCollectible>().Length;
        UpdateCoinCount(0);
    }

    public void UpdateCoinCount(int coinCount)
    {
        _coinCountText.text = "Coins collected: " + coinCount + "/" + _collectibleCount;
    }
}
