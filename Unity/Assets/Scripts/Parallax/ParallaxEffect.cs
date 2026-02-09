using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] public float amountOfParallax; // This is amount of parallax scroll.
    public Camera mainCamera; // Reference of the camera.
    private float _lengthOfSprite; // This is the length of the sprites.
    private float _startingPos; // This is starting position of the sprites.

    private void Start()
    {
        //Getting the starting X position of sprite.
        _startingPos = transform.position.x;
        //Getting the length of the sprites.
        _lengthOfSprite = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        var position = mainCamera.transform.position;
        var temp = position.x * (1 - amountOfParallax);
        var distance = position.x * amountOfParallax;

        var newPosition = new Vector3(_startingPos + distance, transform.position.y, transform.position.z);

        transform.position = newPosition;

        if (temp > _startingPos + _lengthOfSprite / 2) _startingPos += _lengthOfSprite;
        else if (temp < _startingPos - _lengthOfSprite / 2) _startingPos -= _lengthOfSprite;
    }
}
