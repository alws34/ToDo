namespace DoYourTasks
{
    public interface IViewable
    {
        void Rename(string newName);
        void SetCheckedState(bool mode);
        void Delete();

        string GetName();
        string GetTaskID();
        string GetParentTaskID();
        bool GetCheckedState();


    }
}
