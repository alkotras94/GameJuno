using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPotionVisitor
{
    void Visit(Potion potion);
    void Visit(SpeedUpPotion speedUpPotion);
    void Visit(HealthUpPotion healthUpPotion);
}
