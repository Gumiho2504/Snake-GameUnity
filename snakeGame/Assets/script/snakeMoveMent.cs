using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class snakeMoveMent : MonoBehaviour
{
    private Vector2 _diraction = Vector2.right;
    private List<Transform> _segment= new List<Transform>();
    public Transform segmentPrefab;
    public int point=0 ,pointover= 0;
    public Text pointText,pointOvertxt;
    public int hightscore = 0;
    public Text hightscoretxt;
    public int initialSize=1;
    public GameObject bigfood,gameOver,gameSnake;
    public int fakepoint = 0;
    private bool arrow = true;
    private bool arrow1 = true;
    private void Start()
    {
        ResetState();
       
    }
    private void Update()
    {
        if (fakepoint/5 >= 1 && fakepoint % 5 == 0)
        {
            bigfood.SetActive(true);
        }

        if ( fakepoint == 0)
        {
            bigfood.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && arrow == true)
        {
            arrow1 = true;
            arrow = false;
            _diraction = Vector2.up;
         
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && arrow == true)
        {
            arrow1 = true;
            arrow =false;    
            _diraction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && arrow1 == true)
        {
            arrow1 = false;
            arrow = true;
            _diraction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && arrow1 == true)
        {
            arrow1 = false;
            arrow = true;
            _diraction = Vector2.left;
        }
    }
    private void FixedUpdate()
    {
        for (int i = _segment.Count - 1; i > 0; i-- ){
            _segment[i].position = _segment[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _diraction.x , Mathf.Round(this.transform.position.y) + _diraction.y,0);
    }
    private void Grow()
    {
        
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segment[_segment.Count - 1].position;
        _segment.Add(segment);
    }
    private void ResetState()
    {
        point = 0; 
        fakepoint = 0;
        for (int i = 1; i < _segment.Count; i++)
        {
            Destroy(_segment[i].gameObject);
        }
        _segment.Clear();
        _segment.Add(this.transform);
        for (int i = 0; i < this.initialSize; i++)
        {
            _segment.Add(Instantiate(this.segmentPrefab));
        }
        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BigFood")
        {
            Grow();
            point = point +5;
            fakepoint = 0;
            pointText.text = point.ToString();
            if (point > hightscore)
            {
                hightscore = point;
                File.WriteAllText("hightscore.txt", hightscore.ToString());
            }
        }
        if (other.tag == "Food")
        {
            Grow();
            point++;
            fakepoint++;
            pointText.text = point.ToString();
            pointover = point;
            pointOvertxt.text = pointover.ToString();
            if (point > hightscore)
            {
                hightscore = point;
                File.WriteAllText("hightscore.txt", hightscore.ToString());
            }
        }else if ( other.tag == "O")
        {
            pointover = point;
            gameOver.SetActive(true);
            gameSnake.SetActive(false);
            ResetState();
            pointText.text = point.ToString();
            hightscoretxt.text = hightscore.ToString();
            pointOvertxt.text = pointover.ToString();


        }

    }
    
}

