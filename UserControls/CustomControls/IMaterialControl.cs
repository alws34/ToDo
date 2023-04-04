namespace DoYourTaks
{
    public interface IMaterialControl
    {
        int Depth { get; set; }
        DoYourTasksManager SkinManager { get; }
        MouseState MouseState { get; set; }

    }

    public enum MouseState
    {
        HOVER,
        DOWN,
        OUT
    }
}
