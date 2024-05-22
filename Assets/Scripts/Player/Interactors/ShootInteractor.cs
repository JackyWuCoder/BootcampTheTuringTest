using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Player Shoot")]
    [SerializeField] private ObjectPool pool;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float shootVelocity;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMovementBehaviour playerMovementBehaviour;

    private float finalShootVelocity;

    [SerializeField] private InputType inputType;

    public enum InputType
    { 
        Primary,
        Secondary
    }

    public override void Interact()
    {
        if (inputType == InputType.Primary && playerInput.primaryButtonPressed
            || inputType == InputType.Secondary && playerInput.secondaryButtonPressed)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        finalShootVelocity = playerMovementBehaviour.GetForwardSpeed() + shootVelocity;

        PooledObject pooledObject = pool.GetPooledObject();
        pooledObject.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody bullet = pooledObject.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        // ForceMode.Impulse allows the bullet to travel a lot faster
        bullet.velocity = shootPoint.forward * finalShootVelocity;

        //Destroy(bullet.gameObject, 5.0f);
        pool.DestroyObjectFromPool(pooledObject, 5.0f);
    }
}
