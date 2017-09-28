using UnityEngine.UI;
using UnityEngine;

public class PlayerStaminaBar : MonoBehaviour {

    
    public float maxStamina;
    [SerializeField] private float currentStamina;
    public float staminaFallRate;
    public float staminaFallMultiplier;
    public float staminaRegenRate;
    public float staminaRegenMultiplier;
    bool running;
    bool sprinting;
    public Image staminaBar;


    void Awake()
    {
        currentStamina = maxStamina;
  
    }

    void Update()
    {
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        HandleBar();
        if (GetComponent<PlayerMovement>().isRunning == true)
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (GetComponent<PlayerMovement>().isSprinting == true)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
        HandleStamina();
    }

    private void HandleBar()
    {
        staminaBar.fillAmount = Map(currentStamina, maxStamina);
    }

    private float Map(float currentStamina,  float maxStamina)
    {
        return (currentStamina) * 0.5f / maxStamina;
    }

    void HandleStamina()
    {
        if (running == true && sprinting == false)
        {
            currentStamina -= Time.deltaTime * staminaFallRate;
        }
        else if (running == true && sprinting == true)
        {
            currentStamina -= Time.deltaTime * (staminaFallRate * staminaFallMultiplier);
        }
        else if (running == false)
        {
            currentStamina += Time.deltaTime / staminaRegenRate * staminaRegenMultiplier;
        }

        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina <= 0)
        {
            currentStamina = 0;
            GetComponent<PlayerMovement>().sprintModifier = 1f;
        }
        else if (currentStamina >= 10)
        {
            GetComponent<PlayerMovement>().sprintModifier = GetComponent<PlayerMovement>().sprintModifierNorm;
        }

    }
}
