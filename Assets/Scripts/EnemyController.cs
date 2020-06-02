using Assets.Scripts;
using Assets.Scripts.Settings;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SettingsManager settings;
    private GameState gameState;
    private Rigidbody rb;
    private bool isIceBlasted = false;
    private float timeBeforeIceBlastWearsOff = 0;
    private int hp;

    private void Start()
    {
        this.settings = SettingsManager.GetInstance();
        this.gameState = GameState.GetInstance();
        this.rb = GetComponent<Rigidbody>();
        this.rb.AddForce(this.transform.forward * settings.EnemySpeed, ForceMode.VelocityChange);
        this.hp = this.settings.EnemyHp;
    }

    private void FixedUpdate()
    {
        if (isIceBlasted)
        {
            timeBeforeIceBlastWearsOff -= Time.fixedDeltaTime;

            if (timeBeforeIceBlastWearsOff <= 0)
            {
                timeBeforeIceBlastWearsOff = 0;
                isIceBlasted = false;
                rb.AddForce(transform.forward * (settings.EnemySpeed * settings.IceBlastSlowDownFactor), ForceMode.VelocityChange);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            this.hp -= this.settings.BulletDamage;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("FireStrike"))
        {
            this.hp -= this.settings.FireStrikeDamage;
        }

        if (other.gameObject.CompareTag("IceBlast"))
        {
            if (!this.isIceBlasted)
            {
                this.isIceBlasted = true;
                this.rb.AddForce(- this.transform.forward * (this.settings.EnemySpeed * this.settings.IceBlastSlowDownFactor), ForceMode.VelocityChange);
            }

            this.timeBeforeIceBlastWearsOff += this.settings.IceBlastSlowDownPeriod;
        }

        if (this.hp <= 0)
        {
            this.gameState.EnemiesKilled++;
            Destroy(gameObject);
        }
    }
}
