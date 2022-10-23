using UnityEngine;

public class GameData : MonoBehaviour
{
    //This is the static script we will use to transfer data between the main menu and the game, and vice versa.
    //Values such as the player's gun and the currency are written here.
    //Essentially, reading and writing.

    //Gun data
    public static string gunName;
    public static int ammoCount;
    public static float damage, range, reloadDuration, fireRate, tempAmmo;
    public static GunStats.Rarity gunRarity;
    public static int currency;

    //Misc Data
    public static Color gunColour;
    public static float GameSenstivity;
    public static int gainedCurrency;
    public static int kills;
    public static bool isPlayerDead;



}
