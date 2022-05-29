using ReactiveUI;

namespace BD_futball_NT.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public virtual object GetTable() { return null; }
    }
}
