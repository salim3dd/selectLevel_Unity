using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{

    int Level;

    void Start()
    {
        Level = PlayerPrefs.GetInt("Level", 12);
        

        for (int i = 1; i <= 50; i++) {

            int Star = PlayerPrefs.GetInt("Level_star", 0);
            string sprite = "Star_"+ Star;
            
            int lv = 1;
            bool click = false;          
            
            if (Level >= i-1)
            {
                lv = i;
                click = true;
            }
            else {
                sprite = "level_lock";
            }

            if (Level == i-1) {
                lv = i;
                click = true;
                sprite = "level_open";
            }

            GameObject Pbtn = Instantiate(Resources.Load("Prefab/PBTN") as GameObject);
            Pbtn.transform.SetParent(GameObject.FindGameObjectWithTag("Panel_level").transform, false);
            Pbtn.transform.Find("BTN").GetComponent<Image>().sprite = Resources.Load<Sprite>(sprite);
            Pbtn.transform.Find("BTN/Text").GetComponent<Text>().text = i.ToString();
            Pbtn.transform.Find("BTN").GetComponent<Button>().onClick.AddListener(() => BTN_Click(lv));
            Pbtn.transform.Find("BTN").GetComponent<Button>().interactable = click;



        }



    }

    private void BTN_Click(int lv) {

        SceneManager.LoadScene("Level_"+lv);

    }



    void Update()
    {
        
    }
}
