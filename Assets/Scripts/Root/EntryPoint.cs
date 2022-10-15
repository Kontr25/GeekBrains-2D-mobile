using System;
using System.Collections;
using System.Collections.Generic;
using FruitNinja;
using TapMechanics;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private TrailView _trailView;
    [SerializeField] private TapView _tapView;
    
    private TrailModel _trailModel;
    private TrailController _trailController;
    
    private TapModel _tapModel;
    private TapController _tapController;
    
    private void Start()
    {
        _trailModel = new TrailModel(_trailView.Trail, _trailView.MainCamera);
        _trailController = new TrailController(_trailModel, _trailView);

        _tapModel = new TapModel(_tapView.TapEffect.transform, _tapView.MainCamera, _tapView.Rigidbody2D,
            _tapView.JumpForce);
        _tapController = new TapController(_tapModel, _tapView);
    }

    private void Update()
    {
        _trailModel?.Update();
        _tapModel?.Update();
    }

    private void OnDestroy()
    {
        _trailModel?.Dispose();
        _tapModel?.Dispose();
    }
}
