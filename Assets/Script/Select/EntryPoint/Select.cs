using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public StageListScriptableObjects stageList;
    public GameObject stagePrefab;
    public RectTransform listTransform;
    public const int CONTENT_WIDTH = 300;
    public const int CONTENT_SPACE = 200;

    // Start is called before the first frame update
    void Start()
    {
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
            count++;
        }
        listTransform.localPosition = new Vector3((-count * (CONTENT_WIDTH + CONTENT_SPACE) + CONTENT_SPACE) / 2  + CONTENT_WIDTH / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
