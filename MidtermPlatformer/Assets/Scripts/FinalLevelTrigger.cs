using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalLevelTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public machineTracker machineTracker;
    private Collider2D col;
    public TextMeshProUGUI runText;

    void Start()
    {
        col = this.gameObject.GetComponent<Collider2D>();
        col.enabled = false;
        runText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(machineTracker.machineAmount == 0)
        {
            col.enabled = true;
            runText.text = "Run! -->";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
