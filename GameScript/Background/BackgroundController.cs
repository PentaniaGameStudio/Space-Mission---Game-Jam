using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : ObjectController
{
    protected Vector3 vector3;
    [SerializeField] private Sprite[] background;
    [SerializeField] private SpriteRenderer backgroundSprite;

    private void Awake()
    {
        vector3 = transform.position;
        backgroundSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }


    protected override void Update()
    {
        if (transform.position.y <= -22)
        {
            float particularspeed = transform.position.y + 22f;
            transform.position = new Vector3(vector3.x, 44f+particularspeed, vector3.z);
            BackgroundChange();
        }
        base.Update();
    }

    private void BackgroundChange()
    {
        int i = Random.Range(0, background.Length);
        backgroundSprite.sprite = background[i];
    }

}
