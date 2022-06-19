using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpeedLimitScript : MonoBehaviour
{
    public void UpdateScoreLimit()
    {
        {
            if(this.gameObject.name == "SpeedLimitSign20")
            {
                SpeedLimitScript.UpdateSpeedLimit(20);
            } else if(this.gameObject.name == "SpeedLimitSign50")
            {
                SpeedLimitScript.UpdateSpeedLimit(50);
            }
            else if (this.gameObject.name == "SpeedLimitSign110")
            {
                SpeedLimitScript.UpdateSpeedLimit(110);
            }

        }
    }
}
