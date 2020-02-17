using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
      }
    }
}
