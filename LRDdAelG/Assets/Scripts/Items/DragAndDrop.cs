//---------------------------------------------------------
// Zorro Cósmico
// Las Rimbombantes Desventuras de Alfredo el Gnomo (la criatura del bosque)
// ComJamon2025
//---------------------------------------------------------

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
// Añadir aquí el resto de directivas using


/// <summary>
/// Antes de cada class, descripción de qué es y para qué sirve,
/// usando todas las líneas que sean necesarias.
/// </summary>
public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // ---- ATRIBUTOS DEL INSPECTOR ----
    #region Atributos del Inspector (serialized fields)
    [SerializeField] GameObject prefab;
    [SerializeField] Tilemap tilemap; //tilemap

    #endregion

    // ---- ATRIBUTOS PRIVADOS ----
    #region Atributos Privados (private fields)
    private GameObject draggedObject;
    private Vector3Int lastValidCell;
    private bool isValidPlacement = false;

    #endregion
    
    // ---- MÉTODOS DE MONOBEHAVIOUR ----
    #region Métodos de MonoBehaviour

    #endregion

    // ---- MÉTODOS PÚBLICOS ----
    #region Métodos públicos
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedObject = Instantiate(prefab);
        draggedObject.transform.position = GetSnappedWorldPosition();
        draggedObject.transform.position = new Vector3(draggedObject.transform.position.x, temp.y, 0);

        SetObjectAlpha(draggedObject, 0.5f);
        SetObjectActiveState(draggedObject, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedObject == null) return;
        Vector3Int cellPosition = tilemap.WorldToCell(GetMouseWorldPosition());
        draggedObject.transform.position = tilemap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);

        if (CanPlaceObject(cellPosition)) lastValidCell = cellPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedObject == null) return;

        if (CanPlaceObject(lastValidCell)) draggedObject.transform.position = tilemap.CellToWorld(lastValidCell) + new Vector3(0.5f, 0.5f, 0);
        else Destroy(gameObject);

        SetObjectAlpha(draggedObject, 1f);
        SetObjectActiveState(draggedObject, true);
    }

    #endregion

    // ---- MÉTODOS PRIVADOS ----
    #region Métodos Privados
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = GameManager.Instance.GetPlayer().gameObject.transform.position.z;
        Debug.Log(mousePos);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool CanPlaceObject(Vector3Int cellPosition)
    {
        return ! tilemap.HasTile(cellPosition);
    }

    private Vector3 GetSnappedWorldPosition()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(GetMouseWorldPosition());
        return tilemap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);
    }

    private void SetObjectAlpha(GameObject objeto, float alpha)
    {
        MeshRenderer[] meshRenderers = objeto.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer renderer in meshRenderers)
        {
            foreach (Material material in renderer.materials)
            {
                Color color = material.color;
                color.a = alpha;
                material.color = color;
                material.SetFloat("Modo", 3);
            }
        }
    }

    private void SetObjectActiveState(GameObject objeto, bool estado)
    {
        MonoBehaviour[] scripts = objeto.GetComponentsInChildren<MonoBehaviour>();
        Collider2D[] colliders = objeto.GetComponentsInChildren<Collider2D>();
        foreach(var script in scripts)
        {
            script.enabled = estado;
        }
        foreach(var collider in colliders)
        {
            collider.enabled = estado;
        }
    }

    #endregion

} // class DragAndDrop 
// namespace
