using NUnit.Framework.Internal;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopUiManager : MonoBehaviour
{
    int _myCoin;
    int _spearCount = 0;
    int _powerUpCount = 1;
    public Text coinCount;
    public TMP_Text spearCount;
    public TMP_Text powerUpCount;
    public StateManager stateManager;
    public void HandleValueChanged(int powGrade,int spearGrade)
    {
        _spearCount = spearGrade;
        _powerUpCount = powGrade;
        UpdatePurchase();
    }


    private void Start()
    {
        UpdatePurchase();
    }
    private void OnEnable()
    {
        // StateManager의 이벤트에 리스너 등록
        if (StateManager.Instance != null)
        {
            StateManager.Instance.RegisterListener(HandleValueChanged);
            StateManager.Instance.UpgradeEvent();
        }
    }
    private void OnDisable()
    {
        // StateManager의 이벤트에서 리스너 제거
        if (StateManager.Instance != null)
        {
            StateManager.Instance.UnregisterListener(HandleValueChanged);
        }
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
        spearCount.text = _spearCount + "+";
        powerUpCount.text = _powerUpCount + "+";
    }
}
