using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCube : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject destroyParticle;
    private void Start()
    {
        StartCoroutine(PlayAnimationAfterTime());
    }

    IEnumerator PlayAnimationAfterTime()
    {
        float time = Random.Range(0f, 3f);
        yield return new WaitForSeconds(time);
        int animNum = Random.Range(0, 3);
        animator.speed = Random.Range(0.1f, 0.7f);
        if (animNum > 1)
        {
            animator.Play("KillCubeMovement");

        }
        else
        {
            animator.Play("KillCubeMovementTwo");
        }
    }

    public void PlayDestroyParticle()
    {
        GameObject particleObj = Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(particleObj, 5f);
    }
}
