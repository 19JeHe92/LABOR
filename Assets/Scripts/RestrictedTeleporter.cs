using UnityEngine;
using NewtonVR;

[RequireComponent(typeof(NVRHand))]
public class RestrictedTeleporter : MonoBehaviour {

    public Color LineColor;
    public float LineWidth = 0.02f;

    private LineRenderer Line;

    private NVRHand Hand;

    private NVRPlayer Player;
    private bool limitHit = true;

    private void Awake()
    {
        Line = this.GetComponent<LineRenderer>();
        Hand = this.GetComponent<NVRHand>();

        if (Line == null)
        {
            Line = this.gameObject.AddComponent<LineRenderer>();
        }

        if (Line.sharedMaterial == null)
        {
            Line.material = new Material(Shader.Find("Unlit/Color"));
            Line.material.SetColor("_Color", LineColor);
            NVRHelpers.LineRendererSetColor(Line, LineColor, LineColor);
        }

        Line.useWorldSpace = true;
    }

    private void Start()
    {
        Player = Hand.Player;
    }

    private void LateUpdate()
    {
        Line.enabled = (Hand != null && Hand.Inputs[NVRButtons.Trigger].SingleAxis > 0.01f);

        if (Line.enabled == true)
        {
            Line.material.SetColor("_Color", LineColor);
            NVRHelpers.LineRendererSetColor(Line, LineColor, LineColor);
            NVRHelpers.LineRendererSetWidth(Line, LineWidth, LineWidth);

            RaycastHit hitInfo;
            bool hit = Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 1000);
            Vector3 endPoint;
            GameObject hitObject;
            if (hit == true)
            {
                endPoint = hitInfo.point;
                hitObject = hitInfo.transform.gameObject;
                if(hitObject.tag == "TeleportationLimit")
                {
                    Debug.Log("Wall detected");
                    limitHit = true;
                }

                if (Hand.Inputs[NVRButtons.Trigger].PressDown == true)
                {
                    NVRInteractable LHandInteractable = Player.LeftHand.CurrentlyInteracting;
                    NVRInteractable RHandInteractable = Player.RightHand.CurrentlyInteracting;

                    //offset of playable area and player
                    Vector3 offset = Player.Head.transform.position - Player.transform.position;
                    offset.y = 0;
                    offset.x = 0 + Player.PlayspaceSize.x/2;
                    Vector3 newPosition;
                    if (limitHit)
                    {
                        //Vector3 offsetFromLimit = new Vector3(Player.transform.position.x, 0, Player.transform.position.z/2);
                        //newPosition = hitInfo.point - offset - offsetFromLimit;
                        newPosition = hitInfo.point - offset;
                    }
                    else
                        newPosition = hitInfo.point - offset;
                    //So the player can't change it's height
                    newPosition.y = 0;
                    Player.transform.position = newPosition;

                    if (LHandInteractable != null)
                    {
                        LHandInteractable.transform.position = Player.LeftHand.transform.position;
                    }
                    if (RHandInteractable != null)
                    {
                        RHandInteractable.transform.position = Player.RightHand.transform.position;
                    }
                }
            }
            else
            {
                endPoint = this.transform.position + (this.transform.forward * 1000f);
            }

            Line.SetPositions(new Vector3[] { this.transform.position, endPoint });
        }
    }
}

