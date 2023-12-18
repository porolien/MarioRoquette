using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public IBasePlayerState currentState;
    public IdleState idleState;
    public WalkState walkState;
    public RunState runState;
    public JumpState jumpState;
    public FallState fallState;
    public DieState dieState;
    public PlayerAnim playerAnim;
    public PlayerController pc;
    // Start is called before the first frame update
    void Awake()
    {
        idleState = new IdleState();
        walkState = new WalkState();
        runState = new RunState();
        fallState = new FallState();
        dieState = new DieState();
        jumpState = new JumpState();
        pc = GetComponent<PlayerController>();
        Transition(idleState);
    }

    private void Start()
    {
        pc._currentState = currentState;
        pc._fallState = fallState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        print(currentState.ToString());
    }

    //On va faire une transition pour changer l'état de notre ennemie ici,
    //de plus si l'état doit faire quelque chose quand l'ennemie rentre dans cet état ou en sort il le fera ici
    public void Transition(IBasePlayerState _theNewState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = _theNewState;
        currentState.OnEnter(this);
        Debug.LogAssertion(_theNewState);
    }
}

