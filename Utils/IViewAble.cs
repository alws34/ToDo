namespace DoYourTasks
{
    public interface IViewAble
    {
        void Rename(string newName);
        void SetCheckedState(bool mode);
        void Delete();

        string GetName();
        string GetID();
        string GetParentTaskID();
        bool GetCheckedState();


    }
}
