using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConactObject : MonoBehaviour
{
    [SerializeField] private GameObject contactImage;
    [SerializeField] private TextMeshProUGUI name;
    public void CreateContact(Image contactIcon, string contactName)
    {
        this.contactImage.GetComponent<Image>().sprite = contactIcon.sprite;
        this.name.text = contactName;
    }
}
