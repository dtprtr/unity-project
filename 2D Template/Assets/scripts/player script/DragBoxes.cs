using JetBrains.Annotations;
using UnityEngine;

public class DragBoxes : MonoBehaviour 


{
    public LayerMask DragLayers;

    [Range(0.0f, 100.0f)]
    public float m_Damping = 1.0f;

    [Range(0.0f, 100.0f)]
    public float m_frequncy = 5.0f;

    public bool m_DrawDragLine = true;
    public Color m_color = Color.cyan;

    [HideInInspector]public TargetJoint2D m_targtjoint;

    public float castDistance;

    public LayerMask checkBox;

    public Vector2 boxSize;

  



    

    // Update is called once per frame
    void Update()
    {
        
        



        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            var collider = Physics2D.OverlapPoint(worldPos, DragLayers);
            // ! is used for negating a positve bool.
            if (!collider)
                return;


            var body = collider.attachedRigidbody;
            if (!body)
                return;


            // adds target to rigidbody2d
            m_targtjoint = body.gameObject.AddComponent<TargetJoint2D>();
            m_targtjoint.dampingRatio = m_Damping;
            m_targtjoint.frequency = m_frequncy;

            m_targtjoint.anchor = m_targtjoint.transform.InverseTransformPoint(worldPos);

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, true);
        }
        else if (Input.GetMouseButtonUp(0) && m_targtjoint)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), m_targtjoint.GetComponent<Collider2D>(), false);

            Destroy(m_targtjoint);
            m_targtjoint = null;
            return;
        }

        if (m_targtjoint)
        {
            m_targtjoint.target = worldPos;

            if (m_DrawDragLine)
                Debug.DrawLine(m_targtjoint.transform.TransformPoint(m_targtjoint.anchor), worldPos, m_color);       
        }
        
    }
    public bool conPlayer()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, checkBox))
        {
            return true;
        }
        else
        {
            return false;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize);
    }
}
