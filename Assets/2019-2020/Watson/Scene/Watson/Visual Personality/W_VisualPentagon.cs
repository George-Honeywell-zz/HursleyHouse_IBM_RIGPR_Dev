using UnityEngine;
public class W_VisualPentagon : MonoBehaviour
{
    W_GraphSetup graph;
    void Start()
    {
        graph = gameObject.AddComponent<W_GraphSetup>();
    }
    public void Show()
    {
        graph.Get().SetActive(true);
    }
    public void Hide()
    {
        graph.Get().SetActive(false);
    }
}
