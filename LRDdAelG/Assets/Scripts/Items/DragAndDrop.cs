//---------------------------------------------------------
// Zorro Cósmico
// Las Rimbombantes Desventuras de Alfredo el Gnomo (la criatura del bosque)
// ComJamon2025
//---------------------------------------------------------

using Unity.VisualScripting;
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
    public GameObject prefab;
    public Sprite itemImage;
    [SerializeField] Tilemap tilemap; //tilemap
    [SerializeField] Vector2Int objectSize = new Vector2Int(1, 1);
    [SerializeField] float cooldown = 3;

    #endregion

    // ---- ATRIBUTOS PRIVADOS ----
    #region Atributos Privados (private fields)
    private GameObject draggedObject;
    private Image image;
    private Vector3Int lastValidCell;
    private bool isValidPlacement = false;
    private bool firstTime = true;
    private float timer;

    #endregion

    // ---- MÉTODOS DE MONOBEHAVIOUR ----
    #region Métodos de MonoBehaviour
    void Start()
    {
        timer = 0;
        image = GetComponent<Image>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer >= 0) image.color = new Color(0.5f, 0.5f, 0.5f, 1);
        else image.color = new Color(1, 1, 1, 1);

    }
    #endregion

    // ---- MÉTODOS PÚBLICOS ----
    #region Métodos públicos
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (timer > 0) return;
        if (firstTime)
        {
            draggedObject = Instantiate(prefab);
            draggedObject.tag = "Custom";
        }
        draggedObject.transform.position = GetSnappedWorldPosition();
        draggedObject.transform.position = new Vector3(draggedObject.transform.position.x, draggedObject.transform.position.y, 0);

        SetObjectActiveState(draggedObject, false);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (timer <= 0)
        {
            if (draggedObject == null) return;
            Vector3 position = GetSnappedWorldPosition();
            draggedObject.transform.position = position;

            isValidPlacement = CanPlaceObject(position, objectSize);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedObject == null || timer > 0) return;

        Vector3 finalPosition = GetSnappedWorldPosition();
        if (isValidPlacement)
        {
            draggedObject.transform.position = finalPosition;
            SetObjectActiveState(draggedObject, true);
            firstTime = false;
            timer = cooldown;
        }
        else
        {
            Destroy(draggedObject);
            firstTime = true;
        }
    }

    #endregion

    // ---- MÉTODOS PRIVADOS ----
    #region Métodos Privados

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0;
        return worldPosition;
    }

    private bool CanPlaceObject(Vector3 position, Vector2 tamaño)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, tamaño / 2, 0);

        Debug.Log($"Detecado colliders: {colliders.Length} en {position}");
        return colliders.Length == 0;
    }

    private Vector3 GetSnappedWorldPosition()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(GetMouseWorldPosition());
        return tilemap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.3f, 0);
    }

    private void SetObjectActiveState(GameObject objeto, bool estado)
    {
        MonoBehaviour[] scripts = objeto.GetComponentsInChildren<MonoBehaviour>();
        Collider2D[] colliders = objeto.GetComponentsInChildren<Collider2D>();
        foreach (var script in scripts)
        {
            script.enabled = estado;
        }
        foreach (var collider in colliders)
        {
            collider.enabled = estado;
        }
    }

    #endregion

} // class DragAndDrop 
// namespace
