using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

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
      UpdateDisplay();

    }


    void OnDestroy(){
    GameEventsManager.instance.miscEvents.onCoinCollected -= UpdateDisplay;
    GameEventsManager.instance.goldEvents.onGoldGained -= UpdateDisplayINT;
    }

    private void UpdateDisplay(){
        expirience = DataPersistenceManager.instance.GetExpirience();
        moneyText.text = money + playerData.money;
        expText.text = exp + expirience + "XP";
    }

    private void UpdateDisplayINT(int money){
        UpdateDisplay();
    }
}
