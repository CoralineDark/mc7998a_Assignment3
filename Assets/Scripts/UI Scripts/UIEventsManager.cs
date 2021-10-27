using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIEventsManager : MonoBehaviour
{
    
    [SerializeField]
    private List<GameObject> stars; 
    private int numStars; 
    private int numCoins; 
    [SerializeField]
    private GameObject winScreen; 
    [SerializeField]
    private Text coinText; 
    // Start is called before the first frame update
    void Start()
    {
        numStars = 0; 
        numCoins = 0;
        coinText.text = "" + numCoins; 
    }

    // Update is called once per frame
    void Update()
    { 
         
    }

    private void OnEnable() { 
        StarCollectable.PickupStar += PickupStar;  
        CoinObject.PickupCoin += PickupCoin;                        
    }

    private void OnDisable() {
        StarCollectable.PickupStar -= PickupStar; 
        CoinObject.PickupCoin -= PickupCoin;
    }

    private void PickupStar() { 
        numStars++;
        for (int i = 0; i < numStars; i++) {
            stars[i].SetActive(true); 
        }
        if (numStars == 3) {
            winScreen.SetActive(true);
        }
    }

    private void PickupCoin() { 
        numCoins++; 
        coinText.text = "" + numCoins;
    } 
}
