using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image _bar_lifeBarFillable;
    [SerializeField] private TextMeshProUGUI _lifeText;




    public void OnChangeLife(int hp, int maxhp)
    {
        _lifeText.text = hp + "/" + maxhp;
        _bar_lifeBarFillable.fillAmount = (float)hp / maxhp;
    }

    public void OnDefeated()
    {
        Destroy(gameObject);
    }

}
