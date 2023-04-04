using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    private Player player;
    private PipeSpawner pipeSpawner;

    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject getReady;
    public GameObject gameOver;

    private int score;
    public float getReadyTimer = 2.5f;


    private void Awake()
    {
        Application.targetFrameRate = 60;

        getReady.SetActive(true);
        gameOver.SetActive(false);

        player = FindObjectOfType<Player>();
        pipeSpawner = FindObjectOfType<PipeSpawner>();

        Pause();
    }


    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        StartCoroutine(GetReady());

        Time.timeScale = 1f;
        player.enabled = true;

        
        PipeMovement[] pipes = FindObjectsOfType<PipeMovement>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void IncreaseScore()
    {
        Debug.Log(score);

        score++;
        scoreText.text = score.ToString();
    }


    public void GameOver()
    {
        Debug.Log("Game Over! You are noob lol XD");

        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }


    IEnumerator GetReady()
    {
        yield return null;
        getReady.SetActive(true);

        yield return new WaitForSeconds(getReadyTimer);
        getReady.SetActive(false);
    }
}
