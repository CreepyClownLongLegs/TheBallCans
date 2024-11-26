using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float lifeSpan = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(die());
    }

    private IEnumerator die(){
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }

}
