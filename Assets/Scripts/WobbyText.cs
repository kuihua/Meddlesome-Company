using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

public class WobbyText : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent;


    // Update is called once per frame
    void Update()
    {
        // ensure the meshes from text mesh pro are up to date
        // text mesh pro creates a 4 vertex mesh around each character therefore to edit, we have to access the character by refering the 4 vertices and modify them
        textComponent.ForceMeshUpdate();

        // local variable
        var textInfo = textComponent.textInfo;

        // ++1 is pre increment rather than incremeting after a loop
        for (int i = 0; i < textInfo.characterCount; ++i) {
            // storing the character info
            var charInfo = textInfo.characterInfo[i];

            // skip invisible character
            if (!charInfo.isVisible) {
                // continue skips the current iteration of the for loop instead of ending it if we were to use break;
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            // the wobbly text part, checks for 4 bc of the 4 vertices in the mesh
            for (int j = 0; j < 4; ++j) {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time*2f + orig.x*0.01f) * 10f, 0);
            }
        }

        // put the draft copy into the working copy. textInfo.meshInfo created another copy (the draft copy) so we need to put it into the "working" copy
        for (int i = 0; i < textInfo.meshInfo.Length; i++) {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}

// for only doing certain words (need exact line bc will have to modify or make a check or smt)
// In the `for (int i = 0; i < textInfo.characterCount; ++i) {...}` loop, `i` is the index of the character you are applying the effect to, so I just apply different effects for different values of `i`.

// for scaling words
// The way I'd go about this is to make another j=1 to 3 loop above the existing one, and use it to take the average of the four character vertex positions by summing them, then dividing by 4. Now you have the centre point of the character, you can do something like:
// verts[blah] = midPoint + (verts[blah] - midPoint)*scaleFactor;