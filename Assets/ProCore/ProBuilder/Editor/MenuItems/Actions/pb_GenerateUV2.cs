﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using ProBuilder2.Common;

namespace ProBuilder2.Actions
{
	public class pb_GenerateUV2 : Editor
	{

		[MenuItem("Tools/" + pb_Constant.PRODUCT_NAME + "/Actions/Generate UV2 - Selection", false, pb_Constant.MENU_ACTIONS + 20)]
		public static void MenuGenerateUV2Selection()
		{
			pb_Object[] sel = Selection.transforms.GetComponents<pb_Object>();

			if( !GenerateUV2(sel) )
				return;	/// user canceled

			if(sel.Length > 0)
				pb_Editor_Utility.ShowNotification("Generated UV2 for " + sel.Length + " Meshes");
			else
				pb_Editor_Utility.ShowNotification("Nothing Selected");
		}

		[MenuItem("Tools/" + pb_Constant.PRODUCT_NAME + "/Actions/Generate UV2 - Scene", false, pb_Constant.MENU_ACTIONS + 20)]
		public static void MenuGenerateUV2Scene()
		{
			pb_Object[] sel = (pb_Object[])FindObjectsOfType(typeof(pb_Object));

			if( !GenerateUV2(sel) )
				return;

			if(sel.Length > 0)
				pb_Editor_Utility.ShowNotification("Generated UV2 for " + sel.Length + " Meshes");
			else
				pb_Editor_Utility.ShowNotification("No ProBuilder Objects Found");
		}

		static bool GenerateUV2(pb_Object[] selected)
		{			
			for(int i = 0; i < selected.Length; i++)
			{
				if(selected.Length > 3)
				{
					if( EditorUtility.DisplayCancelableProgressBar(
						"Generating UV2 Channel",
						"pb_Object: " + selected[i].name + ".",
						(((float)i+1) / selected.Length)))
					{
						EditorUtility.ClearProgressBar();
						Debug.LogWarning("User canceled UV2 generation.  " + (selected.Length-i) + " pb_Objects left without lightmap UVs.");
						return false;
					}
				}

				// True parameter forcibly generates UV2.  Otherwise if pbDisableAutoUV2Generation is true then UV2 wouldn't be built.
				selected[i].GenerateUV2(true);
                Debug.Log("generating UV2S!");
                var uv2 = selected[i].GetComponent<MeshFilter>().sharedMesh.uv2;
                foreach (var uv in uv2)
                {
                    if (uv.x > 1f || uv.y > 1f || uv.x < 0f || uv.y < 0f)
                    {
                        Debug.LogError("UV2 ERROR! OMG");
                        //selected[i].gameObject.SetActive(!selected[i].gameObject.activeSelf);
                        //selected[i].gameObject.SetActive(!selected[i].gameObject.activeSelf);
                        //selected[i].GenerateUV2(true);
                    }
                }
			}

			EditorUtility.ClearProgressBar();
			return true;
		}
	}
}