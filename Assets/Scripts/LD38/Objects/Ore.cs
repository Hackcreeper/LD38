namespace LD38.Objects
{
    public class Ore : Interactable
    {
        protected override void OnInteract()
        {
            Disable();
            Main.Get.Resources.IncreaseMetal(1);
        }
    }
}