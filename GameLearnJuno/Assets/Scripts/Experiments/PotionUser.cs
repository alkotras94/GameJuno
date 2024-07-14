using UnityEngine;
using TMPro;

public class PotionUser : MonoBehaviour, IPotionVisitor
{
    [SerializeField] private TMP_Text _text;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider.TryGetComponent(out Potion potion))
            {
                Visit(potion);
            }
        }

    }
    public void Visit(Potion potion)
    {
        Visit((dynamic)potion);
    }

    public void Visit(SpeedUpPotion speedUpPotion)
    {
        _text.text = "Включили метод добавления скорости";
    }

    public void Visit(HealthUpPotion healthUpPotion)
    {
        _text.text = "Включили метод добавления жизни";
    }

}
