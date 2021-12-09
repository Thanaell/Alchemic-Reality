using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
    NO_EFFECT,
	
    CHANGE_COLOR_TO_RED, //change color of the test subject to red
	CHANGE_COLOR_TO_YELLOW,
	CHANGE_COLOR_TO_BLUE,
	
	CHANGE_SIZE_TO_2, //x2 bigger
	CHANGE_SIZE_TO_0_25, //changing size to 0.25 (4x smaller)
	CHANGE_SIZE_TO_0_5, //x2 smaller
	
	//animations
	ANIM_JUMP,
	ANIM_FALL,
	ANIM_NOD, // with the head, to approve the potion
	ANIM_LOOK_AT_STOMACH, //because of stomachache
	ANIM_SPINNING,
	ANIM_FLYING
}
