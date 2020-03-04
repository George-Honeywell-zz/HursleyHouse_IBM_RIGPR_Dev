using UnityEngine;
public class W_VisualPentagon : MonoBehaviour
{
    W_AxisSetup axis;
    W_GraphSetup graph;
    void Start()
    {
        axis = gameObject.AddComponent<W_AxisSetup>();
        graph = gameObject.AddComponent<W_GraphSetup>();
    }
    public void Show()
    {
        axis.Get().SetActive(true);
        graph.Get().SetActive(true);
    }
    public void Hide()
    {
        axis.Get().SetActive(false);
        graph.Get().SetActive(false);
    }
}
