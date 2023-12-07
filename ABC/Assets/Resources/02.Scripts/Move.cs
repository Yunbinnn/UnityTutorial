using UnityEngine;

public class Move : MonoBehaviour
{
    #region ī�޶�

    [SerializeField]
    private Camera cam;
    private float curCamRot;
    private readonly float camLimit = 90f;
    private readonly float sense = 1.3f;

    private float applySitPos;
    private readonly float sitDownPos = 0f;
    private readonly float sitUpPos = 0.5f;

    #endregion

    #region �÷��̾�

    private readonly float walkSpeed = 3f;
    private readonly float runSpeed = 6f;
    private readonly float sitSpeed = 1.8f;

    [SerializeField]
    private float applySpeed;

    private readonly float jumpForce = 2.5f;

    #endregion

    private bool isRun;
    private bool isGround;
    private bool isSit;

    private Rigidbody rigid;
    private CapsuleCollider capsule;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        cam.transform.localPosition = new Vector3(0, sitUpPos, 0);
        applySpeed = walkSpeed;
        applySitPos = sitUpPos;
        isRun = false;
        isGround = true;
        isSit = true;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Update()
    {
        Move_Input();
    }

    private void Moving()
    {
        IsGround();
        TrySit();
        TryRun();
        TryJump();
        camVer();
        camHor();
    }

    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Runnig();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isRun)
        {
            RunningCancle();
        }
    }

    private void Runnig()
    {
        isRun = true;
        applySpeed = runSpeed;
    }

    private void RunningCancle()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    private void Move_Input()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 _movHor = transform.right * h;
        Vector3 _movVer = transform.forward * v;

        Vector3 _Move = (_movHor + _movVer).normalized * applySpeed;

        rigid.MovePosition(transform.position + _Move * Time.deltaTime);
    }

    private void TrySit()
    {
        isSit = Input.GetKey(KeyCode.LeftControl);

        if (isSit)
        {
            applySpeed = sitSpeed;
            applySitPos = sitDownPos;
            Sit();
        }
        else
        {
            applySpeed = walkSpeed;
            applySitPos = sitUpPos;
            SitCancle();
        }
    }

    private void Sit()
    {
        float _PosY = cam.transform.localPosition.y;
        _PosY = Mathf.Lerp(_PosY, applySitPos, Time.deltaTime * 8f);
        cam.transform.localPosition = new Vector3(0, _PosY, 0);
    }

    private void SitCancle()
    {
        float PosY = cam.transform.localPosition.y;
        PosY = Mathf.Lerp(PosY, applySitPos, Time.deltaTime * 8f);
        cam.transform.localPosition = new Vector3(0, PosY, 0);
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigid.velocity = transform.up * jumpForce;
    }

    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsule.bounds.extents.y + 0.1f);
    }

    private void camVer()
    {
        float Rot_X = Input.GetAxisRaw("Mouse Y");

        float _camRotX = Rot_X * sense;

        curCamRot -= _camRotX;

        curCamRot = Mathf.Clamp(curCamRot, -camLimit, camLimit);

        cam.transform.localEulerAngles = new Vector3(curCamRot, 0, 0);
    }

    private void camHor()
    {
        float Rot_Y = Input.GetAxisRaw("Mouse X");

        Vector3 _camRotY = new Vector3(0, Rot_Y, 0) * sense;

        rigid.MoveRotation(transform.rotation * Quaternion.Euler(_camRotY));
    }
}