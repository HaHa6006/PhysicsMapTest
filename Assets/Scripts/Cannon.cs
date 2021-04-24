using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cannon : ModTool.Interface.ModBehaviour
{
    public Rigidbody _cannonBallPrefab;
    public Transform _spawnPoint;
    public float _launchForce = 100, _timeInterval = 3;
    public int _maxCannonBalls = 5;
    public int _cannonBallSolverIterations = 8,
                                 _cannonBallVelSolverIterations = 8;

    private float timer;
    private Queue<Rigidbody> _cannonBalls;

    // Start is called before the first frame update
    void Start()
    {
        _cannonBalls = new Queue<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < _timeInterval) timer += Time.deltaTime;
        else
        {
            var cannonBall = SpawnCannonBall();
            cannonBall.velocity = cannonBall.angularVelocity = Vector3.zero;
            cannonBall.MovePosition(_spawnPoint.position);
            cannonBall.MoveRotation(_spawnPoint.rotation);
            cannonBall.AddForce(_spawnPoint.forward * _launchForce, ForceMode.Impulse);

            timer = 0;
        }
    }

    private Rigidbody SpawnCannonBall()
    {
        if (_cannonBalls.Count < _maxCannonBalls)
        {
            var cannonBall = Instantiate(_cannonBallPrefab);
            cannonBall.solverIterations = _cannonBallSolverIterations;
            cannonBall.solverVelocityIterations = _cannonBallVelSolverIterations;
            _cannonBalls.Enqueue(cannonBall);
            return cannonBall;
        }
        else
        {
            var cannonBall = _cannonBalls.Dequeue();
            _cannonBalls.Enqueue(cannonBall);
            return cannonBall;
        }
    }
}
