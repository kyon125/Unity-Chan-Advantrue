using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("���a�Ѽ�")]
    public GameObject player;
    public Collider2D playerCollider2D;
    public Rigidbody2D playerRigibody2D;
    #region �t�β�
    private CharacterSystemMediator characterSystem;
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        Initial();
    }
    private void Start(){
        SystemInitial();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void Initial() {
        characterSystem = new CharacterSystemMediator();
    }
    public void SystemInitial()
    {
        characterSystem.Initial();
    }
}
