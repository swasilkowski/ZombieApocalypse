using Assets.Scripts.Settings;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private void Update()
    {
        if (this.transform.position.magnitude > SettingsManager.GetInstance().EnemySpawnRadius)
        {
            Destroy(gameObject);
        }
    }
}
