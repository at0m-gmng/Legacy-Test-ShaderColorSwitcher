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

    [SerializeField] InputField inputField; 

    void Awake() {
        form = GameObject.Find("formImage");
        logo = GameObject.Find("LogoImage");
        saveList = new List<Transform>();
        // inputField = transform.Find("InputField").GetComponent<InputField>();
    }

    public void AddAndSave(string name, string colorForm, string colorLogo) { // Добавление рекорда в таблицу и пересохранение 
        saveTable.AddScore(name, colorForm, colorLogo);
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
        public void AddScore(string name, string colorForm, string colorLogo) {
            // Debug.Log(PlayerPrefs.GetString(ScoreTableSaveKey));
            ScoresList.Add(new ScoreData(name, colorForm, colorLogo));
            // Debug.Log(PlayerPrefs.GetString(ScoreTableSaveKey));
        }
    }

    [System.Serializable]
    public class ScoreData {
        public string Name;
        public string ColorForm;
        public string ColorLogo; 
        public ScoreData(string name, string colorForm, string colorLogo) {
            Name = name;
            ColorForm = colorForm;
            ColorLogo = colorLogo;
        }
    }

    public void SendResults() {
        LoadTable();
        Debug.Log(inputField.text);
        // form.GetComponent<Image>().material.GetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee")
        AddAndSave(
            form.GetComponent<Image>().material.GetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee").ToString(), 
            logo.GetComponent<Image>().material.GetColor("Color_000bb06fd1f649eaa94ec8e769a24fec").ToString(), 
            inputField.text
        );
        // Debug.Log(saveTable);
    }
}
