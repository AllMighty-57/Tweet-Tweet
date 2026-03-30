using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private GameObject[] _monsters;

    private void OnEnable()
    {
        _monsters = GameObject.FindGameObjectsWithTag("Monster");

    }

    private void Update()
    {
        if (MonstersAreDead())
            NextLevel();
    }  

    void NextLevel()
    {
        Debug.Log("Got to next level."); 
        StartCoroutine(delayStart());
    } 
    
    private IEnumerator delayStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    bool MonstersAreDead()
    {
        foreach (var monster in _monsters)
        {
            if(monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
