using UnityEngine;

public class TwoDPlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private float velocityX;
    private float velocityZ;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maxWalkVelocity = 0.5f;
    public float maxSprintVelocity = 2.0f;

    int VelocityZHash;
    int VelocityXHash;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        VelocityZHash = Animator.StringToHash("VelocityZ");
        VelocityXHash = Animator.StringToHash("VelocityX");
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity = sprintPressed ? maxSprintVelocity : maxWalkVelocity;

        ChangeVelocity(forwardPressed, backwardPressed, leftPressed, rightPressed, sprintPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPressed, backwardPressed, leftPressed, rightPressed, sprintPressed, currentMaxVelocity);

        _animator.SetFloat(VelocityZHash, velocityZ);
        _animator.SetFloat(VelocityXHash, velocityX);
    }

    private void ChangeVelocity(bool forwardPressed, bool backwardPressed, bool leftPressed, bool rightPressed, bool sprintPressed, float currentMaxVelocity)
    {
        if (backwardPressed && leftPressed || backwardPressed && rightPressed)
        {
            currentMaxVelocity = maxWalkVelocity;
        }
        
        
        
        //if (forwardPressed && velocityZ < currentMaxVelocity)
        //{
            //velocityZ += Time.deltaTime * acceleration;
        //}
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        
        
        
        if (backwardPressed && velocityZ > -maxWalkVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }



        //if (!forwardPressed && velocityZ > 0.0f)
        //{
            //velocityZ -= Time.deltaTime * deceleration;
        //}



        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        
        
        
        if (!backwardPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
    }

    private void LockOrResetVelocity(bool forwardPressed, bool backwardPressed, bool leftPressed, bool rightPressed, bool sprintPressed, float currentMaxVelocity)
    {
        //if (!forwardPressed && velocityZ < 0.0f)
        //{
            //velocityZ = 0.0f;
        //}
        if (!leftPressed && !rightPressed && velocityX != 0 && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
        
        
        
        if (!backwardPressed && !forwardPressed && velocityZ != 0 && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }



        //if (forwardPressed && sprintPressed && velocityZ > currentMaxVelocity)
        //{
            //velocityZ = currentMaxVelocity;
        //}
        //else if (forwardPressed && velocityZ > currentMaxVelocity)
        //{
            //velocityZ -= Time.deltaTime * deceleration;
            //if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05))
            //{
                //velocityZ = currentMaxVelocity;
            //}
        //}
        //else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        //{
            //velocityZ = currentMaxVelocity;
        //}



        if (leftPressed && sprintPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }



        if (rightPressed && sprintPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
        
        
        
        if (backwardPressed && sprintPressed && velocityZ < -currentMaxVelocity)
        {
            velocityZ = -currentMaxVelocity;
        }
        else if (backwardPressed && velocityZ < -currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * deceleration;
            if (velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.05f))
            {
                velocityZ = -currentMaxVelocity;
            }
        }
        else if (backwardPressed && velocityZ > -currentMaxVelocity && velocityZ < (-currentMaxVelocity + 0.05f))
        {
            velocityZ = -currentMaxVelocity;
        }
        
        
        
        if (forwardPressed && sprintPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }
        
    }
}
