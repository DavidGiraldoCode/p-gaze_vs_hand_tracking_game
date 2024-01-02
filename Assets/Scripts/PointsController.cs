using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    public TextMeshProUGUI pointsGainText; // 用于显示获得的分数
    public TextMeshProUGUI pointsLoseText; // 用于显示失去的分数
    public TextMeshProUGUI pointsTotalText; // 用于显示失去的分数
    public TextMeshProUGUI livesText; 

    public TextMeshProUGUI finalPointsText;
    public TextMeshProUGUI finalPointsTextGameOver;
    
    private int finalPoints;
    private int totalPoints; // 总分数
    private int pointsGain; // 获得的分数
    private int pointsLose; // 失去的分数
    private int lives;

    public int Points
    {
        get { return totalPoints; }
        set 
        { 
            totalPoints = value; 
            UpdateTotalPointsDisplay(); 
        }
    }

    public int Lives
    {
        get { return lives; }
        set 
        { 
            lives = value; 
            UpdateLivesDisplay(); 
            UpdatePointsGainDisplay();
            UpdatePointsLoseDisplay();
        }
    }

    private void Awake()
    {
        // 初始化时更新UI显示
        UpdateTotalPointsDisplay();
        UpdatePointsGainDisplay();
        UpdatePointsLoseDisplay();
        lives = 3;
        UpdateLivesDisplay();
    }

    private void UpdateLivesDisplay()
    {
        if (livesText != null)
        {
            livesText.text = lives.ToString("000");
        }
        else
        {
            Debug.LogError("LivesText reference not set in the Inspector.");
        }
    }

    private void UpdateTotalPointsDisplay()
    {
        if (pointsTotalText != null)
        {
            pointsTotalText.text = "Total: " + totalPoints.ToString("000");
        }
        else
        {
            Debug.LogError("PointsTotalText reference not set in the Inspector.");
        }
    }

    private void UpdatePointsGainDisplay()
    {
        if (pointsGainText != null)
        {
            pointsGainText.text = pointsGain.ToString("000");
        }
        else
        {
            Debug.LogError("PointsGainText reference not set in the Inspector.");
        }
    }

    private void UpdatePointsLoseDisplay()
    {
        if (pointsLoseText != null)
        {
            pointsLoseText.text = pointsLose.ToString("000");
        }
        else
        {
            Debug.LogError("FinalPointsText reference not set in the Inspector.");
        }
    }

    private void UpdateFinalPointsDisplay()
    {
        if (finalPointsText != null)
        {
            finalPointsText.text = "Final score: " + finalPoints.ToString();
        }
        else
        {
            Debug.LogError("FinalScoreText reference not set in the Inspector.");
        }
        if (finalPointsTextGameOver != null)
        {
            finalPointsTextGameOver.text = "Final score: " + finalPoints.ToString();
        }
        else
        {
            Debug.LogError("finalPointsTextGameOver reference not set in the Inspector.");
        }
        
    }
    
    public void AddPoints(int amount)
    {
        if (amount > 0)
        {
            pointsGain += amount;
            UpdatePointsGainDisplay();
        }
        else if (amount < 0)
        {
            pointsLose -= amount; // 因为amount是负数，所以我们减去一个负数，相当于加上它的绝对值
            UpdatePointsLoseDisplay();
        }

        Points += amount;
        finalPoints = Points;
        UpdateFinalPointsDisplay();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        UpdateLivesDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<Logic>().gameOverUI();
        }
        
    }
}
