using NUnit.Framework.Internal;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopUiManager : MonoBehaviour
{
    int _myCoin;
    int _spearCount;
    int _powerUpCount;
    public Text coinCount;
    public TMP_Text spearCount;
    public TMP_Text powerUpCount;


    private void Start()
    {
        UpdatePurchase();
    }

    public void GoStart()
    {
        //SceneManager.LoadScene(0);
        GameManager.Instance.GoInGameScene();
    }

    public void UpdatePurchase()
    {
        _myCoin = StateManager.Instance.MyCoin;
        coinCount.text = "Sharksfin : " + _myCoin.ToString();
        _spearCount = StateManager.Instance.GetSpearCount() +1;
        spearCount.text = _spearCount + "+";
        _powerUpCount = StateManager.Instance.GetReloadUpgradeCount();
        powerUpCount.text = _powerUpCount + "+";
    }
}
