using UnityEngine;

public class ResourcesFortrres : MonoBehaviour
{
    [SerializeField] private WoodUI _woodUI;
    [SerializeField] private StoneUI _stoneUI;
    [SerializeField] private FoodUI _foodUI;
    [SerializeField] private GoldUI _goldUI;

    private WoodModel _woodModel;
    private StoneModel _stoneModel;
    private FoodModel _foodModel;
    private GoldModel _goldModel;

    private void Awake()
    {
        _woodModel = new WoodModel();
        _stoneModel = new StoneModel();
        _foodModel = new FoodModel();
        _goldModel = new GoldModel();

        _woodUI.Initialize(_woodModel);
        _stoneUI.Initialize(_stoneModel);
        _foodUI.Initialize(_foodModel);
        _goldUI.Initialize(_goldModel);
    }

    public void Visit(ResoursView resoursView, int value)
    {
        Visit((dynamic)resoursView, (dynamic)value);
    }

    public void Visit(Wood resoursView, int value)
    {
        _woodModel.Add(value);
    }

    public void Visit(Stone resoursView, int value)
    {
        _stoneModel.Add(value);
    }

    public void Visit(Food resoursView, int value)
    {
        _foodModel.Add(value);
    }
}
