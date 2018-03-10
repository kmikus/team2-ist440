using System.Collections;
using System.Collections.Generic;

public class PlayerManager{

    // Manages the state of the player, accessable by outside scripts, for hit detection mainly
    private static bool recentlyHit = false;

    public static bool RecentlyHit
    {
        get
        {
            return recentlyHit;
        }

        set
        {
            recentlyHit = value;
        }
    }
}
