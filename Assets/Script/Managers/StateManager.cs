using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    static StateManager _instance;
    public static StateManager Instance { get { return _instance; } private set { } }

    static float _relodaingUpgradeValue = 0.2f;
    static float _reloadingTime = 1;
    // static float _luck = 2f;
    static int spearCoin = 32;
    static int powerUpCoin = 8;
    // static int luckCoin = 2;
    [field: SerializeField] public int SpearCount { get; set; }
    int _reloadUpgradeCount = 1;
    [field: SerializeField] public int MyCoin { get; private set; } = 0;
    // [field: SerializeField] public float LuckLevel { get; private set; }


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // �� �̵��ص� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [System.Serializable]
    public class IntEvent : UnityEvent<int, int> { } // < (int powGrade,int spearGrade) > ����
    // Inspector���� ���� ������ UnityEvent
    public IntEvent upGradeRefrash;

    public void UpgradeEvent()
    {
        if (upGradeRefrash != null)
        {
            upGradeRefrash.Invoke(_reloadUpgradeCount, SpearCount);
        }
    }
    public void RegisterListener(UnityAction<int, int> listener)
    {
        if (upGradeRefrash == null)
        {
            upGradeRefrash = new IntEvent();
        }
        upGradeRefrash.AddListener(listener);
    }
    public void UnregisterListener(UnityAction<int, int> listener)
    {
        if (upGradeRefrash != null)
        {
            upGradeRefrash.RemoveListener(listener);
        }

    }

    public bool BuySpear()
    {
        if (UseCoin(spearCoin)) 
        { 
            SpearCount++;
            UpgradeEvent();
            return true;
        }
        return false;
    }
    public int GetSpearCount()
    {
        return SpearCount;
    }
    public bool ReroadingUpgrade()
    {
        if (UseCoin(powerUpCoin)) 
        { 
            _reloadUpgradeCount++;
            UpgradeEvent();
            return true;
        }
        return false;
    }
    //public bool LuckLevelUpgrade()
    //{
    //    if (UseCoin(luckCoin)) 
    //    {
    //        LuckLevel += _luck;
    //        return true;
    //    }
    //    return false;    
    //}
    public float ReloadingTime()
    {
        return _reloadingTime + (_relodaingUpgradeValue * _reloadUpgradeCount); // Spear.cs , isReturn �϶��� �ӵ��� �����ϵ��� �����ؾ��� 
    }
    public int GetReloadUpgradeCount()
    {
        return _reloadUpgradeCount;
    }
    /// <summary>
    /// ���� +1
    /// </summary>
    public void CoinPlus() 
    {
        if( GameManager.Instance.IsGameOver() != true)
        {
            MyCoin++;
        }
    }
    public bool UseCoin(int coin)
    {
        if (MyCoin >= coin)
        {
            MyCoin -= coin;
            ShopUiManager shopUiManager = GameObject.Find("ShopUIManager").GetComponent<ShopUiManager>();
            if (shopUiManager != null) shopUiManager.UpdatePurchase();
            return true;
        }
            return false;
    }
}
