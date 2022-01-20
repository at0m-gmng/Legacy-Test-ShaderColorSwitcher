using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class save : MonoBehaviour {
    
    private List<Transform> saveList;
    private SaveTable saveTable;
    private const string SaveTableKey = "SaveTable.saveData"; // имя для сохранения в PlayerPrefs
    public GameObject form;
    public GameObject logo;
     private Button button;
    [SerializeField] InputField inputField; 

    void Awake() {
        form = GameObject.Find("formImage");
        logo = GameObject.Find("LogoImage");
        inputField.characterLimit = 10;
        saveList = new List<Transform>();
        button = GameObject.Find("Next_button").GetComponent<Button>();
        // inputField = transform.Find("InputField").GetComponent<InputField>();
    }

    void Update() {
        if (inputField.text.Length >= 10) {
            inputField.transform.Find("Text").GetComponent<Text>().color = new Color(0.713f, 0.133f, 0.0902f, 1f);
            button.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
            // Debug.Log("asd");
        } else {
            inputField.transform.Find("Text").GetComponent<Text>().color = Color.white;
            button.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
    }

    public void AddAndSave(string name, string colorForm, string colorForm1, string colorForm2, string colorLogo1, string colorLogo2, string colorLogo3) { // Добавление рекорда в таблицу и пересохранение 
        saveTable.AddScore(name, colorForm, colorForm1, colorForm2, colorLogo1, colorLogo2, colorLogo3);
        Debug.Log(JsonUtility.ToJson(saveTable));
        SaveResultsTable();
        // Debug.Log(JsonUtility.ToJson(_scoreTable));
    }

    public void SaveResultsTable() { // сохранение таблицы в PlayerPrefs
        PlayerPrefs.SetString(SaveTableKey, JsonUtility.ToJson(saveTable));
    }

    public void LoadTable() { // загружка таблицы из PlayerPrefs  
        saveTable = JsonUtility.FromJson<SaveTable>(PlayerPrefs.GetString(SaveTableKey));
        saveTable = saveTable ?? new SaveTable(); // если сохранения не было и вернуло NULL, то создаём новую таблицу
    }

    [System.Serializable]
    public class SaveTable {
        public List<ScoreData> ScoresList = new List<ScoreData>();

        public bool IsEmpty => ScoresList.Count == 0;
        public void AddScore(string name, string colorForm, string colorForm1, string colorForm2, string colorLogo1, string colorLogo2, string colorLogo3) {
            // Debug.Log(PlayerPrefs.GetString(ScoreTableSaveKey));
            ScoresList.Add(new ScoreData(name, colorForm, colorForm1, colorForm2, colorLogo1, colorLogo2, colorLogo3));
            // Debug.Log(PlayerPrefs.GetString(ScoreTableSaveKey));
        }
    }

    [System.Serializable]
    public class ScoreData {
        public string Name, ColorForm, ColorForm1, ColorForm2, ColorLogo1, ColorLogo2,  ColorLogo3;  
        public ScoreData(string name, string colorForm, string colorForm1, string colorForm2, string colorLogo1, string colorLogo2, string colorLogo3) {
            Name = name;
            ColorForm = colorForm;
            ColorForm1 = colorForm1;
            ColorForm2 = colorForm2;
            ColorLogo1 = colorLogo1;
            ColorLogo2 = colorLogo2;
            ColorLogo3 = colorLogo3;
        }
    }

    public void SendResults() {
        if (inputField.text.Length <= inputField.characterLimit) {
        LoadTable();
        Debug.Log(inputField.text);
        // form.GetComponent<Image>().material.GetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee")
        AddAndSave(
            inputField.text,
            form.GetComponent<Image>().material.GetColor("_Color1").ToString(),
            form.GetComponent<Image>().material.GetColor("_Color2").ToString(), 
            form.GetComponent<Image>().material.GetColor("_Color3").ToString(),
            logo.GetComponent<Image>().material.GetColor("_ColorLogo1").ToString(),
            logo.GetComponent<Image>().material.GetColor("_ColorLogo2").ToString(),
            logo.GetComponent<Image>().material.GetColor("_ColorLogo3").ToString()
        );
        // Debug.Log(saveTable);
        }
    }
}
