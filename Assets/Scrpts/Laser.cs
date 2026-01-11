using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f; // Durée de vie maximale du laser
    [SerializeField] private float deadZoneTop = 8f; // Distance maximale avant destruction

    private void Start()
    {
        Debug.Log($"Laser créé à position: {transform.position}, DeadZone: {deadZoneTop}");
        // Détruire le laser après un certain temps (sécurité)
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Debug temporaire - retire après test
        Debug.Log($"Laser position Y: {transform.position.y}, DeadZone: {deadZoneTop}");

        // Vérifier la deadZone (haut de l'écran)
        if (transform.position.y > deadZoneTop)
        {
            Debug.Log("Laser détruit par deadZone haute");
            Destroy(gameObject);
        }

        // Vérifier aussi le bas de l'écran (au cas où le laser ferait demi-tour)
        if (transform.position.y < -deadZoneTop)
        {
            Debug.Log("Laser détruit par deadZone basse");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Détruire le laser s'il touche un ennemi ou un obstacle
        if (other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        // Sécurité supplémentaire : détruire quand le laser sort complètement de l'écran
        Destroy(gameObject);
    }
}