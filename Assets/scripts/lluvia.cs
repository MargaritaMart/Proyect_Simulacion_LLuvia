using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lluvia : MonoBehaviour
{
    public float fMass, fSpeed, fRadius;
    public Vector3 vPosition, vVelocity, vForces, vGravity;
    private float GRAVITY = -9.8f;
    public float AIRDENSITY = 1.23f, DRAGCOE = 0.6f, WINDSPEED;
    public controler control;
    // Start is called before the first frame update
    void Start()
    {
        fMass = 1.0f;
        vPosition = this.transform.position;
        vVelocity = Vector3.zero;
        fSpeed = 0;
        vForces = Vector3.zero;
        fRadius = 0.1f;
        vGravity = Vector3.zero;
        vGravity.y = fMass * GRAVITY;

        control = FindObjectOfType<controler>();

    }

    // Update is called once per frame
    void Update()
    {
        CalForces();
        UpdateBody(Time.deltaTime);
        WINDSPEED = control.WINDSPEED;
    }
    void CalForces()
    {
        //reset forces
        vForces.x = 0.0f;
        vForces.y = 0.0f;

        //aggregate forces
        vForces += vGravity;

        //still air drag
        Vector3 vDrag = Vector3.zero;
        float fDrag;

        vDrag -= vVelocity;
        vDrag = vDrag.normalized;
        fDrag = 0.5f * AIRDENSITY * fSpeed * fSpeed * (Mathf.PI * fRadius * fRadius) * DRAGCOE;

        vDrag *= fDrag;

        vForces += vDrag;

        //windUwU
        Vector3 vWind = Vector3.zero;
        vWind.x = 0.5f * AIRDENSITY * WINDSPEED * WINDSPEED * (Mathf.PI * fRadius * fRadius) * DRAGCOE;
        vForces += vWind;
    }
    void UpdateBody(float dt)
    {
        Vector3 a, dv, ds;

        //integrate equation of motion
        a = vForces / fMass;

        dv = a * dt;
        vVelocity += dv;

        ds = vVelocity * dt;
        vPosition += ds;

        //misc. calculation
        fSpeed = vVelocity.magnitude;
        this.transform.position = vPosition;
    }
}
