namespace LD38.Objects
{
    /// <summary>
    /// This class represents an ore. You can collect one "Metal" and then the object disables
    /// itself.
    /// </summary>
    public class Ore : Interactable
    {
        protected override void OnInteract()
        {
            Disable();
            Main.Get.Resources.IncreaseMetal(1);
        }
    }
}