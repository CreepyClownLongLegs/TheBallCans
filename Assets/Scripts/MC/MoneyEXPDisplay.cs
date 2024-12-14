
using Systems.SceneManagement;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    string money = "Dabloons: ";
    string exp = "EXP: ";
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI expText;
    static PlayerData playerData = CoinManager.playerData;

    private int expirience;

    //TODO : UPDATE EXPIRIENCE SOMEWHERE TOO
    void Start()
    {
      GameEventsManager.instance.miscEvents.onCoinCollected += UpdateDisplay;
      GameEventsManager.instance.goldEvents.onGoldGained += UpdateDisplayINT;
      GameEventsManager.instance.goldEvents.onGoldLost += UpdateDisplayINT;
      GameEventsManager.instance.playerEvents.onExperienceGained +=UpdateDisplayINT;
      SceneLoader.newSceneGrouploaded += UpdateDisplay;  
      UpdateDisplay();

    }


    void OnDestroy(){
    GameEventsManager.instance.miscEvents.onCoinCollected -= UpdateDisplay;
    GameEventsManager.instance.goldEvents.onGoldGained -= UpdateDisplayINT;
    GameEventsManager.instance.goldEvents.onGoldLost -= UpdateDisplayINT;
    GameEventsManager.instance.playerEvents.onExperienceGained -=UpdateDisplayINT;
    SceneLoader.newSceneGrouploaded -= UpdateDisplay;  
    }

    private void UpdateDisplay(){
        expirience = DataPersistenceManager.instance.GetGameData().playerExpirience;
        moneyText.text = money + playerData.money;
        expText.text = exp + expirience + "XP";
    }

    private void UpdateDisplayINT(int moneyint){
        expirience = DataPersistenceManager.instance.GetGameData().playerExpirience;
        moneyText.text = money + playerData.money;
        expText.text = exp + expirience + "XP";
    }
}
