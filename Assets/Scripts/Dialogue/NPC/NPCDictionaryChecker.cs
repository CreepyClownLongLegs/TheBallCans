using UnityEngine;

public class NPCDictionaryChecker : MonoBehaviour
{
    bool showNPC = true;
    public string ID = "";

    void Start(){
        this.ID = this.name;
        Loaddata();
    }
    public void Loaddata()
    {
        if(EpisodeManager.instance.npcs.ContainsKey(ID)){
            EpisodeManager.instance.npcs.TryGetValue(ID, out showNPC);
        }

        if(!showNPC){
            var children = gameObject.GetComponentInChildren<Transform>(true);
            foreach(Transform child in children){
                child.gameObject.SetActive(false);
            }
        }
    }


}
