using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    [SerializeField]
    int _StarCount = 0;
    int _MaxCollect = 3;

    bool _IsGoal = false;

    [SerializeField]
    List<GameObject> _DiamondObject = new List<GameObject>();

    public void ResetBehaviour()
    {
        _StarCount = 0;
        _IsGoal = false;
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
            EventManager.TriggerEvent(new OnNextLevel());

        }

        if (collision.gameObject.tag == "Obstacle")
        {
            EventManager.TriggerEvent(new ObstacleEvent());
        }

        if (collision.gameObject.tag == "Collectible")
        {
            _StarCount++;
            EventManager.TriggerEvent(new GetStarEvent(_StarCount - 1));

            collision.gameObject.SetActive(false);
            _DiamondObject.Add(collision.gameObject);
            if (_StarCount > 2)
                _IsGoal = true;
        }
    }
}
