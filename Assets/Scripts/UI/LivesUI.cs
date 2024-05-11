using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class LivesUI : MonoBehaviour
{

    public List<LifeSlot> livesSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife()
    {
        var life = livesSlots.First();
        life.gameObject.SetActive(false);
        livesSlots.Remove(life);
    }
}
