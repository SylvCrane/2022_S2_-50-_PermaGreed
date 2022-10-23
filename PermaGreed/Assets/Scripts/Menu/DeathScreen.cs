using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public TMP_Text KillsBox;
    public TMP_Text GainedBox;
    public GameObject menuScreen;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (GameData.isPlayerDead)
        {
            //Reading data into the death screen
            KillsBox.text = GameData.kills + "";
            GainedBox.text = "$" + GameData.gainedCurrency;
            menuScreen.SetActive(false);
            deathScreen.SetActive(true);
        }
    }
}
