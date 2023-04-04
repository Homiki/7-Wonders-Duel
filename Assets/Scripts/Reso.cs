using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reso : MonoBehaviour
{
//------------PlayerTextPanel---------
    public Text textGold;
    public Text textGlina;
    public Text textWood;
    public Text textStone;
    public Text textGlass;
    public Text textPapirus;
    public Text textPZ;

//-----------EnemyTextPanel---------
    public Text enemyTextGold;
    public Text enemyTextGlina;
    public Text enemyTextWood;
    public Text enemyTextStone;
    public Text enemyTextGlass;
    public Text enemyTextPapirus;
    public Text enemyTextPZ;

//---------TEXTCenyZasobowDlaGracza-------
    public Text glinaTextPrice;
    public Text drewnoTextPrice;
    public Text kamienTextPrice;
    public Text papirusTextPrice;
    public Text szkloTextPrice;

//------------PlayerResources---------
    public int gold;
    public int glina;
    public int wood;
    public int stone;
    public int glass;
    public int papirus;
    public int PZ;
    public int military;
    
//------------EnemyResources---------
    public int enemyGold;
    public int enemyGlina;
    public int enemyWood;
    public int enemyStone;
    public int enemyGlass;
    public int enemyPapirus;
    public int enemyPZ;
    public int enemyMilitary;

//---------CenyZasobow----------
    public int priceGlina;
    public int priceWood;
    public int priceStone;
    public int priceGlass;
    public int pricePapirus;

    public int militaryToken;

    public int playerYellowQuantity;
    public int enemyYellowQuantity;

    public ChangingButton button;

    //public int cardsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        gold = 7;
        glina = 0;
        wood = 0;
        stone = 0;
        glass = 0;
        papirus = 0;
        PZ = 0;
        military = 0;

        enemyGold = 7;
        enemyGlina = 0;
        enemyWood = 0;
        enemyStone = 0;
        enemyGlass = 0;
        enemyPapirus = 0;
        enemyPZ = 0;
        enemyMilitary = 0;

        //cardsRemaining = 20;

        button = GameObject.FindGameObjectWithTag("TurnButton").GetComponent<ChangingButton>();
    }

    // Update is called once per frame
    void Update()
    {
        militaryToken = military - enemyMilitary;

        textGold.text = gold.ToString();
        textGlina.text = glina.ToString();
        textWood.text = wood.ToString();
        textStone.text = stone.ToString();
        textGlass.text = glass.ToString();
        textPapirus.text = papirus.ToString();
        textPZ.text = PZ.ToString();

        enemyTextGold.text = enemyGold.ToString();
        enemyTextGlina.text = enemyGlina.ToString();
        enemyTextWood.text = enemyWood.ToString();
        enemyTextStone.text = enemyStone.ToString();
        enemyTextGlass.text = enemyGlass.ToString();
        enemyTextPapirus.text = enemyPapirus.ToString();
        enemyTextPZ.text = enemyPZ.ToString();

        if(button.isYourTurn == true && button.isEnemyTurn == false)
        {
            glinaTextPrice.text = (2 + enemyGlina).ToString();
            drewnoTextPrice.text = (2 + enemyWood).ToString();
            kamienTextPrice.text = (2 + enemyStone).ToString();
            papirusTextPrice.text = (2 + enemyPapirus).ToString();
            szkloTextPrice.text = (2 + enemyGlass).ToString();

            priceGlina = (2 + enemyGlina);
            priceWood = (2 + enemyWood);
            priceStone = (2 + enemyStone);
            priceGlass = (2 + enemyGlass);
            pricePapirus = (2 + enemyPapirus);

        }
        else if(button.isYourTurn == false && button.isEnemyTurn == true)
        {
            glinaTextPrice.text = (2 + glina).ToString();
            drewnoTextPrice.text = (2 + wood).ToString();
            kamienTextPrice.text = (2 + stone).ToString();
            papirusTextPrice.text = (2 + papirus).ToString();
            szkloTextPrice.text = (2 + glass).ToString();

            priceGlina = (2 + glina);
            priceWood = (2 + wood);
            priceStone = (2 + stone);
            priceGlass = (2 + glass);
            pricePapirus = (2 + papirus);

        }
        if (gold <= 0)
        {
            gold = 0;
        }
        if (enemyGold <= 0)
        {
            enemyGold = 0;
        }


    }
}
