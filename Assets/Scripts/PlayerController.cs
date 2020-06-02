using Assets.Scripts;
using Assets.Scripts.Settings;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyParent;
    public Rigidbody bulletPrefab;
    public GameObject bulletParent;
    public Rigidbody fireStrikePrefab;
    public GameObject fireStrikeParent;
    public Rigidbody iceBlastPrefab;
    public GameObject iceBlastParent;
    public UiController uiController;
    public bool constantFire;

    private int hp;
    private float timeSinceSpawn = 0;
    private SettingsManager settings;
    private GameState gameState;

    private void Start()
    {
        this.settings = SettingsManager.GetInstance();
        this.gameState = GameState.GetInstance();
        this.hp = this.settings.PlayerHp;
        this.gameState.GameStartTime = Time.time;
    }

    private void Update()
    {
        this.RotateTowardsMouse();
        this.HandleShooting();
        this.HandleEnemySpawning();
        this.HandleSpellCasting();
        this.HandleGameQuiting();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.hp -= 50;
            this.gameState.EnemiesKilled++;
            Destroy(other.gameObject);

            if (this.hp <= 0)
            {
                this.gameState.GameOver = true;
            }
        }
    }

    private void HandleSpellCasting()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !this.gameState.IsFireStrikeAtCoolDown)
        {
            var fireStrike = Instantiate(this.fireStrikePrefab, this.transform.position, this.transform.rotation, this.fireStrikeParent.transform);
            fireStrike.AddForce(this.transform.forward * this.settings.FireStrikeSpeed, ForceMode.VelocityChange);
            this.gameState.StartFireStrikeCoolDownTimer();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !this.gameState.IsIceBlastAtCoolDown)
        {
            var iceBlast = Instantiate(this.iceBlastPrefab, this.transform.position, this.transform.rotation, this.iceBlastParent.transform);
            iceBlast.AddForce(transform.forward * this.settings.IceBlastSpeed, ForceMode.VelocityChange);
            this.gameState.StartIceBlastCoolDownTimer();
        }
    }    

    private void HandleEnemySpawning()
    {
        this.timeSinceSpawn += Time.deltaTime;

        if (this.timeSinceSpawn > this.settings.EnemiesSpawningInterval)
        {
            this.timeSinceSpawn = 0;

            for (int i = 0; i < this.settings.EnemiesSpawningCount; i++)
            {
                float angleInRadians = Random.Range(0, 2 * Mathf.PI);
                float posX = Mathf.Cos(angleInRadians) * this.settings.EnemySpawnRadius;
                float posZ = Mathf.Sin(angleInRadians) * this.settings.EnemySpawnRadius;
                Vector3 enemyPosition = this.transform.position + new Vector3(posX, 0, posZ);
                float angleInDegrees = -angleInRadians * Mathf.Rad2Deg - 90;
                var enemyRotation = Quaternion.Euler(0, angleInDegrees, 0);
                var enemy = Instantiate(this.enemyPrefab, enemyPosition, enemyRotation, this.enemyParent.transform);
                enemy.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.6f, 0.6f, 0.6f, 0.6f);
            }

            GameState.GetInstance().EnemiesAlive += this.settings.EnemiesSpawningCount;
        }
    }

    private void HandleShooting()
    {
        if (this.constantFire)
        {
            if (Input.GetMouseButton(0))
            {
                this.Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.Shoot();
            }
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate<Rigidbody>(this.bulletPrefab, this.transform.position, this.transform.rotation, this.bulletParent.transform);
        bullet.AddForce(this.transform.forward * this.settings.BulletSpeed, ForceMode.VelocityChange);
    }

    private void RotateTowardsMouse()
    {

        var mouse = Input.mousePosition;
        var playerPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        var subtraction = mouse - playerPosition;
        var angle = Mathf.Atan2(- subtraction.y, subtraction.x) * Mathf.Rad2Deg + 90;
        this.transform.eulerAngles = new Vector3(0f, angle, 0f);
    }

    private void HandleGameQuiting()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
