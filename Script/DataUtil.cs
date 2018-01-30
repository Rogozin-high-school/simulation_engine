using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public static class DataUtil {

	/*
	Converts an integer to 4 bytes.
	*/
	public static byte[] ItB(int input)
	{
		return BitConverter.GetBytes(input);
	}

	/*
	Converts 4 bytes array to an integer value.
	*/
	public static int BtI(byte[] input) 
	{
		return BitConverter.ToInt32(input, 0);
	}
}
