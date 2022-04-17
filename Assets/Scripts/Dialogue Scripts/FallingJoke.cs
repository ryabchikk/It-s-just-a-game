using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingJoke : MonoBehaviour
{
    [SerializeField] Transform checker;
    Vector3 _startingPos;
    List<GameObject> _objectsToHide = new List<GameObject>();
    Transform _player;


    public void FallTrough(State state)
    {
        if (!(state is FallState))
            return;
        Debug.Log("Start falling");
        _startingPos = checker.parent.position;
        StartCoroutine(FallCoroutine());
    }

    IEnumerator FallCoroutine()
    {
        var gravity = Physics.gravity;
        Physics.gravity = new Vector3(0, 0, 0);
        Ray ray = new Ray(checker.parent.position, -checker.up);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject != null && hitObject != checker.gameObject)
            {
                Debug.Log(hitObject.name);
                _objectsToHide.Add(hitObject);
                hitObject.SetActive(false);
            }
        }

        yield return new WaitForSeconds(3);

        foreach (var _object in _objectsToHide)
        {
            _object.SetActive(true);
        }

        Physics.gravity = gravity;
        var characterController = checker.parent.GetComponent<CharacterController>();
        characterController.enabled = false;
        checker.parent.transform.position = _startingPos;
        characterController.enabled = true;
        //characterController.Move(_startingPos - checker.parent.transform.position);
    }
}
