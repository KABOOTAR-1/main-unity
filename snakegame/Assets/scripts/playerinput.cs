using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinput : MonoBehaviour
{
    private playercontroller playercont;
    public  int x = 0, y = 0;

   private enum axis
    {
        Horizzontal,
        Vertical
    }
    void Start()
    {
        playercont = GetComponent<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        x = 0;
        y = 0;
        GetKeyBoardInput();
        SetMovemnet();
    }

   public void GetKeyBoardInput()
    {
        x = getaxisraw(axis.Horizzontal);
        y = getaxisraw(axis.Vertical);

        if (x != 0)
        {
            y = 0;
        }


    }
    void SetMovemnet()
    {
        if (y != 0)
        {
            playercont.inputdirection(y == 1 ? playerDirection.UP : playerDirection.DOWN);
        }
        else if (x != 0)
        {
            playercont.inputdirection(x == 1 ? playerDirection.RIGHT : playerDirection.LEFT);
        }
    }

    int getaxisraw(axis ax)
    {
        if (ax == axis.Horizzontal)
        {
            bool left = Input.GetKeyDown(KeyCode.LeftArrow);
            bool right = Input.GetKeyDown(KeyCode.RightArrow);


            if (left)
            {
                return -1;
            }
            if (right)
            {
                return 1;
            }
            return 0;
        }
        if (ax == axis.Vertical)
        {
            bool up = Input.GetKeyDown(KeyCode.UpArrow);
            bool down = Input.GetKeyDown(KeyCode.DownArrow);

            if (up)
            {
                return 1;
            }
            if (down)
            {
                return -1;
            }
            return 0;
        }
        return 0;
    }

}
