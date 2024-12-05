using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class QuestLogUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private NewsLogUi newsLogUi;
    [SerializeField] private QuestLogScrollingList scrollingList;
    [SerializeField] private TextMeshProUGUI questDisplayNameText;
    [SerializeField] private TextMeshProUGUI questStatusText;
    [SerializeField] private TextMeshProUGUI goldRewardsText;
    [SerializeField] private TextMeshProUGUI experienceRewardsText;

    private Button firstSelectedButton;
    private void Start()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        ShowUI();
    }
    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }
    private void QuestLogTogglePressed()
    {
        if (contentParent.activeInHierarchy)
        {
            HideUI();
        }
        else
        {
            ShowUI();
        }
    }

    public void ShowUI()
    {
        contentParent.SetActive(true);
        newsLogUi.HideNewsLogUI();
        GameEventsManager.instance.playerEvents.DisablePlayerMovement();
        // note - this needs to happen after the content parent is set active,
        // or else the onSelectAction won't work as expected
        if (firstSelectedButton != null)
        {
            firstSelectedButton.Select();
        }
    }

    public void HideUI()
    {
        contentParent.SetActive(false);
        GameEventsManager.instance.playerEvents.EnablePlayerMovement();
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void QuestStateChange(Quest quest)
    {
        // add the button to the scrolling list if not already added
        QuestLogButton questLogButton = scrollingList.CreateButtonIfNotExists(quest, () => {
            SetQuestLogInfo(quest);
        });

        // initialize the first selected button if not already so that it's
        // always the top button
        if (firstSelectedButton == null)
        {
            firstSelectedButton = questLogButton.button;
        }

        // set the button color based on quest state
        questLogButton.SetState(quest.state);
    }

    private void SetQuestLogInfo(Quest quest)
    {
        // quest name
        questDisplayNameText.text = quest.info.displayName;

        // status
        questStatusText.text = quest.info.description;

        // rewards
        goldRewardsText.text = quest.info.coins + " Gold";
        experienceRewardsText.text = quest.info.playerExpirience + " XP";
    }
}