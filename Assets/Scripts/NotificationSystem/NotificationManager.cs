using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : PersistentSingleton<NotificationManager>
{
    [SerializeField] GameObject notificationPanel;
    [SerializeField] float fadeOutTime = 0.5f;
    [SerializeField] private TextMeshProUGUI notificationText;
    private RawImage visual;
    private Color colorOfPanel;
    private Color colorOfText;
    private Coroutine notificationCoroutine;

    // Update is called once per frame
    void Awake()
    {
        notificationPanel.SetActive(false);
        visual = notificationPanel.gameObject.GetComponent<RawImage>();
        colorOfText = notificationText.color;
    }

    private void changeColor(NotificationPanelColor notificationPanelColor){
        switch(notificationPanelColor){
            case NotificationPanelColor.SUCCSES:
                this.colorOfPanel = Color.green;
                visual.color = this.colorOfPanel;
                notificationText.color = this.colorOfText;
                break;
            case NotificationPanelColor.INFO:
                this.colorOfPanel = Color.cyan;
                visual.color = this.colorOfPanel;
                notificationText.color = this.colorOfText;
                break;
            case NotificationPanelColor.WARNING:
                this.colorOfPanel = Color.red;
                visual.color = this.colorOfPanel;
                notificationText.color = this.colorOfText;
                break;
            default: 
                this.colorOfPanel = Color.white;
                visual.color = this.colorOfPanel;
                notificationText.color = this.colorOfText;
                break;
        }

    }

    public void showNotification(String text, NotificationPanelColor notificationPanelColor){
        notificationText.text =  text;
        notificationPanel.SetActive(true);
        if(notificationCoroutine != null){
            StopCoroutine(notificationCoroutine);
        }
        changeColor(notificationPanelColor);  
        notificationCoroutine = StartCoroutine(notification(notificationPanelColor));
    }

    public IEnumerator notification(NotificationPanelColor notificationPanelColor){
        yield return new WaitForSeconds(2f);   
        float t = 0;
        while(t < fadeOutTime){
            t+=Time.unscaledDeltaTime;
            visual.color = new Color(
                colorOfPanel.r,
                colorOfPanel.g,
                colorOfPanel.b,
                Mathf.Lerp(1f, 0f, t/fadeOutTime)
            );
            notificationText.color = new Color(
                colorOfText.r,
                colorOfText.g,
                colorOfText.b,
                Mathf.Lerp(1f, 0f, t/fadeOutTime)
            );
            yield return null;  
        }
        notificationPanel.SetActive(false);
    }
}

public enum NotificationPanelColor{
    SUCCSES,
    INFO,
    WARNING
}
