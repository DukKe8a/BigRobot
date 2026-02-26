using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public float maxHealth = 100f;
    public float currentHealth;

    public Image healthBarFill;
    public GameObject deathScreen;

    public AudioSource Sounds;

    public AudioClip damageClip;
    public AudioClip DefeatClip;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateBar();
        deathScreen.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        Sounds.PlayOneShot(damageClip);

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Jugador muerto");
            GameOver();
        }
        else
        {
            StartCoroutine(CameraShake());
        }
    }

    IEnumerator CameraShake()
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 originalPosition = cameraTransform.localPosition;
        float duration = 0.2f;
        float magnitude = 0.2f;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
    }

    void UpdateBar()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth > maxHealth * 0.5f)
        {
            float t = (currentHealth - maxHealth / 2) / (maxHealth / 2);
            healthBarFill.color = Color.Lerp(Color.yellow, Color.green, t);
        }
        else
        {
            float t = currentHealth / (maxHealth / 2);
            healthBarFill.color = Color.Lerp(Color.red, Color.yellow, t);
        }
    }
    
    void GameOver()
    {
        Sounds.PlayOneShot(DefeatClip);        
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

    public void RestartGame(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}