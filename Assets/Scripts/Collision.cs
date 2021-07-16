using UnityEngine;
using UnityEngine.EventSystems;

public class Collision : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;

    public EventTrigger.TriggerEvent defeatTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Apple apple = collision.gameObject.GetComponent<Apple>();
        BaseEventData eventData = new BaseEventData(EventSystem.current);

        if (apple != null)
        {
            scoreTrigger.Invoke(eventData);
        }
        else
        {
            defeatTrigger.Invoke(eventData);
        }
    }
}
