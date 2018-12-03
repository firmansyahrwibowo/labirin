using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    [SerializeField]
    int _StarCount = 0;
    int _MaxCollect = 3;

    bool _IsGoal = false;
    bool _CalledOnce = false;

    [SerializeField]
    List<GameObject> _DiamondObject = new List<GameObject>();

    
    public void ResetBehaviour()
    {
        _CalledOnce = false;
        _StarCount = 0;
        _IsGoal = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        for (int i = 0; i < _DiamondObject.Count; i++)
        {
            _DiamondObject[i].SetActive(true);
        }
        _DiamondObject = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal" && (_IsGoal || _StarCount > 2))
        {
            if (!_CalledOnce)
            {
                EventManager.TriggerEvent(new OnNextLevel());
                _CalledOnce = true;
            }
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            EventManager.TriggerEvent(new ObstacleEvent());
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP_BACK, false));
            Handheld.Vibrate();
        }

        if (collision.gameObject.tag == "Collectible")
        {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.STAR, false));
            _StarCount++;


            EventManager.TriggerEvent(new GetStarEvent(_StarCount - 1));

            collision.gameObject.SetActive(false);
            _DiamondObject.Add(collision.gameObject);
            if (_StarCount > 2)
                _IsGoal = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag != "Obstacle") || (collision.gameObject.tag != "Collectible") || (collision.gameObject.tag == "Goal"))
        {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.HIT_WALL, false));
        }
    }

}
