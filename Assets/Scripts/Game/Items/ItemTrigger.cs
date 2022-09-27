using UnityEngine;

public class ItemTrigger : MonoBehaviour {
    [SerializeField] private SpawnItems items;
    [SerializeField] private ItemEffects effects;
    [SerializeField] private GameObject pickupSFX;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Ball") {
            Instantiate(pickupSFX, transform.position, transform.rotation);
            effects.Apply(gameObject.name);
            items.itemPosList.Remove(collision.gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
