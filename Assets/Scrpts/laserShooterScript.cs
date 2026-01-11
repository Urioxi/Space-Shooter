using UnityEngine;
using UnityEngine.InputSystem;

public class LaserShooter : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float fireRate = 0.2f; // Temps entre chaque tir (en secondes)

    [Header("Spawn Point")]
    [SerializeField] private Transform firePoint; // Point d'où part le laser

    private float nextFireTime = 0f;

    private void Update()
    {
        // Vérifier si on peut tirer et si la touche espace est pressée
        if (CanShoot() && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextFireTime;
    }

    private void Shoot()
    {
        if (laserPrefab == null)
        {
            Debug.LogWarning("Laser prefab non assigné !");
            return;
        }

        // Calculer la position de spawn
        Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;

        // Instancier le laser
        GameObject laser = Instantiate(laserPrefab, spawnPosition, Quaternion.identity);

        // Configurer la direction et vitesse du laser
        Rigidbody2D laserRb = laser.GetComponent<Rigidbody2D>();
        if (laserRb != null)
        {
            laserRb.linearVelocity = Vector2.up * laserSpeed;
        }

        // Mettre à jour le prochain temps de tir
        nextFireTime = Time.time + fireRate;
    }
}
