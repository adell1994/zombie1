using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public StageListScriptableObjects stageList;
    public GameObject stagePrefab;
    public RectTransform listTransform;
    public AudioSource audioSource;
    public const int CONTENT_WIDTH = 300;
    public const int CONTENT_SPACE = 200;
    public AudioClip selectSE;
    public bool isButtonPush = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        int count = 0;
        foreach (StageScriptableObjects stage in stageList.StageList)
        {
            GameObject obj = Instantiate(stagePrefab,listTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(count * (CONTENT_WIDTH + CONTENT_SPACE), 0);
            GameObject label = obj.transform.Find("Label").gameObject;
            TextMeshProUGUI tmp = label.GetComponent<TextMeshProUGUI>();
            tmp.text = stage.name;
            Sprite sp = Resources.Load<Sprite>(stage.thumbnail);
            Image img = obj.GetComponent<Image>();
            img.sprite = sp;
            int id = stage.id;
            obj.GetComponent<Button>().onClick.AddListener(() => ChengeScene(id));

            count++;
        }
        listTransform.localPosition = new Vector3((-count * (CONTENT_WIDTH + CONTENT_SPACE) + CONTENT_SPACE) / 2  + CONTENT_WIDTH / 2, 0);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChengeScene(int id)
    {
        if(id == 1)
        {
            if (isButtonPush == true)
            {
                return;
            }
            isButtonPush = true;
            audioSource.PlayOneShot(selectSE);
            SceneManager.LoadScene("Port");
        }
        if (id == 2)
        {
            if (isButtonPush == true)
            {
                return;
            }
            isButtonPush = true;
            audioSource.PlayOneShot(selectSE);
            SceneManager.LoadScene("Village");
        }
        if (id == 3)
        {
            if (isButtonPush == true)
            {
                return;
            }
            isButtonPush = true;
            audioSource.PlayOneShot(selectSE);
            SceneManager.LoadScene("Stage3");
        }
    }
    public void PushStartButton()
    {
        if (isButtonPush == true)
        {
            return;
        }
        isButtonPush = true;
        audioSource.PlayOneShot(selectSE);
        Invoke("ChengeScene", 2.5f);
    }
}
