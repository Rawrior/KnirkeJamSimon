using System.Collections.Generic;
using UnityEngine;

public class GamestateManager : MonoBehaviour
{
    public bool fadeInDone = false;
    public bool movedLeft = false;
    public bool movedRight = false;
    public bool seenHouse = false;
    public bool seenAdversary = false;
    public List<bool> booksPickedUp;
    public int hitCounter = 0;
}
