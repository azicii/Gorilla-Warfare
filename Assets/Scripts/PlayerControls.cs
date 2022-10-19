using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Ship Position/Movement Modifiers")]
    [Tooltip("Input speed on X and Y axis")] [SerializeField] float controlSpeed = 10f;
    [Tooltip("The length the ship can move across the screen along the x axis")] [SerializeField] float xRange = 24f;
    [SerializeField] float yRange = 14f;
    [SerializeField] ParticleSystem[] lasers;

    [Header("Screen position based tuning")]
    [Tooltip("Offsets the amount the ship can travel up and down")] [SerializeField] float clampedCameraYOffsetFactor = 5f;
    [Tooltip("Sets the ship X rotation based on position")] [SerializeField] float positionPitchFactor = -1.5f;
    [Tooltip("Sets the ship Y rotation based on position")][SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [Tooltip("Sets the ship X rotation based on player input")][SerializeField] float controlPitchFactor = -30f;
    [Tooltip("Sets the ship Z rotation based on player input")] [SerializeField] float controlRollFactor = -15f;


    float xThrow;
    float yThrow;

    bool lasershot;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

   

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange + clampedCameraYOffsetFactor, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }


    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }

        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (ParticleSystem laser in lasers)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isActive;
        }
    }

}
