using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerScript;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private float _screenSpeed;

    private void OnEnable()
    {
        onPlayerDie += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        onPlayerDie -= HandlePlayerDeath;
    }

    public float ScreenSpeed => _screenSpeed * 100;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance.gameObject);
    }

    public void HandlePlayerDeath()
    {

    }
}
