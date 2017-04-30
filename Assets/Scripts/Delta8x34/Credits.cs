using UnityEngine;

public class Credits : MonoBehaviour
{
    #region PROTECTED_VARS

    [SerializeField] protected RectTransform CreditsPanel;

    #endregion

    #region PUBLIC_METHODS

    public virtual void Open()
    {
        gameObject.SetActive(false);
        CreditsPanel.gameObject.SetActive(true);
    }

    #endregion
}
