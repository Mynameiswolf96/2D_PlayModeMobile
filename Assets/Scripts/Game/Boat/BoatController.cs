using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

internal class BoatController : TransportController
{
    private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Boat");
    private readonly BoatView _view;

    public GameObject ViewGameObject => _view.gameObject;

    public BoatController() : base()
    {
        _view = LoadView();
    }

    private BoatView LoadView()
    {
        GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
        GameObject objectView = Object.Instantiate(prefab);
        AddGameObject(objectView);

        return objectView.GetComponent<BoatView>();
    }
}
