namespace XElement.RedYellowBlue.UI.UWP.Model.AutoSave
{
    internal interface IAutoSaveTarget
    {
        IAutoSaveTarget DeepClone();


        bool NeedsToBePersisted( IAutoSaveTarget old );


        void Persist();
    }
}
