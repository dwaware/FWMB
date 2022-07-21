using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject buildingPrefab;
    public GameObject buildingCollection;
    public List<GameObject> buildings;


    public void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                Vector3 _vector3 = new Vector3(x, 0, z) * 5;
                int _bldgIndex = x * 10 + z;
                int _bldgNum = _bldgIndex + 1;
                GameObject _building = buildings[_bldgIndex];
                _building = Instantiate(buildingPrefab, _vector3, Quaternion.identity);
                buildings[_bldgIndex] = _building;
                _building.name = "Bldg# " + _bldgNum.ToString();
                _building.transform.SetParent(buildingCollection.transform);
                if (_bldgNum % 3 == 0)
                {
                    Renderer _renderer = _building.GetComponent<Renderer>();
                    _renderer.material.color = Color.red;
                    _building.name += " Fizz";
                    //StartCoroutine(GrowBuilding(_building, 2f));
                }
                if (_bldgNum % 5 == 0)
                {
                    Renderer _renderer = _building.GetComponent<Renderer>();
                    _renderer.material.color = Color.green;
                    _building.name += " Buzz";
                    //StartCoroutine(GrowBuilding(_building, 3f));
                }
                if (_bldgNum % 15 == 0)
                {
                    Renderer _renderer = _building.GetComponent<Renderer>();
                    _renderer.material.color = Color.blue;
                }
            }
        }

        IEnumerator GrowBuilding(GameObject _go, float _delay)
        {
            //wait....
            yield return new WaitForSeconds(_delay);
            _go.transform.localScale = new Vector3(_go.transform.localScale.x, _go.transform.localScale.y*_delay, _go.transform.localScale.z);
        }
    }
}
