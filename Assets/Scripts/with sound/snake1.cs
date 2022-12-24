using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake1 : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    private List<Transform> _tail = new List<Transform>();
    public Transform segmentPrefab;
    public Transform tailPrefab;
    public GameManager GM;

    public int initialSize = 3;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {                                                                                                       //HAREKET KOMUTLARI
        if (Input.GetKeyDown(KeyCode.W)) _direction = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S)) _direction = Vector2.down;
        if (Input.GetKeyDown(KeyCode.D)) _direction = Vector2.right;
        if (Input.GetKeyDown(KeyCode.A)) _direction = Vector2.left;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            GM.PauseGame();
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--) _segments[i].position = _segments[i - 1].position;   //Govde(segment) parcalarinin takip etmesi

        this.transform.position = new Vector3(                                                             //kafanin onde olmasi, yonun dogru hesaplanmasi
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f);
    }

    private void Grow()                                                                                   //Yeni govde olusturmasi
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)                                                        //Food objesi alindiginda buyume fonksiyonu cagrisi
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            GameObject.FindObjectOfType<AudioManager>().playsong("dead2");
            ResetState();
        }
    }
    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }
}
