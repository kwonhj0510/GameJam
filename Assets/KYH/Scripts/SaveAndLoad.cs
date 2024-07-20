using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public int LV = 1;
    public int HP = 20;
    public int MAXHP = 20;
    public int Coin;
    public string sceneName;
    public string PlayerName;
    public Vector3 playerPosition;
    public float timeScale = 1;
}

[System.Serializable]
public class SoundVal
{
    public float LocalBGSound = 1f;
    public float LocalSEFSound = 1f;
}

public class SaveAndLoad : MonoBehaviour
{
    public SaveData data = new SaveData();
    public SoundVal sound = new SoundVal();
    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILE_NAME = "/SaveFile.txt";
    private string SAVE_SOUND_FILE_NAME = "/SoundFlie.txt";
    Sound Soundvalval;

    private void Awake()
    {
        Soundvalval = GameObject.Find("Setting_Img").GetComponent<Sound>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Saves/";
        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            if (SceneManager.GetActiveScene().name != "StartScene")
            {
                SceneManager.LoadScene("CreateName");
                Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
            }
        }
        LoadData();
    }

    public void SaveData()
    {
        // ���� �� �̸� ����
        data.sceneName = SceneManager.GetActiveScene().name;

        // �÷��̾� ��ġ ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            data.playerPosition = player.transform.position;
        }

        // ���� ������ ����
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILE_NAME, json);
    }

    public void SaveSoundData()
    {
        string json = JsonUtility.ToJson(sound);
        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_SOUND_FILE_NAME, json);
    }

    public void LoadData()
    {
        // ���� ������ �ε�
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILE_NAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILE_NAME);
            data = JsonUtility.FromJson<SaveData>(loadJson);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = data.playerPosition;


            Debug.Log("�ε� �Ϸ�");
            Debug.Log(loadJson);
        }
        else
        {
            Debug.Log("���̺� ������ �����ϴ�");
        }
        string loadSoundjson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_SOUND_FILE_NAME);
        sound = JsonUtility.FromJson<SoundVal>(loadSoundjson);
        //Soundvalval.slider.value = sound.LocalBGSound;
        //Soundvalval.slider2.value = sound.LocalSEFSound;
    }

    public void ResetData()
    {
        // ������ �ʱ�ȭ
        data = new SaveData();

        Debug.Log("������ ���� �Ϸ�");
        SceneManager.LoadScene("CreateName");
    }

    public void StartBtn()
    {
        // ����� ������ ��ȯ
        SceneManager.LoadScene(data.sceneName);
    }
    private void Update()
    {
        SaveSoundData();
    }
}
