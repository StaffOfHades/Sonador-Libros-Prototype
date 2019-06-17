using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Demo : MonoBehaviour {

    private readonly string[] m_animations = { "Pickup","Wave" };
    private Animator[] m_animators;
    [SerializeField] private CameraLogic m_cameraLogic;

    [SerializeField] private RectTransform m_UI;

    public GameObject prefabButton;

    private void Start() {
        m_animators = FindObjectsOfType<Animator>();

        for(int i = 0; i < m_animations.Length; i++) {
            GameObject obj = (GameObject) Instantiate(prefabButton);
            obj.transform.SetParent(m_UI, false);
            Button button = obj.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = m_animations[i];
            button.GetComponentInChildren<PrefabButtonScript>().id = i;
            button.onClick.AddListener(
                () => {
                    int id = button.GetComponentInChildren<PrefabButtonScript>().id;
                    for(int j = 0; j < m_animators.Length; j++) {
                        m_animators[j].SetTrigger(m_animations[id]);
                    }
                }
            );
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            m_cameraLogic.PreviousTarget();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            m_cameraLogic.NextTarget();
        }
    }
}
